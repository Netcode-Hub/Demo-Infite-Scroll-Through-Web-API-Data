

namespace Demo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string title { get; set; }
        public bool Completed { get; set; }
    }
}
