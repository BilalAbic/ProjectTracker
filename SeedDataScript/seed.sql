-- ============================================
-- ProjectTracker - Comprehensive Seed Data
-- ============================================
-- Created: 2025-12-29
-- Description: Complete seed data with users, teams, projects, tasks, and all relationships
-- ============================================
-- Clean up existing data (optional - use only if tables exist)
-- DELETE FROM TaskComments;
-- DELETE FROM Tasks;
-- DELETE FROM TeamInvitations;
-- DELETE FROM TeamMembers;
-- DELETE FROM ProjectTeamMembers;
-- DELETE FROM Projects;
-- DELETE FROM Teams;
-- DELETE FROM Notifications;
-- DELETE FROM Users;
-- DELETE FROM Roles;
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
(3, 2, 3, 'Owner', '2025-01-15', 1),        -- Sarah PM (Owner)
(4, 2, 6, 'Developer', '2025-01-16', 1),    -- David Dev
(5, 2, 7, 'Developer', '2025-01-16', 1),    -- Emma Dev
(6, 2, 1, 'Admin', '2025-01-15', 1),        -- Admin (overseer)
-- Backend & API Team
(7, 3, 4, 'Owner', '2025-01-20', 1),        -- Mike PM (Owner)
(8, 3, 8, 'Developer', '2025-01-21', 1),    -- Alex Dev
(9, 3, 9, 'Developer', '2025-01-21', 1),    -- Sophia Dev
(10, 3, 2, 'Admin', '2025-01-20', 1),       -- John Admin (overseer)
-- Mobile Development Team
(11, 4, 5, 'Owner', '2025-02-01', 1),       -- Lisa PM (Owner)
(12, 4, 10, 'Developer', '2025-02-02', 1),  -- James Dev
(13, 4, 6, 'Developer', '2025-02-03', 1),   -- David Dev (cross-team)
(14, 4, 1, 'Admin', '2025-02-01', 1);       -- Admin (overseer)
SET IDENTITY_INSERT TeamMembers OFF;
-- ============================================
-- 5. PROJECTS (8 Projects across teams)
-- ============================================
SET IDENTITY_INSERT Projects ON;
INSERT INTO Projects (ProjectId, TeamId, CreatedByUserId, ProjectName, Description, StartDate, EndDate, Budget, Status, Priority, CompletionPercentage, CreatedAt) VALUES
-- Frontend Team Projects
(1, 2, 3, 'E-Commerce Platform', 'Building a modern e-commerce platform with React and Next.js', '2025-10-29', '2026-04-29', 150000.00, 'Active', 3, 35.00, '2025-10-29'),
(2, 2, 3, 'Corporate Website Redesign', 'Complete redesign of company website with modern UI', '2025-11-15', '2026-02-15', 50000.00, 'Active', 2, 60.00, '2025-11-15'),
(3, 2, 3, 'Admin Dashboard', 'Internal admin dashboard for management', '2025-12-01', '2026-01-31', 30000.00, 'Active', 1, 15.00, '2025-12-01'),
-- Backend Team Projects
(4, 3, 4, 'API Gateway Development', 'Microservices API gateway with authentication', '2025-11-01', '2026-03-01', 80000.00, 'Active', 4, 45.00, '2025-11-01'),
(5, 3, 4, 'Database Migration Tool', 'Automated database migration and versioning tool', '2025-12-15', '2026-02-28', 40000.00, 'Active', 2, 20.00, '2025-12-15'),
-- Mobile Team Projects
(6, 4, 5, 'Mobile Banking App', 'iOS and Android banking app with biometric auth', '2025-11-29', '2026-03-29', 200000.00, 'Active', 4, 25.00, '2025-11-29'),
(7, 4, 5, 'Fitness Tracker App', 'Cross-platform fitness and health tracking app', '2025-12-20', '2026-04-20', 120000.00, 'Planned', 3, 0.00, '2025-12-20'),
-- Default Team Project
(8, 1, 1, 'Internal CRM System', 'Customer relationship management for internal use', '2026-01-13', '2026-06-29', 80000.00, 'Planned', 2, 0.00, '2025-12-29');
SET IDENTITY_INSERT Projects OFF;
-- ============================================
-- 6. PROJECT TEAM MEMBERS (Assign devs to projects)
-- ============================================
SET IDENTITY_INSERT ProjectTeamMembers ON;
INSERT INTO ProjectTeamMembers (TeamMemberId, ProjectId, UserId, ProjectRole, JoinedAt) VALUES
-- E-Commerce Platform (Project 1)
(1, 1, 6, 'Frontend Lead', '2025-10-29'),
(2, 1, 7, 'UI/UX Developer', '2025-10-30'),
-- Corporate Website (Project 2)
(3, 2, 7, 'Lead Developer', '2025-11-15'),
-- Admin Dashboard (Project 3)
(4, 3, 6, 'Full-stack Developer', '2025-12-01'),
-- API Gateway (Project 4)
(5, 4, 8, 'Backend Lead', '2025-11-01'),
(6, 4, 9, 'API Developer', '2025-11-02'),
-- Database Migration (Project 5)
(7, 5, 9, 'Database Engineer', '2025-12-15'),
-- Mobile Banking (Project 6)
(8, 6, 10, 'iOS Developer', '2025-11-29'),
(9, 6, 6, 'Android Developer', '2025-11-30'),
-- Fitness Tracker (Project 7)
(10, 7, 10, 'Mobile Lead', '2025-12-20');
SET IDENTITY_INSERT ProjectTeamMembers OFF;
-- ============================================
-- 7. TASKS (25+ Tasks across projects)
-- ============================================
SET IDENTITY_INSERT Tasks ON;
INSERT INTO Tasks (TaskId, ProjectId, AssignedUserId, ParentTaskId, TaskName, Description, Priority, Status, EstimatedHours, ActualHours, StartDate, DueDate, CompletedDate, IsCriticalPath, CreatedAt) VALUES
-- E-Commerce Platform Tasks (Project 1)
(1, 1, 6, NULL, 'Design Product Catalog UI', 'Create wireframes and mockups for product listing', 'High', 'Completed', 40, 38, '2025-10-29', '2025-11-29', '2025-12-04', 0, '2025-10-29'),
(2, 1, 7, NULL, 'Implement Shopping Cart', 'Build cart functionality with session management', 'Critical', 'InProgress', 60, 35, '2025-12-19', '2026-01-03', NULL, 1, '2025-12-19'),
(3, 1, 6, NULL, 'Setup Payment Gateway', 'Integrate Stripe for checkout process', 'High', 'Pending', 50, NULL, '2026-01-03', '2026-01-13', NULL, 0, '2025-12-29'),
(4, 1, NULL, NULL, 'Performance Testing', 'Load test for 10k concurrent users', 'Medium', 'Blocked', 30, NULL, '2025-12-29', '2026-01-18', NULL, 0, '2025-12-29'),
-- Corporate Website Tasks (Project 2)
(5, 2, 7, NULL, 'Homepage Redesign', 'Design and implement new homepage layout', 'High', 'Completed', 45, 42, '2025-11-15', '2025-12-01', '2025-12-05', 0, '2025-11-15'),
(6, 2, 7, NULL, 'Contact Form Integration', 'Add contact form with email notifications', 'Medium', 'Completed', 20, 18, '2025-12-05', '2025-12-15', '2025-12-14', 0, '2025-12-05'),
(7, 2, 7, NULL, 'SEO Optimization', 'Implement SEO best practices', 'High', 'InProgress', 30, 15, '2025-12-10', '2026-01-05', NULL, 0, '2025-12-10'),
-- Admin Dashboard Tasks (Project 3)
(8, 3, 6, NULL, 'User Management Module', 'CRUD for user administration', 'Critical', 'InProgress', 50, 25, '2025-12-01', '2025-12-25', NULL, 1, '2025-12-01'),
(9, 3, 6, NULL, 'Analytics Dashboard', 'Real-time analytics and charts', 'High', 'Pending', 60, NULL, '2025-12-20', '2026-01-15', NULL, 0, '2025-12-10'),
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
-- 8. TEAM INVITATIONS (Some pending invitations)
-- ============================================
SET IDENTITY_INSERT TeamInvitations ON;
INSERT INTO TeamInvitations (InvitationId, TeamId, Email, InvitedByUserId, ProposedRole, Status, Token, SentAt, ExpiresAt, RespondedAt) VALUES
-- Pending invitations
(1, 2, 'newdev1@example.com', 3, 'Developer', 'Pending', NEWID(), '2025-12-25', '2026-01-01', NULL),
(2, 3, 'backend.expert@example.com', 4, 'ProjectManager', 'Pending', NEWID(), '2025-12-26', '2026-01-02', NULL),
-- Accepted invitation
(3, 4, 'james.taylor@projecttracker.com', 5, 'Developer', 'Accepted', NEWID(), '2025-02-01', '2025-02-08', '2025-02-02'),
-- Declined invitation
(4, 2, 'declined@example.com', 3, 'Observer', 'Declined', NEWID(), '2025-12-20', '2025-12-27', '2025-12-21'),
-- Expired invitation
(5, 3, 'expired@example.com', 4, 'Developer', 'Pending', NEWID(), '2025-12-10', '2025-12-17', NULL);
SET IDENTITY_INSERT TeamInvitations OFF;
-- ============================================
-- 9. TASK COMMENTS (Some sample comments)
-- ============================================
SET IDENTITY_INSERT TaskComments ON;
INSERT INTO TaskComments (CommentId, TaskId, UserId, CommentText, CreatedAt) VALUES
(1, 2, 7, 'Working on the cart state management. Redux implementation is 50% complete.', '2025-12-20 10:30:00'),
(2, 2, 3, 'Great progress! Make sure to add unit tests for the cart reducer.', '2025-12-20 14:15:00'),
(3, 8, 6, 'User roles and permissions table design completed. Ready for review.', '2025-12-10 09:00:00'),
(4, 11, 9, 'Found a good rate-limiting library. Testing with different scenarios.', '2025-12-01 11:20:00'),
(5, 15, 10, 'iOS Face ID integration done. Working on Android biometric now.', '2025-12-27 16:45:00');
SET IDENTITY_INSERT TaskComments OFF;
-- ============================================
-- 10. NOTIFICATIONS (Sample notifications)
-- ============================================
SET IDENTITY_INSERT Notifications ON;
INSERT INTO Notifications (NotificationId, UserId, Title, Message, Type, IsRead, CreatedAt) VALUES
(1, 6, 'Task Assigned', 'You have been assigned to task: Setup Payment Gateway', 'Info', 0, '2025-12-29 08:00:00'),
(2, 7, 'Task Completed', 'Your task "Cart Item Addition" has been marked as completed', 'Success', 1, '2025-12-22 17:30:00'),
(3, 3, 'Team Invitation', 'newdev1@example.com has been invited to Frontend Development team', 'Info', 0, '2025-12-25 14:00:00'),
(4, 8, 'Project Update', 'API Gateway Development is now 45% complete', 'Info', 1, '2025-12-28 09:00:00'),
(5, 10, 'Task Overdue', 'Task "Biometric Authentication" is approaching deadline', 'Warning', 0, '2025-12-29 07:00:00');
SET IDENTITY_INSERT Notifications OFF;
-- ============================================
-- VERIFICATION QUERIES
-- ============================================
-- Count summary
SELECT 'Users' AS Entity, COUNT(*) AS Count FROM Users
UNION ALL
SELECT 'Teams', COUNT(*) FROM Teams
UNION ALL
SELECT 'TeamMembers', COUNT(*) FROM TeamMembers
UNION ALL
SELECT 'Projects', COUNT(*) FROM Projects
UNION ALL
SELECT 'Tasks', COUNT(*) FROM Tasks
UNION ALL
SELECT 'TeamInvitations', COUNT(*) FROM TeamInvitations
UNION ALL
SELECT 'TaskComments', COUNT(*) FROM TaskComments
UNION ALL
SELECT 'Notifications', COUNT(*) FROM Notifications;
-- Team membership summary
SELECT 
    T.TeamName,
    COUNT(TM.TeamMemberId) AS MemberCount,
    COUNT(P.ProjectId) AS ProjectCount
FROM Teams T
LEFT JOIN TeamMembers TM ON T.TeamId = TM.TeamId AND TM.IsActive = 1
LEFT JOIN Projects P ON T.TeamId = P.TeamId
GROUP BY T.TeamId, T.TeamName
ORDER BY T.TeamId;
-- Task status summary by project
SELECT 
    P.ProjectName,
    T.Status,
    COUNT(*) AS TaskCount
FROM Projects P
INNER JOIN Tasks T ON P.ProjectId = T.ProjectId
GROUP BY P.ProjectId, P.ProjectName, T.Status
ORDER BY P.ProjectId, T.Status;
PRINT '✅ Seed data inserted successfully!';
PRINT '📊 Database contains:';
PRINT '   - 10 Users (2 Admins, 3 PMs, 5 Devs)';
PRINT '   - 4 Teams with 14 members';
PRINT '   - 8 Projects across all teams';
PRINT '   - 25 Tasks with various statuses';
PRINT '   - 5 Team Invitations';
PRINT '   - 5 Task Comments';
PRINT '   - 5 Notifications';