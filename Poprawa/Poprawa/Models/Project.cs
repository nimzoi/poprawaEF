namespace Poprawa.Models
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
            Accesses = new HashSet<Access>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int DefaultAssigneeId { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Access> Accesses { get; set; }
    }
}