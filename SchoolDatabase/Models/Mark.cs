using System;

namespace SchoolDatabase.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
    }
}