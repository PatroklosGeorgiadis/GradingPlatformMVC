using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

[Table("courses")]
public partial class Course
{
    [Key]
    [Column("idCourse")]
    public int IdCourse { get; set; }

    [Column("courseTitle")]
    [StringLength(100)]
    [Unicode(false)]
    public string? CourseTitle { get; set; }

    [Column("courseSemester")]
    public int? CourseSemester { get; set; }

    [Column("professorsAFM")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProfessorsAfm { get; set; }

    [InverseProperty("IdCourseNavigation")]
    public virtual ICollection<CourseHasStudent> CourseHasStudents { get; } = new List<CourseHasStudent>();

    public virtual Professor? ProfessorsAfmNavigation { get; set; }
}
