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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();

            // ============================================
            // FORMS
            // ============================================
            services.AddTransient<Forms.Login.FrmLogin>();
            services.AddTransient<Forms.Dashboard.FrmDashboard>();
            services.AddTransient<Forms.Dashboard.Content.DashboardContent>();
            services.AddTransient<Forms.Dashboard.Content.ProjectsContent>();
            services.AddTransient<Forms.Dashboard.Content.TasksContent>();
            services.AddTransient<Forms.Dashboard.Content.TaskDetailControl>();
        }
    }
}