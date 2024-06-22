namespace Poprawa.DTOs
{
    public class CreateTaskDTO
    {
        public int ProjectId { get; set; }
        public int ReporterId { get; set; }
        public int? AssigneeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}