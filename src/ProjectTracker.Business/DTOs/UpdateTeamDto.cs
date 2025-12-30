namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for updating an existing team
    /// </summary>
    public class UpdateTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string? Description { get; set; }
    }
}
