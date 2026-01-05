-- =====================================================
-- Plesk Veritabanı için Davet Tablosu
-- Bu script'i Plesk'teki DboProjectTracker veritabanında çalıştırın
-- =====================================================

-- Davetler Tablosu
CREATE TABLE Invitations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Token NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL,
    TeamName NVARCHAR(100) NOT NULL,
    InvitedByName NVARCHAR(100) NOT NULL,
    ProposedRole NVARCHAR(50) NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending', -- Pending, Accepted, Declined, Expired
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    ExpiresAt DATETIME NOT NULL,
    RespondedAt DATETIME NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Index for faster token lookup
CREATE INDEX IX_Invitations_Token ON Invitations(Token);
CREATE INDEX IX_Invitations_Email ON Invitations(Email);
CREATE INDEX IX_Invitations_Status ON Invitations(Status);

-- Test verisi (opsiyonel - silebilirsiniz)
-- INSERT INTO Invitations (Token, Email, TeamName, InvitedByName, ProposedRole, ExpiresAt)
-- VALUES ('test123', 'test@example.com', 'Test Team', 'Admin', 'Developer', DATEADD(DAY, 7, GETDATE()));

PRINT 'Invitations tablosu başarıyla oluşturuldu!';
