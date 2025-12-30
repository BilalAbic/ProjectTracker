namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for roles
    /// </summary>
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
