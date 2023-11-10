using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Revers_EntityFramework.Models;

[Table("Student")]
[Index("GradeId", Name = "IX_Student_GradeId")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public float? Height { get; set; }

    public float? Weight { get; set; }

    public int? GradeId { get; set; }

    public string? Photo { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    [ForeignKey("GradeId")]
    [InverseProperty("Students")]
    public virtual Grade? Grade { get; set; }
}
