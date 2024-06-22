namespace Poprawa.Models
{
    public partial class User
    {
        public User()
        {
            ReportedTasks = new HashSet<Task>();
            AssignedTasks = new HashSet<Task>();
            Accesses = new HashSet<Access>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Task> ReportedTasks { get; set; }
        public virtual ICollection<Task> AssignedTasks { get; set; }
        public virtual ICollection<Access> Accesses { get; set; }
    }
}