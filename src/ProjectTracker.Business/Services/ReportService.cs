using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.DTOs.Statistics;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Core.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp.text;
using iTextSharp.text.pdf;

// Alias to avoid ambiguity between System.Threading.Tasks.Task and ProjectTracker.Core.Entities.Task
using CoreTask = ProjectTracker.Core.Entities.Task;
using CoreTaskStatus = ProjectTracker.Core.Enums.TaskStatus;

namespace ProjectTracker.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvancedReportService _advancedReportService;

        public ReportService(IUnitOfWork unitOfWork, IAdvancedReportService advancedReportService)
        {
            _unitOfWork = unitOfWork;
            _advancedReportService = advancedReportService;
        }

        public async Task<ProjectStatisticsDto> GetProjectStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null)
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();

            // Proje ID filtrelemesi (rol bazlı)
            if (projectIds != null && projectIds.Any())
            {
                projects = projects.Where(p => projectIds.Contains(p.ProjectId));
            }

            // NOT: Proje istatistikleri için tarih filtresi uygulanmaz
            // Tarih filtresi sadece task aktiviteleri için geçerlidir
            // Projeler her zaman mevcut durumlarıyla gösterilir

            var projectList = projects.ToList();
            var total = projectList.Count;
            var active = projectList.Count(p => p.Status == "Active");
            var completed = projectList.Count(p => p.Status == "Completed");
            var onHold = projectList.Count(p => p.Status == "OnHold");
            var cancelled = projectList.Count(p => p.Status == "Cancelled");

            double avgCompletion = 0;
            if (projectList.Any())
                avgCompletion = (double)projectList.Average(p => p.CompletionPercentage);

            return new ProjectStatisticsDto
            {
                TotalProjects = total,
                ActiveProjects = active,
                CompletedProjects = completed,
                OnHoldProjects = onHold,
                CancelledProjects = cancelled,
                AverageCompletionRate = avgCompletion
            };
        }

        public async Task<TaskStatisticsDto> GetTaskStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null, IEnumerable<int>? projectIds = null)
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();

            // Proje ID filtrelemesi (rol bazlı)
            if (projectIds != null && projectIds.Any())
            {
                tasks = tasks.Where(t => projectIds.Contains(t.ProjectId));
            }

            // Tarih filtrelemesi - o tarih aralığında AKTİVİTE olan taskler
            // Aktivite: Task oluşturulma veya tamamlanma
            if (startDate.HasValue || endDate.HasValue)
            {
                var start = startDate ?? DateTime.MinValue;
                var end = endDate ?? DateTime.MaxValue;
                
                tasks = tasks.Where(t => 
                    // Task bu tarih aralığında oluşturulmuş
                    (t.CreatedAt >= start && t.CreatedAt <= end) ||
                    // Task bu tarih aralığında tamamlanmış
                    (t.CompletedDate.HasValue && t.CompletedDate.Value >= start && t.CompletedDate.Value <= end)
                );
            }

            var taskList = tasks.ToList();
            var stats = new TaskStatisticsDto
            {
                TotalTasks = taskList.Count,
                CompletedTasks = taskList.Count(t => t.Status == CoreTaskStatus.Completed),
                InProgressTasks = taskList.Count(t => t.Status == CoreTaskStatus.InProgress),
                TodoTasks = taskList.Count(t => t.Status == CoreTaskStatus.Pending),
                OverdueTasks = taskList.Count(t => t.DueDate < DateTime.Now && t.Status != CoreTaskStatus.Completed),
                TasksByPriority = taskList.GroupBy(t => t.Priority)
                                       .ToDictionary(g => g.Key, g => g.Count())
            };

            return stats;
        }

        public async Task<IEnumerable<TrendDataDto>> GetCompletionTrendAsync(int days = 30, IEnumerable<int>? projectIds = null)
        {
            var cutoff = DateTime.Now.AddDays(-days);
            var tasks = await _unitOfWork.Tasks.FindAsync(t => (t.CreatedAt >= cutoff) || (t.CompletedDate.HasValue && t.CompletedDate >= cutoff));

            // Proje ID filtrelemesi (rol bazlı)
            if (projectIds != null && projectIds.Any())
            {
                tasks = tasks.Where(t => projectIds.Contains(t.ProjectId));
            }

            var taskList = tasks.ToList();
            var trends = new List<TrendDataDto>();
            for (int i = 0; i < days; i++)
            {
                var date = DateTime.Now.Date.AddDays(-i);
                trends.Add(new TrendDataDto
                {
                    Date = date,
                    CreatedTasks = taskList.Count(t => t.CreatedAt.Date == date),
                    CompletedTasks = taskList.Count(t => t.CompletedDate.HasValue && t.CompletedDate.Value.Date == date)
                });
            }
            
            return trends.OrderBy(t => t.Date);
        }

        public async Task<byte[]> ExportReportToExcelAsync()
        {
            var projectStats = await GetProjectStatisticsAsync();
            var taskStats = await GetTaskStatisticsAsync();
            var projects = await _unitOfWork.Projects.GetAllAsync();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var ws1 = package.Workbook.Worksheets.Add("Project Statistics");
                ws1.Cells["A1"].Value = "Metric";
                ws1.Cells["B1"].Value = "Value";
                ws1.Cells["A1:B1"].Style.Font.Bold = true;
                ws1.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws1.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(91, 141, 239));
                ws1.Cells["A1:B1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                ws1.Cells["A2"].Value = "Total Projects"; ws1.Cells["B2"].Value = projectStats.TotalProjects;
                ws1.Cells["A3"].Value = "Active Projects"; ws1.Cells["B3"].Value = projectStats.ActiveProjects;
                ws1.Cells["A4"].Value = "Completed Projects"; ws1.Cells["B4"].Value = projectStats.CompletedProjects;
                ws1.Cells["A5"].Value = "On Hold Projects"; ws1.Cells["B5"].Value = projectStats.OnHoldProjects;
                ws1.Cells["A6"].Value = "Cancelled Projects"; ws1.Cells["B6"].Value = projectStats.CancelledProjects;
                ws1.Cells["A7"].Value = "Avg Completion Rate"; ws1.Cells["B7"].Value = projectStats.AverageCompletionRate / 100;
                ws1.Cells["B7"].Style.Numberformat.Format = "0.00%";
                ws1.Cells[ws1.Dimension.Address].AutoFitColumns();

                var ws2 = package.Workbook.Worksheets.Add("Task Statistics");
                ws2.Cells["A1"].Value = "Metric"; ws2.Cells["B1"].Value = "Value";
                ws2.Cells["A1:B1"].Style.Font.Bold = true;
                ws2.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws2.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(16, 185, 129));
                ws2.Cells["A1:B1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                ws2.Cells["A2"].Value = "Total Tasks"; ws2.Cells["B2"].Value = taskStats.TotalTasks;
                ws2.Cells["A3"].Value = "Completed Tasks"; ws2.Cells["B3"].Value = taskStats.CompletedTasks;
                ws2.Cells["A4"].Value = "In Progress Tasks"; ws2.Cells["B4"].Value = taskStats.InProgressTasks;
                ws2.Cells["A5"].Value = "To Do Tasks"; ws2.Cells["B5"].Value = taskStats.TodoTasks;
                ws2.Cells["A6"].Value = "Overdue Tasks"; ws2.Cells["B6"].Value = taskStats.OverdueTasks;
                ws2.Cells[ws2.Dimension.Address].AutoFitColumns();

                var ws3 = package.Workbook.Worksheets.Add("Tasks by Priority");
                ws3.Cells["A1"].Value = "Priority"; ws3.Cells["B1"].Value = "Count";
                ws3.Cells["A1:B1"].Style.Font.Bold = true;
                ws3.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                ws3.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(251, 176, 52));
                ws3.Cells["A1:B1"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                int row = 2;
                foreach (var kvp in taskStats.TasksByPriority.OrderByDescending(x => (int)x.Key))
                {
                    ws3.Cells[$"A{row}"].Value = kvp.Key.ToString();
                    ws3.Cells[$"B{row}"].Value = kvp.Value;
                    row++;
                }
                ws3.Cells[ws3.Dimension.Address].AutoFitColumns();

                // Advanced Analytics
                try
                {
                    // Risk Analysis
                    var ws4 = package.Workbook.Worksheets.Add("Risk Analysis");
                    ws4.Cells["A1"].Value = "Project Name"; ws4.Cells["B1"].Value = "Completion %";
                    ws4.Cells["C1"].Value = "Risk Score"; ws4.Cells["D1"].Value = "Risk Level";
                    ws4.Cells["E1"].Value = "Risk Factors"; ws4.Cells["F1"].Value = "Recommendations";
                    ws4.Cells["A1:F1"].Style.Font.Bold = true;
                    ws4.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws4.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(239, 68, 68));
                    ws4.Cells["A1:F1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                    var projectsWithRisk = projects.Where(p => p.RiskScore.HasValue).OrderByDescending(p => p.RiskScore).ToList();
                    int riskRow = 2;
                    foreach (var project in projectsWithRisk)
                    {
                        ws4.Cells[$"A{riskRow}"].Value = project.ProjectName;
                        ws4.Cells[$"B{riskRow}"].Value = (double)project.CompletionPercentage / 100;
                        ws4.Cells[$"B{riskRow}"].Style.Numberformat.Format = "0.00%";
                        ws4.Cells[$"C{riskRow}"].Value = (double)project.RiskScore.Value;

                        string riskLevel = project.RiskScore < 30 ? "Low" : project.RiskScore < 70 ? "Medium" : "High";
                        var cellColor = project.RiskScore < 30 ? System.Drawing.Color.FromArgb(16, 185, 129) : 
                                        project.RiskScore < 70 ? System.Drawing.Color.FromArgb(251, 176, 52) : 
                                                                 System.Drawing.Color.FromArgb(239, 68, 68);

                        ws4.Cells[$"D{riskRow}"].Value = riskLevel;
                        ws4.Cells[$"D{riskRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws4.Cells[$"D{riskRow}"].Style.Fill.BackgroundColor.SetColor(cellColor);
                        ws4.Cells[$"D{riskRow}"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                        var projectRisks = await _unitOfWork.ProjectRisks.FindAsync(r => r.ProjectId == project.ProjectId);
                        var latestRisk = projectRisks.OrderByDescending(r => r.AnalyzedAt).FirstOrDefault();
                        ws4.Cells[$"E{riskRow}"].Value = latestRisk?.RiskFactors ?? "N/A";
                        ws4.Cells[$"F{riskRow}"].Value = latestRisk?.Recommendations ?? "Regular monitoring";
                        riskRow++;
                    }
                    if(ws4.Dimension != null) ws4.Cells[ws4.Dimension.Address].AutoFitColumns();

                    // EVM Performance
                    var ws5 = package.Workbook.Worksheets.Add("EVM Performance");
                    ws5.Cells["A1"].Value = "Project Name"; ws5.Cells["B1"].Value = "CPI";
                    ws5.Cells["C1"].Value = "SPI"; ws5.Cells["D1"].Value = "Status";
                    ws5.Cells["E1"].Value = "Budget Var"; ws5.Cells["F1"].Value = "Schedule Var";
                    ws5.Cells["A1:F1"].Style.Font.Bold = true;
                    ws5.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws5.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(99, 102, 241));
                    ws5.Cells["A1:F1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                    var evmList = await _advancedReportService.GetPortfolioEarnedValueAsync();
                    int evmRow = 2;
                    foreach (var pEvm in evmList.Take(20))
                    {
                        ws5.Cells[$"A{evmRow}"].Value = pEvm.ProjectName;
                        ws5.Cells[$"B{evmRow}"].Value = (double)pEvm.CPI;
                        ws5.Cells[$"B{evmRow}"].Style.Numberformat.Format = "0.00";
                        ws5.Cells[$"C{evmRow}"].Value = (double)pEvm.SPI;
                        ws5.Cells[$"C{evmRow}"].Style.Numberformat.Format = "0.00";

                        string status = pEvm.Health;
                        var statusColor = status == "Good" ? System.Drawing.Color.Green : status == "Warning" ? System.Drawing.Color.Orange : System.Drawing.Color.Red;

                        ws5.Cells[$"D{evmRow}"].Value = status;
                        ws5.Cells[$"D{evmRow}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws5.Cells[$"D{evmRow}"].Style.Fill.BackgroundColor.SetColor(statusColor);
                        ws5.Cells[$"D{evmRow}"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                        ws5.Cells[$"E{evmRow}"].Value = (double)pEvm.CostVariance; 
                        ws5.Cells[$"E{evmRow}"].Style.Numberformat.Format = "$#,##0.00";
                        ws5.Cells[$"F{evmRow}"].Value = (double)pEvm.ScheduleVariance;
                        ws5.Cells[$"F{evmRow}"].Style.Numberformat.Format = "$#,##0.00";
                        evmRow++;
                    }
                    if(ws5.Dimension != null) ws5.Cells[ws5.Dimension.Address].AutoFitColumns();

                    // Velocity
                    var ws6 = package.Workbook.Worksheets.Add("Velocity Trends");
                    ws6.Cells["A1"].Value = "Week"; ws6.Cells["B1"].Value = "Hours"; ws6.Cells["C1"].Value = "Avg"; ws6.Cells["D1"].Value = "Trend";
                    ws6.Cells["A1:D1"].Style.Font.Bold = true;
                    ws6.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws6.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Blue);
                    ws6.Cells["A1:D1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                    var velocityData = await _advancedReportService.GetTeamVelocityAsync(1, 8);
                    int vRow = 2;
                    foreach(var w in velocityData.WeeklyVelocity.OrderBy(x => x.WeekNumber))
                    {
                        ws6.Cells[$"A{vRow}"].Value = w.WeekNumber;
                        ws6.Cells[$"B{vRow}"].Value = (double)w.CompletedHours;
                        ws6.Cells[$"C{vRow}"].Value = (double)velocityData.AverageVelocity;
                        string trend = w.CompletedHours > velocityData.AverageVelocity ? "Up" : "Down";
                        ws6.Cells[$"D{vRow}"].Value = trend;
                        vRow++;
                    }
                    if(ws6.Dimension != null) ws6.Cells[ws6.Dimension.Address].AutoFitColumns();

                    // Burndown (for active projects with snapshots)
                    var ws7 = package.Workbook.Worksheets.Add("Burndown Data");
                    ws7.Cells["A1"].Value = "Project"; ws7.Cells["B1"].Value = "Date"; 
                    ws7.Cells["C1"].Value = "Ideal"; ws7.Cells["D1"].Value = "Actual"; ws7.Cells["E1"].Value = "Variance";
                     ws7.Cells["A1:E1"].Style.Font.Bold = true;
                    ws7.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws7.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Purple);
                     ws7.Cells["A1:E1"].Style.Font.Color.SetColor(System.Drawing.Color.White);

                    var activeProjects = projects.Where(p => p.Status == "Active").Take(3);
                    int bRow = 2;
                    foreach(var ap in activeProjects)
                    {
                        try {
                            var bd = await _advancedReportService.GetProjectBurndownAsync(ap.ProjectId);
                            foreach(var dp in bd.DataPoints.OrderBy(d => d.Date).Take(15))
                            {
                                ws7.Cells[$"A{bRow}"].Value = ap.ProjectName;
                                ws7.Cells[$"B{bRow}"].Value = dp.Date.ToString("MM/dd/yyyy");
                                ws7.Cells[$"C{bRow}"].Value = (double)dp.IdealRemainingHours;
                                ws7.Cells[$"D{bRow}"].Value = (double)dp.ActualRemainingHours;
                                ws7.Cells[$"E{bRow}"].Value = (double)(dp.ActualRemainingHours - dp.IdealRemainingHours);
                                ws7.Cells[$"E{bRow}"].Style.Numberformat.Format = "0.00";
                                bRow++;
                            }
                        } catch {}
                    }
                    if(ws7.Dimension != null) ws7.Cells[ws7.Dimension.Address].AutoFitColumns();

                }
                catch {}
                
                return package.GetAsByteArray();
            }
        }

        public async Task<byte[]> ExportReportToPdfAsync()
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, BaseColor.BLACK);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                var sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.DARK_GRAY);

                document.Add(new Paragraph(new Chunk("Project Tracker Report", titleFont)));
                document.Add(new Paragraph(new Chunk($"Generated: {DateTime.Now}", normalFont)));
                document.Add(new Paragraph(new Chunk("\n", normalFont)));

                var projectStats = await GetProjectStatisticsAsync();
                
                document.Add(new Paragraph(new Chunk("Project Statistics", sectionFont)));
                var table1 = new PdfPTable(2);
                table1.AddCell(new Phrase(new Chunk("Total Projects", headerFont)));
                table1.AddCell(new Phrase(new Chunk(projectStats.TotalProjects.ToString(), normalFont)));
                table1.AddCell(new Phrase(new Chunk("Active Projects", headerFont)));
                table1.AddCell(new Phrase(new Chunk(projectStats.ActiveProjects.ToString(), normalFont)));
                document.Add(table1);

                document.NewPage();
                document.Add(new Paragraph(new Chunk("Advanced Analytics Report", titleFont)));

                try {
                     var evmList = await _advancedReportService.GetPortfolioEarnedValueAsync();
                     var evmTable = new PdfPTable(3);
                     evmTable.WidthPercentage = 100;
                     evmTable.AddCell(new Phrase(new Chunk("Project", headerFont)));
                     evmTable.AddCell(new Phrase(new Chunk("CPI", headerFont)));
                     evmTable.AddCell(new Phrase(new Chunk("SPI", headerFont)));

                     foreach(var item in evmList.Take(10))
                     {
                         evmTable.AddCell(new Phrase(new Chunk(item.ProjectName, normalFont)));
                         evmTable.AddCell(new Phrase(new Chunk(item.CPI.ToString("F2"), normalFont)));
                         evmTable.AddCell(new Phrase(new Chunk(item.SPI.ToString("F2"), normalFont)));
                     }
                     document.Add(evmTable);
                } catch (Exception) {
                    document.Add(new Paragraph(new Chunk("Analytics data unavailable", normalFont)));
                }

                document.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
