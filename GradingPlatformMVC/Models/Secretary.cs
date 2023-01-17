using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GradingPlatformMVC.Models;

[Table("secretaries")]
[Index("PhoneNumber", Name = "UQ__secretar__4849DA01B682E493", IsUnique = true)]
public partial class Secretary
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

    [Column("phoneNumber")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

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
}
