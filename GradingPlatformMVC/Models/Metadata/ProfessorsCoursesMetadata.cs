using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GradingPlatformMVC.Models.Metadata
{
    public class ProfessorsCoursesMetadata
    {
        [Display(Name = "Course Title")]
        public string? CourseTitle { get; set; }

        [Display(Name = "Course Semester")]
        public int? CourseSemester { get; set; }

        [Display(Name = "Professor's Afm")]
        public string? ProfessorsAfm { get; set; }
    }
}
