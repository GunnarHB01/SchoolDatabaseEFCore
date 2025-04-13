namespace SchoolDatabase.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    public List<Student> Students { get; set; } = new();
    }
}
