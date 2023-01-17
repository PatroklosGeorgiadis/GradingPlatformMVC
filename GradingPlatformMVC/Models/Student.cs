using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

[Table("students")]
[Index("RegistrationNum", Name = "UQ__students__DD1F272C84155ED5", IsUnique = true)]
public partial class Student
{
    [Key]
    [Column("username")]
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("surname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Surname { get; set; }

    [Column("registrationNum")]
    [StringLength(50)]
    [Unicode(false)]
    public string RegistrationNum { get; set; } = null!;

    [Column("department")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Department { get; set; }

    public virtual ICollection<CourseHasStudent> CourseHasStudents { get; } = new List<CourseHasStudent>();
}
