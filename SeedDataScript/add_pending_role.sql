-- Add Pending Role to Roles table
-- Run this script if migration is not available

-- Check if Pending role already exists
IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleId = 4)
BEGIN
    SET IDENTITY_INSERT Roles ON;
    
    INSERT INTO Roles (RoleId, RoleName, Description)
    VALUES (4, 'Pending', 'Waiting for approval - Limited access');
    
    SET IDENTITY_INSERT Roles OFF;
    
    PRINT 'Pending role added successfully.';
END
ELSE
BEGIN
    PRINT 'Pending role already exists.';
END
GO
