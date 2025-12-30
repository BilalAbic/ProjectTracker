namespace ProjectTracker.Business.DTOs
{
    /// <summary>
    /// DTO for creating a new team
    /// </summary>
    public class CreateTeamDto
    {
        public string TeamName { get; set; }
        public string? Description { get; set; }
    }
}
