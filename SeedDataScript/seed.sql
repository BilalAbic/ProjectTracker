-- ============================================
-- ProjectTracker - Comprehensive Updated Seed Data
-- ============================================
-- Created: 2026-01-01
-- Description: Complete seed data including advanced analytics tables
-- Includes: Users, Teams, Projects, Tasks, TimeEntries, ProjectSnapshots, ProjectRisks
-- ============================================

-- Clean up existing data (optional - use only if tables exist)
 DELETE FROM TimeEntries;
 DELETE FROM ProjectSnapshots;
 DELETE FROM ProjectRisks;
 DELETE FROM TaskComments;
 DELETE FROM Tasks;
 DELETE FROM TeamInvitations;
 DELETE FROM TeamMembers;
 DELETE FROM ProjectTeamMembers;
 DELETE FROM Projects;
 DELETE FROM Teams;
 DELETE FROM Notifications;
 DELETE FROM Users;
 DELETE FROM Roles;

-- ============================================
-- 1. ROLES (System Roles)
-- ============================================
SET IDENTITY_INSERT Roles ON;
INSERT INTO Roles (RoleId, RoleName, Description) VALUES
(1, 'Admin', 'System Administrator with full access'),
(2, 'ProjectManager', 'Can manage projects and teams'),
(3, 'Developer', 'Can work on assigned tasks');
SET IDENTITY_INSERT Roles OFF;

