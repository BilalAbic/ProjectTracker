using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTracker.Business.Interfaces;
using ProjectTracker.Business.Mappings;
using ProjectTracker.Business.Services;
using ProjectTracker.Business.Validators;
using ProjectTracker.Core.Interfaces;
using ProjectTracker.Data;
using ProjectTracker.Data.Context;
using FluentValidation;
using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.Services;


namespace ProjectTracker.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Windows Forms initialization
            ApplicationConfiguration.Initialize();

            // Setup Dependency Injection
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Veritabanını otomatik oluştur (yoksa)
            using (var scope = ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            // Run Login Form
            var loginForm = ServiceProvider.GetRequiredService<Forms.Login.FrmLogin>();
            Application.Run(loginForm);

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // ============================================
            // CONFIGURATION
            // ============================================
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            // ============================================
            // DATABASE CONTEXT
            // ============================================
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
                    .UseLazyLoadingProxies(), // Enable lazy loading
                ServiceLifetime.Transient);

            // ============================================
            // REPOSITORIES & UNIT OF WORK
            // ============================================
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // ============================================
            // AUTOMAPPER
            // ============================================
            services.AddAutoMapper(typeof(MappingProfile));

            // ============================================
            // VALIDATORS
            // ============================================
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();

            // ============================================
            // SERVICES
            // ============================================
            services.AddSingleton<ICurrentUserService, Helpers.CurrentUserService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IInvitationService, InvitationService>();
            services.AddTransient<IReportService, ProjectTracker.Business.Services.ReportService>(); 
            services.AddTransient<IAdvancedReportService, AdvancedReportService>();
            services.AddTransient<IAuditLogService, AuditLogService>();
            services.AddTransient<IEmailService, EmailService>();

            // ============================================
            // GITHUB INTEGRATION SERVICES
            // ============================================
            services.AddTransient<ITokenPoolService, TokenPoolService>();
            services.AddTransient<ITaskMatchingService, TaskMatchingService>();
            services.AddTransient<IGitHubSyncService, GitHubSyncService>();
            services.AddTransient<IGitHubAnalyticsService, GitHubAnalyticsService>();

            // ============================================
            // BACKGROUND SERVICES 
            // ============================================
            services.AddHostedService<Business.BackgroundServices.SnapshotBackgroundService>();

            // ============================================
            // FORMS
            // ============================================
            services.AddTransient<Forms.Login.FrmLogin>();
            services.AddTransient<Forms.Login.FrmRegister>();
            services.AddTransient<Forms.Login.FrmPendingWaitlist>();
            services.AddTransient<Forms.Dashboard.FrmDashboard>();
            services.AddTransient<Forms.Dashboard.Content.DashboardContent>();
            services.AddTransient<Forms.Dashboard.Content.ProjectsContent>();
            services.AddTransient<Forms.Dashboard.Content.TasksContent>();
            services.AddTransient<Forms.Dashboard.Content.TaskDetailControl>();
            services.AddTransient<Forms.Dashboard.Content.TeamsContent>();
            services.AddTransient<Forms.Dashboard.Content.TeamDetailControl>();
            services.AddTransient<Forms.Dashboard.Content.InvitationsContent>();
            services.AddTransient<Forms.Dashboard.Content.MyInvitationsContent>();
            services.AddTransient<Forms.Dashboard.Content.TeamMembersContent>();
            services.AddTransient<Forms.Dashboard.Content.ReportsContent>();
            services.AddTransient<Forms.Dashboard.Content.UserSettingsContent>();
            services.AddTransient<Forms.Dashboard.Content.GitHubContent>();
        }
    }
}