using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

[PrimaryKey("IdCourse", "RegistrationNum")]
[Table("course_has_students")]
public partial class CourseHasStudent
{
    [Key]
    [Column("idCourse")]
    public int IdCourse { get; set; }

    [Key]
    [Column("registrationNum")]
    [StringLength(50)]
    [Unicode(false)]
    public string RegistrationNum { get; set; } = null!;

    [Column("grade")]
    public int? Grade { get; set; }

    [ForeignKey("IdCourse")]
    [InverseProperty("CourseHasStudents")]
    public virtual Course IdCourseNavigation { get; set; } = null!;

    public virtual Student RegistrationNumNavigation { get; set; } = null!;
}
