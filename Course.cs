namespace StudyPlanner.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<StudyNote>? StudyNotes { get; set; }
    }
}