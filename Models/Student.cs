using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagmentSystem.Models;

public partial class Student
{
    [Key]
    [Column("student_id")]
    public int StudentId { get; set; }

    [Column("student_firstName")]
    [StringLength(50)]
    public string? StudentFirstName { get; set; }

    [Column("student_lastName")]
    [StringLength(50)]
    public string? StudentLastName { get; set; }

    [Column("student_email")]
    [StringLength(50)]
    public string? StudentEmail { get; set; }

    [Column("year_level")]
    public int? YearLevel { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
}