-- ============================================
-- 2. USERS (10 Users: 2 Admins, 3 PMs, 5 Devs)
-- ============================================
SET IDENTITY_INSERT Users ON;
-- Password for all users: "admin123" (BCrypt hashed)
-- Correct Hash: $2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC
INSERT INTO Users (UserId, RoleId, Username, PasswordHash, FullName, Email, IsActive, CreatedAt) VALUES
-- Admins (2)
(1, 1, 'admin', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Admin User', 'admin@projecttracker.com', 1, '2025-01-01'),
(2, 1, 'john.admin', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'John Administrator', 'john.admin@projecttracker.com', 1, '2025-01-02'),
-- Project Managers (3)
(3, 2, 'sarah.pm', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Sarah Johnson', 'sarah.johnson@projecttracker.com', 1, '2025-01-03'),
(4, 2, 'mike.manager', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Mike Williams', 'mike.williams@projecttracker.com', 1, '2025-01-04'),
(5, 2, 'lisa.pm', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Lisa Anderson', 'lisa.anderson@projecttracker.com', 1, '2025-01-05'),
-- Developers (5)
(6, 3, 'david.dev', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'David Brown', 'david.brown@projecttracker.com', 1, '2025-01-06'),
(7, 3, 'emma.dev', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Emma Davis', 'emma.davis@projecttracker.com', 1, '2025-01-07'),
(8, 3, 'alex.dev', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Alex Martinez', 'alex.martinez@projecttracker.com', 1, '2025-01-08'),
(9, 3, 'sophia.dev', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'Sophia Wilson', 'sophia.wilson@projecttracker.com', 1, '2025-01-09'),
(10, 3, 'james.dev', '$2a$11$rBV2/.QxbrR5mCRudV3oD.6KhT/dKLZXQbEJU3BUW8qNZnVlCJWJC', 'James Taylor', 'james.taylor@projecttracker.com', 1, '2025-01-10');
SET IDENTITY_INSERT Users OFF;

-- ============================================
-- 3. TEAMS (4 Teams with different owners)
-- ============================================
SET IDENTITY_INSERT Teams ON;
INSERT INTO Teams (TeamId, TeamName, Description, OwnerId, IsActive, CreatedAt) VALUES
(1, 'Default Team', 'Auto-created default team for existing projects', 1, 1, '2025-01-01'),
(2, 'Frontend Development', 'Team focused on UI/UX and frontend development', 3, 1, '2025-01-15'),
(3, 'Backend & API Team', 'Team handling backend services and APIs', 4, 1, '2025-01-20'),
(4, 'Mobile Development', 'iOS and Android app development team', 5, 1, '2025-02-01');
SET IDENTITY_INSERT Teams OFF;

-- ============================================
-- 4. TEAM MEMBERS (Assign users to teams)
-- ============================================
SET IDENTITY_INSERT TeamMembers ON;
INSERT INTO TeamMembers (TeamMemberId, TeamId, UserId, Role, JoinedAt, IsActive) VALUES
-- Default Team (Admin + some users)
(1, 1, 1, 'Owner', '2025-01-01', 1),
(2, 1, 2, 'Admin', '2025-01-02', 1),
-- Frontend Development Team
(3, 2, 3, 'Owner', '2025-01-15', 1),
(4, 2, 6, 'Developer', '2025-01-16', 1),
(5, 2, 7, 'Developer', '2025-01-16', 1),
(6, 2, 1, 'Admin', '2025-01-15', 1),
-- Backend & API Team
(7, 3, 4, 'Owner', '2025-01-20', 1),
(8, 3, 8, 'Developer', '2025-01-21', 1),
(9, 3, 9, 'Developer', '2025-01-21', 1),
(10, 3, 2, 'Admin', '2025-01-20', 1),
-- Mobile Development Team
(11, 4, 5, 'Owner', '2025-02-01', 1),
(12, 4, 10, 'Developer', '2025-02-02', 1),
(13, 4, 6, 'Developer', '2025-02-03', 1),
(14, 4, 1, 'Admin', '2025-02-01', 1);
SET IDENTITY_INSERT TeamMembers OFF;

-- ============================================
-- 5. PROJECTS (8 Projects with RiskScore)
-- ============================================
SET IDENTITY_INSERT Projects ON;
INSERT INTO Projects (ProjectId, TeamId, CreatedByUserId, ProjectName, Description, StartDate, EndDate, Budget, Status, Priority, CompletionPercentage, RiskScore, TotalPlannedHours, CreatedAt) VALUES
-- Frontend Team Projects
(1, 2, 3, 'E-Commerce Platform', 'Building a modern e-commerce platform with React and Next.js', '2025-10-29', '2026-04-29', 150000.00, 'Active', 3, 35.00, 45.0, 1200, '2025-10-29'),
(2, 2, 3, 'Corporate Website Redesign', 'Complete redesign of company website with modern UI', '2025-11-15', '2026-02-15', 50000.00, 'Active', 2, 60.00, 25.0, 400, '2025-11-15'),
(3, 2, 3, 'Admin Dashboard', 'Internal admin dashboard for management', '2025-12-01', '2026-01-31', 30000.00, 'Active', 1, 15.00, 60.0, 300, '2025-12-01'),
-- Backend Team Projects
(4, 3, 4, 'API Gateway Development', 'Microservices API gateway with authentication', '2025-11-01', '2026-03-01', 80000.00, 'Active', 4, 45.00, 35.0, 800, '2025-11-01'),
(5, 3, 4, 'Database Migration Tool', 'Automated database migration and versioning tool', '2025-12-15', '2026-02-28', 40000.00, 'Active', 2, 20.00, 55.0, 500, '2025-12-15'),
-- Mobile Team Projects
(6, 4, 5, 'Mobile Banking App', 'iOS and Android banking app with biometric auth', '2025-11-29', '2026-03-29', 200000.00, 'Active', 4, 25.00, 70.0, 1500, '2025-11-29'),
(7, 4, 5, 'Fitness Tracker App', 'Cross-platform fitness and health tracking app', '2025-12-20', '2026-04-20', 120000.00, 'Planned', 3, 0.00, 20.0, 1000, '2025-12-20'),
-- Default Team Project
(8, 1, 1, 'Internal CRM System', 'Customer relationship management for internal use', '2026-01-13', '2026-06-29', 80000.00, 'Planned', 2, 0.00, 15.0, 800, '2025-12-29');
SET IDENTITY_INSERT Projects OFF;

-- ============================================
-- 6. PROJECT TEAM MEMBERS
-- ============================================
SET IDENTITY_INSERT ProjectTeamMembers ON;
INSERT INTO ProjectTeamMembers (TeamMemberId, ProjectId, UserId, ProjectRole, JoinedAt) VALUES
(1, 1, 6, 'Frontend Lead', '2025-10-29'),
(2, 1, 7, 'UI/UX Developer', '2025-10-30'),
(3, 2, 7, 'Lead Developer', '2025-11-15'),
(4, 3, 6, 'Full-stack Developer', '2025-12-01'),
(5, 4, 8, 'Backend Lead', '2025-11-01'),
(6, 4, 9, 'API Developer', '2025-11-02'),
(7, 5, 9, 'Database Engineer', '2025-12-15'),
(8, 6, 10, 'iOS Developer', '2025-11-29'),
(9, 6, 6, 'Android Developer', '2025-11-30'),
(10, 7, 10, 'Mobile Lead', '2025-12-20');
SET IDENTITY_INSERT ProjectTeamMembers OFF;

-- ============================================
-- 7. TASKS (25 Tasks with IsCriticalPath flags)
-- ============================================
SET IDENTITY_INSERT Tasks ON;
INSERT INTO Tasks (TaskId, ProjectId, AssignedUserId, ParentTaskId, TaskName, Description, Priority, Status, EstimatedHours, ActualHours, StartDate, DueDate, CompletedDate, IsCriticalPath, CreatedAt) VALUES
-- E-Commerce Platform Tasks (Project 1)
(1, 1, 6, NULL, 'Design Product Catalog UI', 'Create wireframes and mockups for product listing', 'High', 'Completed', 40, 38, '2025-10-29', '2025-11-29', '2025-12-04', 0, '2025-10-29'),
(2, 1, 7, NULL, 'Implement Shopping Cart', 'Build cart functionality with session management', 'Critical', 'InProgress', 60, 35, '2025-12-19', '2026-01-03', NULL, 1, '2025-12-19'),
(3, 1, 6, NULL, 'Setup Payment Gateway', 'Integrate Stripe for checkout process', 'High', 'Pending', 50, NULL, '2026-01-03', '2026-01-13', NULL, 1, '2025-12-29'),
(4, 1, NULL, NULL, 'Performance Testing', 'Load test for 10k concurrent users', 'Medium', 'Blocked', 30, NULL, '2025-12-29', '2026-01-18', NULL, 0, '2025-12-29'),
-- Corporate Website Tasks (Project 2)
(5, 2, 7, NULL, 'Homepage Redesign', 'Design and implement new homepage layout', 'High', 'Completed', 45, 42, '2025-11-15', '2025-12-01', '2025-12-05', 0, '2025-11-15'),
(6, 2, 7, NULL, 'Contact Form Integration', 'Add contact form with email notifications', 'Medium', 'Completed', 20, 18, '2025-12-05', '2025-12-15', '2025-12-14', 0, '2025-12-05'),
(7, 2, 7, NULL, 'SEO Optimization', 'Implement SEO best practices', 'High', 'InProgress', 30, 15, '2025-12-10', '2026-01-05', NULL, 0, '2025-12-10'),
-- Admin Dashboard Tasks (Project 3)
(8, 3, 6, NULL, 'User Management Module', 'CRUD for user administration', 'Critical', 'InProgress', 50, 25, '2025-12-01', '2025-12-25', NULL, 1, '2025-12-01'),
(9, 3, 6, NULL, 'Analytics Dashboard', 'Real-time analytics and charts', 'High', 'Pending', 60, NULL, '2025-12-20', '2026-01-15', NULL, 1, '2025-12-10'),
-- API Gateway Tasks (Project 4)
(10, 4, 8, NULL, 'Authentication Service', 'JWT-based auth with refresh tokens', 'Critical', 'Completed', 70, 68, '2025-11-01', '2025-11-25', '2025-11-24', 1, '2025-11-01'),
(11, 4, 9, NULL, 'Rate Limiting', 'Implement API rate limiting', 'High', 'InProgress', 40, 20, '2025-11-20', '2025-12-30', NULL, 0, '2025-11-20'),
(12, 4, 8, NULL, 'API Documentation', 'Swagger/OpenAPI documentation', 'Medium', 'Pending', 30, NULL, '2025-12-25', '2026-01-10', NULL, 0, '2025-12-15'),
-- Database Migration Tasks (Project 5)
(13, 5, 9, NULL, 'Migration Script Generator', 'Auto-generate migration scripts from schema', 'High', 'InProgress', 55, 30, '2025-12-15', '2026-01-15', NULL, 0, '2025-12-15'),
(14, 5, 9, NULL, 'Rollback Mechanism', 'Safe rollback for failed migrations', 'Critical', 'Pending', 45, NULL, '2026-01-05', '2026-02-05', NULL, 1, '2025-12-20'),
-- Mobile Banking Tasks (Project 6)
(15, 6, 10, NULL, 'Biometric Authentication', 'Fingerprint and face recognition', 'Critical', 'InProgress', 80, 45, '2025-12-24', '2026-01-08', NULL, 1, '2025-12-24'),
(16, 6, 6, NULL, 'Transaction History UI', 'Design transaction list screen', 'High', 'Pending', 40, NULL, '2026-01-01', '2026-01-10', NULL, 0, '2025-12-29'),
(17, 6, 10, NULL, 'Push Notifications', 'Implement FCM push notifications', 'Medium', 'Pending', 35, NULL, '2026-01-10', '2026-01-25', NULL, 0, '2025-12-29'),
-- Fitness Tracker Tasks (Project 7)
(18, 7, NULL, NULL, 'Requirements Gathering', 'Meet stakeholders for feature requirements', 'High', 'Pending', 20, NULL, '2025-12-20', '2026-01-05', NULL, 0, '2025-12-20'),
(19, 7, NULL, NULL, 'UI/UX Design', 'Design app screens and user flows', 'High', 'Pending', 60, NULL, '2026-01-05', '2026-01-25', NULL, 0, '2025-12-20'),
-- CRM System Tasks (Project 8)
(20, 8, NULL, NULL, 'Requirements Gathering', 'Collect CRM requirements from teams', 'High', 'Pending', 25, NULL, '2026-01-13', '2026-01-18', NULL, 0, '2025-12-29'),
(21, 8, NULL, NULL, 'Database Design', 'Design CRM database schema', 'Critical', 'Pending', 40, NULL, '2026-01-20', '2026-02-10', NULL, 1, '2025-12-29'),
-- Parent-Child Task Example
(22, 1, 6, 2, 'Cart Item Addition', 'Implement add to cart functionality', 'High', 'Completed', 15, 14, '2025-12-19', '2025-12-22', '2025-12-22', 0, '2025-12-19'),
(23, 1, 7, 2, 'Cart Item Removal', 'Implement remove from cart feature', 'High', 'InProgress', 12, 8, '2025-12-23', '2025-12-26', NULL, 0, '2025-12-23'),
(24, 1, 6, 2, 'Cart Quantity Update', 'Allow quantity changes in cart', 'Medium', 'Pending', 10, NULL, '2025-12-26', '2025-12-28', NULL, 0, '2025-12-23'),
(25, 1, 7, 2, 'Cart Persistence', 'Save cart to database for logged users', 'High', 'Pending', 18, NULL, '2025-12-28', '2026-01-02', NULL, 0, '2025-12-23');
SET IDENTITY_INSERT Tasks OFF;

-- ============================================
-- 8. TIME ENTRIES (For cost tracking & EVM @ 50 USD/hour)
-- ============================================
SET IDENTITY_INSERT TimeEntries ON;
INSERT INTO TimeEntries (TimeEntryId, UserId, TaskId, WorkDate, HoursSpent, IsBillable, Description, CreatedAt) VALUES
-- David's work (E-Commerce)
(1, 6, 1, '2025-11-01', 8.0, 1, 'Created wireframes for product catalog', '2025-11-01'),
(2, 6, 1, '2025-11-02', 8.0, 1, 'Mockup designs in Figma', '2025-11-02'),
(3, 6, 1, '2025-11-05', 7.5, 1, 'Final UI revisions', '2025-11-05'),
(4, 6, 1, '2025-11-08', 8.0, 1, 'Component implementation', '2025-11-08'),
(5, 6, 1, '2025-11-15', 6.5, 1, 'Final touches and refactoring', '2025-11-15'),
-- Emma's work (Shopping Cart)
(6, 7, 2, '2025-12-19', 7.0, 1, 'Setup cart state management', '2025-12-19'),
(7, 7, 2, '2025-12-20', 8.0, 1, 'Redux implementation', '2025-12-20'),
(8, 7, 2, '2025-12-21', 6.5, 1, 'Cart reducer and actions', '2025-12-21'),
(9, 7, 2, '2025-12-22', 7.5, 1, 'UI components for cart', '2025-12-22'),
(10, 7, 2, '2025-12-26', 6.0, 1, 'Session management integration', '2025-12-26'),
-- Emma's work (Website)
(11, 7, 5, '2025-11-16', 8.0, 1, 'Homepage layout design', '2025-11-16'),
(12, 7, 5, '2025-11-18', 7.5, 1, 'Responsive design implementation', '2025-11-18'),
(13, 7, 5, '2025-11-22', 8.0, 1, 'Hero section and animations', '2025-11-22'),
(14, 7, 5, '2025-11-28', 7.0, 1, 'Content sections', '2025-11-28'),
(15, 7, 5, '2025-12-02', 6.5, 1, 'Final testing and bug fixes', '2025-12-02'),
(16, 7, 6, '2025-12-06', 7.0, 1, 'Contact form design', '2025-12-06'),
(17, 7, 6, '2025-12-08', 6.0, 1, 'Email notification setup', '2025-12-08'),
(18, 7, 6, '2025-12-12', 5.0, 1, 'Form validation and testing', '2025-12-12'),
(19, 7, 7, '2025-12-11', 7.5, 1, 'SEO meta tags implementation', '2025-12-11'),
(20, 7, 7, '2025-12-15', 7.5, 1, 'Schema markup and sitemap', '2025-12-15'),
-- David's work (Admin Dashboard)
(21, 6, 8, '2025-12-02', 8.0, 1, 'User table schema design', '2025-12-02'),
(22, 6, 8, '2025-12-05', 7.0, 1, 'CRUD API endpoints', '2025-12-05'),
(23, 6, 8, '2025-12-10', 6.5, 1, 'User list UI component', '2025-12-10'),
(24, 6, 8, '2025-12-15', 3.5, 1, 'Edit user modal', '2025-12-15'),
-- Alex's work (API Gateway)
(25, 8, 10, '2025-11-02', 8.0, 1, 'JWT auth research and setup', '2025-11-02'),
(26, 8, 10, '2025-11-05', 8.0, 1, 'Token generation logic', '2025-11-05'),
(27, 8, 10, '2025-11-08', 7.5, 1, 'Refresh token implementation', '2025-11-08'),
(28, 8, 10, '2025-11-12', 8.0, 1, 'Auth middleware', '2025-11-12'),
(29, 8, 10, '2025-11-18', 7.0, 1, 'Testing and security review', '2025-11-18'),
(30, 8, 10, '2025-11-22', 6.5, 1, 'Documentation and final fixes', '2025-11-22'),
-- Sophia's work (API Gateway)
(31, 9, 11, '2025-11-21', 7.0, 1, 'Rate limiting library evaluation', '2025-11-21'),
(32, 9, 11, '2025-11-25', 6.5, 1, 'Implementation with Redis', '2025-11-25'),
(33, 9, 11, '2025-12-01', 6.5, 1, 'Testing different scenarios', '2025-12-01'),
-- Sophia's work (Database Migration)
(34, 9, 13, '2025-12-16', 7.5, 1, 'Migration script generator design', '2025-12-16'),
(35, 9, 13, '2025-12-18', 8.0, 1, 'Schema parsing implementation', '2025-12-18'),
(36, 9, 13, '2025-12-22', 7.0, 1, 'Script generation logic', '2025-12-22'),
(37, 9, 13, '2025-12-27', 7.5, 1, 'Testing with sample schemas', '2025-12-27'),
-- James's work (Mobile Banking)
(38, 10, 15, '2025-12-25', 8.0, 1, 'iOS Face ID integration', '2025-12-25'),
(39, 10, 15, '2025-12-26', 7.5, 1, 'Fingerprint authentication', '2025-12-26'),
(40, 10, 15, '2025-12-28', 8.0, 1, 'Android biometric API', '2025-12-28'),
(41, 10, 15, '2025-12-30', 6.5, 1, 'Cross-platform testing', '2025-12-30'),
(42, 10, 15, '2026-01-01', 7.5, 1, 'Security hardening', '2026-01-01'),
-- Cart sub-tasks
(43, 6, 22, '2025-12-20', 7.0, 1, 'Add to cart button implementation', '2025-12-20'),
(44, 6, 22, '2025-12-21', 7.0, 1, 'Cart state update logic', '2025-12-21'),
(45, 7, 23, '2025-12-24', 5.0, 1, 'Remove from cart functionality', '2025-12-24'),
(46, 7, 23, '2025-12-25', 3.0, 1, 'UI testing', '2025-12-25');
SET IDENTITY_INSERT TimeEntries OFF;

-- ============================================
-- 9. PROJECT SNAPSHOTS (Daily snapshots for Burndown & EVM)
-- ============================================
SET IDENTITY_INSERT ProjectSnapshots ON;
INSERT INTO ProjectSnapshots (SnapshotId, ProjectId, SnapshotDate, OpenTasksCount, CompletedTasksCount, RemainingHours, IdealRemainingHours, BurnedBudget, PlannedValue, EarnedValue, CreatedAt) VALUES
-- E-Commerce Platform (Project 1) - 30 day snapshots
(1, 1, '2025-11-01', 5, 0, 1200.0, 1200.0, 0.0, 0.0, 0.0, '2025-11-01'),
(2, 1, '2025-11-05', 5, 0, 1180.0, 1180.0, 1000.0, 2000.0, 1600.0, '2025-11-05'),
(3, 1, '2025-11-10', 5, 0, 1150.0, 1160.0, 2000.0, 5000.0, 4000.0, '2025-11-10'),
(4, 1, '2025-11-15', 5, 0, 1110.0, 1140.0, 3500.0, 8500.0, 7200.0, '2025-11-15'),
(5, 1, '2025-11-20', 5, 0, 1080.0, 1120.0, 5500.0, 12000.0, 9600.0, '2025-11-20'),
(6, 1, '2025-11-25', 5, 0, 1050.0, 1100.0, 7500.0, 16000.0, 12000.0, '2025-11-25'),
(7, 1, '2025-11-30', 5, 0, 1020.0, 1080.0, 10000.0, 20000.0, 14400.0, '2025-11-30'),
(8, 1, '2025-12-05', 4, 1, 985.0, 1060.0, 12500.0, 25000.0, 17200.0, '2025-12-05'),
(9, 1, '2025-12-10', 4, 1, 950.0, 1040.0, 16000.0, 30000.0, 20000.0, '2025-12-10'),
(10, 1, '2025-12-15', 4, 1, 915.0, 1020.0, 20000.0, 35000.0, 22800.0, '2025-12-15'),
(11, 1, '2025-12-20', 4, 1, 880.0, 1000.0, 25000.0, 40000.0, 25600.0, '2025-12-20'),
(12, 1, '2025-12-25', 4, 1, 845.0, 980.0, 30000.0, 45000.0, 28400.0, '2025-12-25'),
(13, 1, '2025-12-30', 4, 1, 810.0, 960.0, 36000.0, 52000.0, 31200.0, '2025-12-30'),
-- Corporate Website (Project 2) - Snapshots
(14, 2, '2025-11-16', 3, 0, 400.0, 400.0, 0.0, 0.0, 0.0, '2025-11-16'),
(15, 2, '2025-11-20', 3, 0, 380.0, 385.0, 1000.0, 3000.0, 1600.0, '2025-11-20'),
(16, 2, '2025-11-25', 3, 0, 350.0, 370.0, 2500.0, 6000.0, 4000.0, '2025-11-25'),
(17, 2, '2025-12-01', 3, 0, 320.0, 355.0, 4500.0, 9000.0, 6400.0, '2025-12-01'),
(18, 2, '2025-12-05', 2, 1, 285.0, 340.0, 7000.0, 12000.0, 9200.0, '2025-12-05'),
(19, 2, '2025-12-10', 2, 1, 265.0, 325.0, 10000.0, 16000.0, 10800.0, '2025-12-10'),
(20, 2, '2025-12-15', 1, 2, 230.0, 310.0, 13500.0, 21000.0, 13600.0, '2025-12-15'),
(21, 2, '2025-12-20', 1, 2, 215.0, 295.0, 18000.0, 26000.0, 14800.0, '2025-12-20'),
(22, 2, '2025-12-25', 1, 2, 200.0, 280.0, 23000.0, 30000.0, 16000.0, '2025-12-25'),
(23, 2, '2025-12-30', 1, 2, 185.0, 265.0, 28000.0, 35000.0, 17200.0, '2025-12-30'),
-- API Gateway (Project 4) - Snapshots
(24, 4, '2025-11-02', 3, 0, 800.0, 800.0, 0.0, 0.0, 0.0, '2025-11-02'),
(25, 4, '2025-11-08', 3, 0, 760.0, 785.0, 2000.0, 4000.0, 3200.0, '2025-11-08'),
(26, 4, '2025-11-15', 3, 0, 710.0, 770.0, 4500.0, 8000.0, 7200.0, '2025-11-15'),
(27, 4, '2025-11-22', 3, 0, 670.0, 755.0, 8000.0, 13000.0, 10400.0, '2025-11-22'),
(28, 4, '2025-11-28', 2, 1, 620.0, 740.0, 12000.0, 18000.0, 14400.0, '2025-11-28'),
(29, 4, '2025-12-05', 2, 1, 585.0, 725.0, 16500.0, 24000.0, 17200.0, '2025-12-05'),
(30, 4, '2025-12-12', 2, 1, 555.0, 710.0, 22000.0, 29000.0, 19600.0, '2025-12-12'),
(31, 4, '2025-12-20', 2, 1, 535.0, 695.0, 28000.0, 35000.0, 21200.0, '2025-12-20'),
(32, 4, '2025-12-28', 2, 1, 520.0, 680.0, 34000.0, 40000.0, 22400.0, '2025-12-28'),
-- Mobile Banking (Project 6) - Snapshots
(33, 6, '2025-11-30', 3, 0, 1500.0, 1500.0, 0.0, 0.0, 0.0, '2025-11-30'),
(34, 6, '2025-12-05', 3, 0, 1460.0, 1480.0, 2000.0, 5000.0, 3200.0, '2025-12-05'),
(35, 6, '2025-12-10', 3, 0, 1415.0, 1460.0, 4500.0, 10000.0, 6800.0, '2025-12-10'),
(36, 6, '2025-12-15', 3, 0, 1380.0, 1440.0, 7500.0, 16000.0, 9600.0, '2025-12-15'),
(37, 6, '2025-12-20', 3, 0, 1340.0, 1420.0, 11000.0, 23000.0, 12800.0, '2025-12-20'),
(38, 6, '2025-12-25', 3, 0, 1295.0, 1400.0, 15000.0, 31000.0, 16400.0, '2025-12-25'),
(39, 6, '2025-12-30', 3, 0, 1250.0, 1380.0, 20000.0, 40000.0, 20000.0, '2025-12-30'),
-- Admin Dashboard (Project 3) - Snapshots
(40, 3, '2025-12-02', 2, 0, 300.0, 300.0, 0.0, 0.0, 0.0, '2025-12-02'),
(41, 3, '2025-12-07', 2, 0, 285.0, 290.0, 500.0, 1500.0, 1200.0, '2025-12-07'),
(42, 3, '2025-12-12', 2, 0, 270.0, 280.0, 1200.0, 3000.0, 2400.0, '2025-12-12'),
(43, 3, '2025-12-17', 2, 0, 255.0, 270.0, 2000.0, 4500.0, 3600.0, '2025-12-17'),
(44, 3, '2025-12-22', 2, 0, 240.0, 260.0, 3000.0, 6000.0, 4800.0, '2025-12-22'),
(45, 3, '2025-12-27', 2, 0, 225.0, 250.0, 4000.0, 7500.0, 6000.0, '2025-12-27'),
(46, 3, '2026-01-01', 2, 0, 210.0, 240.0, 4500.0, 9000.0, 7200.0, '2026-01-01');
SET IDENTITY_INSERT ProjectSnapshots OFF;

-- ============================================
-- 10. PROJECT RISKS (Risk analysis data)
-- ============================================
SET IDENTITY_INSERT ProjectRisks ON;
INSERT INTO ProjectRisks (RiskId, ProjectId, RiskScore, RiskLevel, RiskFactors, Recommendations, AnalyzedAt) VALUES
(1, 1, 45.0, 'Medium', 'Scope creep detected in cart features. Third-party payment API dependency. High complexity shopping cart logic.', 'Lock down scope for V1. Create fallback payment options. Add comprehensive cart unit tests.', '2025-12-28'),
(2, 2, 25.0, 'Low', 'Design iterations took longer than expected. Minor SEO optimization delays.', 'Maintain current velocity. Focus on SEO completion in next sprint.', '2025-12-27'),
(3, 3, 60.0, 'Medium-High', 'Analytics dashboard complexity higher than estimated. Limited developer availability. Tight deadline approaching.', 'Consider reducing initial feature set. Add developer resources if possible. Plan for post-V1 enhancements.', '2025-12-29'),
(4, 4, 35.0, 'Medium-Low', 'Authentication complexity handled well. Rate limiting integration smooth. Documentation slightly behind.', 'Continue current pace. Prioritize documentation in final sprint. Plan comprehensive testing.', '2025-12-26'),
(5, 5, 55.0, 'Medium', 'Database migration tool has many edge cases. Rollback mechanism critical. Limited testing time.', 'Focus on core use cases first. Extensive testing required. Plan phased rollout for rollback feature.', '2025-12-30'),
(6, 6, 70.0, 'High', 'Biometric authentication complexity across platforms. Banking security requirements stringent. Regulatory compliance needed.', 'Allocate extra testing time. Engage security audit team. Consider extending deadline if needed.', '2025-12-29'),
(7, 7, 20.0, 'Low', 'Project in early planning phase. Clear requirements. Experienced team assigned.', 'Proceed with current plan. Ensure regular stakeholder communication.', '2025-12-28'),
(8, 8, 15.0, 'Low', 'Project not yet started. Clear scope defined. Adequate timeline allocated.', 'Begin requirements phase as planned. No immediate risks identified.', '2025-12-29');
SET IDENTITY_INSERT ProjectRisks OFF;

-- ============================================
-- 11. TEAM INVITATIONS
-- ============================================
SET IDENTITY_INSERT TeamInvitations ON;
INSERT INTO TeamInvitations (InvitationId, TeamId, Email, InvitedByUserId, ProposedRole, Status, Token, SentAt, ExpiresAt, RespondedAt) VALUES
(1, 2, 'newdev1@example.com', 3, 'Developer', 'Pending', NEWID(), '2025-12-25', '2026-01-01', NULL),
(2, 3, 'backend.expert@example.com', 4, 'ProjectManager', 'Pending', NEWID(), '2025-12-26', '2026-01-02', NULL),
(3, 4, 'james.taylor@projecttracker.com', 5, 'Developer', 'Accepted', NEWID(), '2025-02-01', '2025-02-08', '2025-02-02'),
(4, 2, 'declined@example.com', 3, 'Observer', 'Declined', NEWID(), '2025-12-20', '2025-12-27', '2025-12-21'),
(5, 3, 'expired@example.com', 4, 'Developer', 'Pending', NEWID(), '2025-12-10', '2025-12-17', NULL);
SET IDENTITY_INSERT TeamInvitations OFF;

-- ============================================
-- 12. TASK COMMENTS
-- ============================================
SET IDENTITY_INSERT TaskComments ON;
INSERT INTO TaskComments (CommentId, TaskId, UserId, CommentText, CreatedAt) VALUES
(1, 2, 7, 'Working on the cart state management. Redux implementation is 50% complete.', '2025-12-20 10:30:00'),
(2, 2, 3, 'Great progress! Make sure to add unit tests for the cart reducer.', '2025-12-20 14:15:00'),
(3, 8, 6, 'User roles and permissions table design completed. Ready for review.', '2025-12-10 09:00:00'),
(4, 11, 9, 'Found a good rate-limiting library. Testing with different scenarios.', '2025-12-01 11:20:00'),
(5, 15, 10, 'iOS Face ID integration done. Working on Android biometric now.', '2025-12-27 16:45:00'),
(6, 1, 3, 'Excellent work on the UI mockups. Approved for implementation.', '2025-11-10 14:00:00'),
(7, 10, 4, 'Auth service looks solid. Security review scheduled for next week.', '2025-11-18 09:30:00');
SET IDENTITY_INSERT TaskComments OFF;

-- ============================================
-- 13. NOTIFICATIONS
-- ============================================
SET IDENTITY_INSERT Notifications ON;
INSERT INTO Notifications (NotificationId, UserId, Title, Message, Type, IsRead, CreatedAt) VALUES
(1, 6, 'Task Assigned', 'You have been assigned to task: Setup Payment Gateway', 'Info', 0, '2025-12-29 08:00:00'),
(2, 7, 'Task Completed', 'Your task "Cart Item Addition" has been marked as completed', 'Success', 1, '2025-12-22 17:30:00'),
(3, 3, 'Team Invitation', 'newdev1@example.com has been invited to Frontend Development team', 'Info', 0, '2025-12-25 14:00:00'),
(4, 8, 'Project Update', 'API Gateway Development is now 45% complete', 'Info', 1, '2025-12-28 09:00:00'),
(5, 10, 'Task Overdue', 'Task "Biometric Authentication" is approaching deadline', 'Warning', 0, '2025-12-29 07:00:00'),
(6, 6, 'High Risk Alert', 'Admin Dashboard project has elevated risk score of 60', 'Warning', 0, '2025-12-29 08:30:00'),
(7, 4, 'Budget Alert', 'API Gateway project at 45% budget utilization', 'Info', 1, '2025-12-28 10:00:00');
SET IDENTITY_INSERT Notifications OFF;

-- ============================================
-- VERIFICATION QUERIES
-- ============================================
PRINT '📊 =========================================';
PRINT '📊 SEED DATA INSERTION SUMMARY';
PRINT '📊 =========================================';

SELECT 'Users' AS Entity, COUNT(*) AS Count FROM Users
UNION ALL SELECT 'Teams', COUNT(*) FROM Teams
UNION ALL SELECT 'TeamMembers', COUNT(*) FROM TeamMembers
UNION ALL SELECT 'Projects', COUNT(*) FROM Projects
UNION ALL SELECT 'Tasks', COUNT(*) FROM Tasks
UNION ALL SELECT 'TimeEntries', COUNT(*) FROM TimeEntries
UNION ALL SELECT 'ProjectSnapshots', COUNT(*) FROM ProjectSnapshots
UNION ALL SELECT 'ProjectRisks', COUNT(*) FROM ProjectRisks
UNION ALL SELECT 'TeamInvitations', COUNT(*) FROM TeamInvitations
UNION ALL SELECT 'TaskComments', COUNT(*) FROM TaskComments
UNION ALL SELECT 'Notifications', COUNT(*) FROM Notifications;

-- Project status summary with analytics
SELECT 
    P.ProjectName,
    P.Status,
    P.CompletionPercentage AS [Completion %],
    P.RiskScore AS [Risk Score],
    P.Budget,
    COUNT(DISTINCT T.TaskId) AS [Total Tasks],
    COUNT(DISTINCT CASE WHEN T.Status = 'Completed' THEN T.TaskId END) AS [Completed],
    COUNT(DISTINCT CASE WHEN T.IsCriticalPath = 1 THEN T.TaskId END) AS [Critical Path]
FROM Projects P
LEFT JOIN Tasks T ON P.ProjectId = T.ProjectId
GROUP BY P.ProjectId, P.ProjectName, P.Status, P.CompletionPercentage, P.RiskScore, P.Budget
ORDER BY P.ProjectId;

PRINT '=====================================';
PRINT '✅ SEED DATA INSERTED SUCCESSFULLY!';
PRINT '=====================================';
PRINT '📦 Database Contents:';
PRINT '   - 10 Users (2 Admins, 3 PMs, 5 Devs)';
PRINT '   - 4 Teams with 14 members';
PRINT '   - 8 Projects with RiskScore';
PRINT '   - 25 Tasks (with IsCriticalPath flags)';
PRINT '   - 46 Time Entries (for cost tracking)';
PRINT '   - 46 Project Snapshots (for Burndown/EVM)';
PRINT '   - 8 Project Risks (risk analysis data)';
PRINT '   - 5 Team Invitations';
PRINT '   - 7 Task Comments';
PRINT '   - 7 Notifications';
PRINT '=====================================';
PRINT '🚀 Advanced Analytics Ready!';
PRINT '   ✓ Burndown Charts (via ProjectSnapshots)';
PRINT '   ✓ EVM Analysis (PV, EV, AC from snapshots)';
PRINT '   ✓ Velocity Tracking (via TimeEntries)';
PRINT '   ✓ Cost Tracking (TimeEntries @ $50/hour)';
PRINT '   ✓ Risk Analysis (ProjectRisks table)';
PRINT '=====================================';