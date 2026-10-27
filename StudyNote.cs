namespace StudyPlanner.Models
{
    public class StudyNote
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}