using ProjectTracker.Business.DTOs.Analytics;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Core.Enums;
using ProjectTracker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Business.Services
{
    /// <summary>
    /// Advanced analytics service implementation
    /// Provides burndown, EVM, velocity, and financial reporting
    /// </summary>
    public class AdvancedReportService : IAdvancedReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AdvancedReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        #region Burndown Chart
        
        public async Task<BurndownChartDto> GetProjectBurndownAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                throw new ArgumentException($"Project {projectId} not found");
            
            var tasks = (await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId)).ToList();
            var snapshots = (await _unitOfWork.ProjectSnapshots
                .FindAsync(s => s.ProjectId == projectId))
                .OrderBy(s => s.SnapshotDate)
                .ToList();
            
            var dataPoints = new List<BurndownDataPoint>();
            var totalDays = (project.EndDate.Value - project.StartDate).TotalDays;
            var initialHours = project.TotalPlannedHours ?? tasks.Sum(t => t.EstimatedHours ?? 0);
            
            // Generate data points from snapshots or calculate on-the-fly
            if (snapshots.Any())
            {
                foreach (var snapshot in snapshots)
                {
                    dataPoints.Add(new BurndownDataPoint
                    {
                        Date = snapshot.SnapshotDate,
                        ActualRemainingHours = snapshot.RemainingHours,
                        IdealRemainingHours = snapshot.IdealRemainingHours,
                        TasksCompleted = snapshot.CompletedTasksCount
                    });
                }
            }
            else
            {
                // Fallback: Calculate from current state
                var currentRemaining = tasks
                    .Where(t => t.Status != TaskStatus.Completed)
                    .Sum(t => t.EstimatedHours ?? 0);
                
                var today = DateTime.Today;
                var elapsedDays = (today - project.StartDate).TotalDays;
                var idealRemaining = CalculateIdealRemaining(
                    today, 
                    project.StartDate, 
                    project.EndDate.Value, 
                    initialHours);
                
                dataPoints.Add(new BurndownDataPoint
                {
                    Date = today,
                    ActualRemainingHours = currentRemaining,
                    IdealRemainingHours = idealRemaining,
                    TasksCompleted = tasks.Count(t => t.Status == TaskStatus.Completed)
                });
            }
            
            return new BurndownChartDto
            {
                ProjectId = projectId,
                ProjectName = project.ProjectName,
                DataPoints = dataPoints,
                ProjectStartDate = project.StartDate,
                ProjectEndDate = project.EndDate.Value,
                InitialPlannedHours = initialHours,
                CurrentRemainingHours = dataPoints.LastOrDefault()?.ActualRemainingHours ?? 0
            };
        }
        
        private decimal CalculateIdealRemaining(DateTime currentDate, DateTime startDate, DateTime endDate, decimal totalHours)
        {
            var totalDays = (endDate - startDate).TotalDays;
            var elapsedDays = (currentDate - startDate).TotalDays;
            
            if (elapsedDays <= 0) return totalHours;
            if (elapsedDays >= totalDays) return 0;
            
            var dailyBurnRate = totalHours / (decimal)totalDays;
            return totalHours - (dailyBurnRate * (decimal)elapsedDays);
        }
        
        #endregion
        
        #region Earned Value Management
        
        public async Task<EarnedValueDto> GetEarnedValueAnalysisAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                throw new ArgumentException($"Project {projectId} not found");
            
            if (!project.Budget.HasValue || project.Budget.Value == 0)
                throw new InvalidOperationException($"Project {projectId} has no budget defined");
            
            // Calculate Planned Value (PV)
            var totalDuration = (project.EndDate.Value - project.StartDate).TotalDays;
            var elapsedDuration = (DateTime.Today - project.StartDate).TotalDays;
            var plannedPercentage = Math.Min((decimal)(elapsedDuration / totalDuration), 1.0m);
            var PV = project.Budget.Value * plannedPercentage;
            
            // Calculate Earned Value (EV)
            var completedPercentage = project.CompletionPercentage / 100m;
            var EV = project.Budget.Value * completedPercentage;
            
            // Calculate Actual Cost (AC)
            var AC = await CalculateActualCostAsync(projectId);
            
            // Calculate EVM Metrics
            var CPI = AC > 0 ? EV / AC : 0;
            var SPI = PV > 0 ? EV / PV : 0;
            var CV = EV - AC;
            var SV = EV - PV;
            
            // Estimate at Completion (EAC)
            var EAC = CPI > 0 ? project.Budget.Value / CPI : project.Budget.Value;
            
            // Determine health status
            var health = "Good";
            if (CPI < 0.8m || SPI < 0.8m)
                health = "Critical";
            else if (CPI < 0.9m || SPI < 0.9m)
                health = "Warning";
            
            return new EarnedValueDto
            {
                ProjectId = projectId,
                ProjectName = project.ProjectName,
                PlannedValue = PV,
                EarnedValue = EV,
                ActualCost = AC,
                CPI = CPI,
                SPI = SPI,
                CostVariance = CV,
                ScheduleVariance = SV,
                EstimateAtCompletion = EAC,
                Health = health
            };
        }
        
        public async Task<List<EarnedValueDto>> GetPortfolioEarnedValueAsync(IEnumerable<int>? projectIds = null)
        {
            var projects = (await _unitOfWork.Projects.GetAllAsync())
                .Where(p => p.Status == "Active" || p.Status == "InProgress")
                .ToList();
            
            // Proje ID filtrelemesi (rol bazlı)
            if (projectIds != null && projectIds.Any())
            {
                projects = projects.Where(p => projectIds.Contains(p.ProjectId)).ToList();
            }
            
            var results = new List<EarnedValueDto>();
            foreach (var project in projects)
            {
                try
                {
                    var evm = await GetEarnedValueAnalysisAsync(project.ProjectId);
                    results.Add(evm);
                }
                catch
                {
                    // Skip projects without budget
                    continue;
                }
            }
            
            return results;
        }
        
        private async Task<decimal> CalculateActualCostAsync(int projectId)
        {
            var timeEntries = (await _unitOfWork.TimeEntries
                .FindAsync(te => te.Task.ProjectId == projectId))
                .ToList();
            
            decimal totalCost = 0;
            foreach (var entry in timeEntries)
            {
                var user = await _unitOfWork.Users.GetByIdAsync(entry.UserId);
                var hourlyCost = user?.HourlyCost ?? 50m; // Default $50/hour
                totalCost += entry.HoursSpent * hourlyCost;
            }
            
            return totalCost;
        }
        
        #endregion
        
        #region Velocity Tracking
        
        public async Task<VelocityDto> GetTeamVelocityAsync(int teamId, int numberOfWeeks = 12)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
            if (team == null)
                throw new ArgumentException($"Team {teamId} not found");
            
            var endDate = DateTime.Today;
            var startDate = endDate.AddDays(-7 * numberOfWeeks);
            
            var completedTasks = (await _unitOfWork.Tasks.FindAsync(t =>
                t.Project.TeamId == teamId &&
                t.Status == TaskStatus.Completed &&
                t.CompletedDate.HasValue &&
                t.CompletedDate.Value >= startDate &&
                t.CompletedDate.Value <= endDate))
                .ToList();
            
            var weeklyData = completedTasks
                .GroupBy(t => GetWeekNumber(t.CompletedDate.Value))
                .Select(g => new VelocityDataPoint
                {
                    WeekNumber = g.Key,
                    WeekStartDate = GetWeekStartDate(g.Key, g.First().CompletedDate.Value.Year),
                    WeekEndDate = GetWeekStartDate(g.Key, g.First().CompletedDate.Value.Year).AddDays(6),
                    CompletedHours = g.Sum(t => t.ActualHours ?? t.EstimatedHours ?? 0),
                    CompletedTasksCount = g.Count()
                })
                .OrderBy(v => v.WeekNumber)
                .ToList();
            
            var avgVelocity = weeklyData.Any() ? weeklyData.Average(v => v.CompletedHours) : 0;
            var minVelocity = weeklyData.Any() ? weeklyData.Min(v => v.CompletedHours) : 0;
            var maxVelocity = weeklyData.Any() ? weeklyData.Max(v => v.CompletedHours) : 0;
            var trend = CalculateTrend(weeklyData, avgVelocity);
            
            return new VelocityDto
            {
                TeamId = teamId,
                TeamName = team.TeamName,
                WeeklyVelocity = weeklyData,
                AverageVelocity = avgVelocity,
                MinVelocity = minVelocity,
                MaxVelocity = maxVelocity,
                Trend = trend
            };
        }
        
        public async Task<List<VelocityDto>> GetAllTeamsVelocityAsync(int numberOfWeeks = 12)
        {
            var teams = (await _unitOfWork.Teams.GetAllAsync())
                .Where(t => t.IsActive)
                .ToList();
            
            var results = new List<VelocityDto>();
            foreach (var team in teams)
            {
                var velocity = await GetTeamVelocityAsync(team.TeamId, numberOfWeeks);
                results.Add(velocity);
            }
            
            return results;
        }
        
        private int GetWeekNumber(DateTime date)
        {
            var ci = System.Globalization.CultureInfo.CurrentCulture;
            return ci.Calendar.GetWeekOfYear(date, 
                System.Globalization.CalendarWeekRule.FirstFourDayWeek, 
                DayOfWeek.Monday);
        }
        
        private DateTime GetWeekStartDate(int weekNumber, int year)
        {
            var jan1 = new DateTime(year, 1, 1);
            var daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            var firstMonday = jan1.AddDays(daysOffset);
            return firstMonday.AddDays((weekNumber - 1) * 7);
        }
        
        private string CalculateTrend(List<VelocityDataPoint> data, decimal average)
        {
            if (data.Count < 3) return "Stable";
            
            var lastThree = data.TakeLast(3).ToList();
            var lastThreeAvg = lastThree.Average(v => v.CompletedHours);
            
            if (lastThreeAvg > average * 1.1m) return "Increasing";
            if (lastThreeAvg < average * 0.9m) return "Decreasing";
            return "Stable";
        }
        
        #endregion
        
        #region Financial Analytics
        
        public async Task<FinancialOverviewDto> GetFinancialOverviewAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null)
        {
            var projects = (await _unitOfWork.Projects.GetAllAsync()).ToList();
            
            // Proje ID filtrelemesi (rol bazlı)
            if (projectIds != null && projectIds.Any())
            {
                projects = projects.Where(p => projectIds.Contains(p.ProjectId)).ToList();
            }
            
            // NOT: Projeler tarih filtresine göre filtrelenmez
            // Tarih filtresi sadece time entries (aktiviteler) için geçerlidir
            
            var totalBudget = projects.Sum(p => p.Budget ?? 0);
            
            // Time entries'i al ve filtrele
            var allTimeEntries = (await _unitOfWork.TimeEntries.GetAllAsync()).ToList();
            
            // Proje ID filtrelemesi için time entries
            if (projectIds != null && projectIds.Any())
            {
                allTimeEntries = allTimeEntries.Where(te => projectIds.Contains(te.Task.ProjectId)).ToList();
            }
            
            // Tarih filtrelemesi - o tarih aralığındaki çalışma aktiviteleri
            if (startDate.HasValue)
                allTimeEntries = allTimeEntries.Where(te => te.WorkDate >= startDate.Value).ToList();
            if (endDate.HasValue)
                allTimeEntries = allTimeEntries.Where(te => te.WorkDate <= endDate.Value).ToList();
            
            // Filtrelenmiş time entries üzerinden maliyet hesapla
            decimal totalActualCost = 0m;
            foreach (var entry in allTimeEntries)
            {
                var user = await _unitOfWork.Users.GetByIdAsync(entry.UserId);
                var hourlyCost = user?.HourlyCost ?? 50m;
                totalActualCost += entry.HoursSpent * hourlyCost;
            }
            
            var billableHours = allTimeEntries.Where(te => te.IsBillable).Sum(te => te.HoursSpent);
            var nonBillableHours = allTimeEntries.Where(te => !te.IsBillable).Sum(te => te.HoursSpent);
            var totalHours = billableHours + nonBillableHours;
            var avgHourlyCost = totalHours > 0 ? totalActualCost / totalHours : 0;
            
            return new FinancialOverviewDto
            {
                TotalPlannedBudget = totalBudget,
                TotalActualCost = totalActualCost,
                RemainingBudget = totalBudget - totalActualCost,
                BudgetUtilizationPercentage = totalBudget > 0 ? (totalActualCost / totalBudget) * 100 : 0,
                TotalBillableHours = billableHours,
                TotalNonBillableHours = nonBillableHours,
                AverageHourlyCost = avgHourlyCost,
                StartDate = startDate,
                EndDate = endDate
            };
        }
        
        public async Task<CostBreakdownDto> GetCostBreakdownByProjectAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null)
                throw new ArgumentException($"Project {projectId} not found");
            
            var timeEntries = (await _unitOfWork.TimeEntries
                .FindAsync(te => te.Task.ProjectId == projectId))
                .ToList();
            
            var costByUser = new Dictionary<string, decimal>();
            var costByTask = new Dictionary<string, decimal>();
            var costByMonth = new Dictionary<string, decimal>();
            decimal billableCost = 0;
            decimal nonBillableCost = 0;
            
            foreach (var entry in timeEntries)
            {
                var user = await _unitOfWork.Users.GetByIdAsync(entry.UserId);
                var task = await _unitOfWork.Tasks.GetByIdAsync(entry.TaskId);
                var cost = entry.HoursSpent * (user?.HourlyCost ?? 50m);
                
                // By user
                var userName = user?.FullName ?? "Unknown";
                if (!costByUser.ContainsKey(userName))
                    costByUser[userName] = 0;
                costByUser[userName] += cost;
                
                // By task
                var taskName = task?.TaskName ?? "Unknown";
                if (!costByTask.ContainsKey(taskName))
                    costByTask[taskName] = 0;
                costByTask[taskName] += cost;
                
                // By month
                var monthKey = entry.WorkDate.ToString("yyyy-MM");
                if (!costByMonth.ContainsKey(monthKey))
                    costByMonth[monthKey] = 0;
                costByMonth[monthKey] += cost;
                
                // Billable vs Non-billable
                if (entry.IsBillable)
                    billableCost += cost;
                else
                    nonBillableCost += cost;
            }
            
            return new CostBreakdownDto
            {
                EntityId = projectId,
                EntityName = project.ProjectName,
                BreakdownType = "Project",
                TotalCost = billableCost + nonBillableCost,
                CostByUser = costByUser,
                CostByTask = costByTask,
                CostByMonth = costByMonth,
                BillableCost = billableCost,
                NonBillableCost = nonBillableCost
            };
        }
        
        public async Task<CostBreakdownDto> GetCostBreakdownByTeamAsync(int teamId)
        {
            var team = await _unitOfWork.Teams.GetByIdAsync(teamId);
            if (team == null)
                throw new ArgumentException($"Team {teamId} not found");
            
            var projects = (await _unitOfWork.Projects.FindAsync(p => p.TeamId == teamId)).ToList();
            var projectIds = projects.Select(p => p.ProjectId).ToList();
            
            var timeEntries = (await _unitOfWork.TimeEntries.GetAllAsync())
                .Where(te => projectIds.Contains(te.Task.ProjectId))
                .ToList();
            
            decimal totalCost = 0;
            var costByUser = new Dictionary<string, decimal>();
            
            foreach (var entry in timeEntries)
            {
                var user = await _unitOfWork.Users.GetByIdAsync(entry.UserId);
                var cost = entry.HoursSpent * (user?.HourlyCost ?? 50m);
                totalCost += cost;
                
                var userName = user?.FullName ?? "Unknown";
                if (!costByUser.ContainsKey(userName))
                    costByUser[userName] = 0;
                costByUser[userName] += cost;
            }
            
            return new CostBreakdownDto
            {
                EntityId = teamId,
                EntityName = team.TeamName,
                BreakdownType = "Team",
                TotalCost = totalCost,
                CostByUser = costByUser
            };
        }
        
        #endregion
        
        #region Background Jobs
        
        public async Task<int> CreateDailySnapshotsAsync()
        {
            var activeProjects = (await _unitOfWork.Projects.GetAllAsync())
                .Where(p => p.Status == "Active" || p.Status == "InProgress")
                .ToList();
            
            var snapshotsCreated = 0;
            var today = DateTime.Today;
            
            foreach (var project in activeProjects)
            {
                // Check if snapshot already exists for today
                var existingSnapshot = (await _unitOfWork.ProjectSnapshots
                    .FindAsync(s => s.ProjectId == project.ProjectId && s.SnapshotDate == today))
                    .FirstOrDefault();
                
                if (existingSnapshot != null)
                    continue; // Skip if already exists
                
                var tasks = (await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == project.ProjectId)).ToList();
                
                var openTasksCount = tasks.Count(t => t.Status != TaskStatus.Completed);
                var completedTasksCount = tasks.Count(t => t.Status == TaskStatus.Completed);
                var remainingHours = tasks.Where(t => t.Status != TaskStatus.Completed)
                    .Sum(t => t.EstimatedHours ?? 0);
                var initialHours = project.TotalPlannedHours ?? tasks.Sum(t => t.EstimatedHours ?? 0);
                var idealRemaining = CalculateIdealRemaining(today, project.StartDate, project.EndDate ?? DateTime.Today.AddDays(30), initialHours);
                
                var actualCost = await CalculateActualCostAsync(project.ProjectId);
                
                // Create snapshot
                var snapshot = new Core.Entities.ProjectSnapshot
                {
                    ProjectId = project.ProjectId,
                    SnapshotDate = today,
                    OpenTasksCount = openTasksCount,
                    CompletedTasksCount = completedTasksCount,
                    RemainingHours = remainingHours,
                    IdealRemainingHours = idealRemaining,
                    BurnedBudget = actualCost,
                    PlannedValue = 0, // Will calculate in EVM
                    EarnedValue = 0,  // Will calculate in EVM
                    CreatedAt = DateTime.Now
                };
                
                await _unitOfWork.ProjectSnapshots.AddAsync(snapshot);
                snapshotsCreated++;
            }
            
            await _unitOfWork.SaveChangesAsync();
            return snapshotsCreated;
        }
        
        public async Task RecalculateProjectMetricsAsync(int projectId)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(projectId);
            if (project == null) return;
            
            // Recalculate ActualCost
            project.ActualCost = await CalculateActualCostAsync(projectId);
            
            // Recalculate TotalPlannedHours if not set
            if (!project.TotalPlannedHours.HasValue)
            {
                var tasks = (await _unitOfWork.Tasks.FindAsync(t => t.ProjectId == projectId)).ToList();
                project.TotalPlannedHours = tasks.Sum(t => t.EstimatedHours ?? 0);
            }
            
            await _unitOfWork.SaveChangesAsync();
        }
        
        #endregion
    }
}
