namespace Poprawa.Models
{
    public partial class Task
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int ReporterId { get; set; }
        public int? AssigneeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Project Project { get; set; }
        public virtual User Reporter { get; set; }
        public virtual User Assignee { get; set; }
    }
}