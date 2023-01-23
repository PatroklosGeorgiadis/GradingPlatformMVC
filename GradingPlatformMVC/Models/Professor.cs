using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

[Table("professors")]
[Index("Afm", Name = "UQ__professo__C6906E626E9F47D0", IsUnique = true)]
public partial class Professor
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

    [Column("AFM")]
    [StringLength(50)]
    [Unicode(false)]
    public string Afm { get; set; } = null!;

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("surname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Surname { get; set; }

    [Column("department")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Department { get; set; }
    [InverseProperty("ProfessorsAfmNavigation")]
    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
