using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagmentSystem.Models;

public partial class Course
{
    [Key]
    [Column("course_id")]
    public int CourseId { get; set; }

    [Column("module_id")]
    public int? ModuleId { get; set; }

    [Column("course_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CourseName { get; set; }

    [Column("course_hours")]
    public int? CourseHours { get; set; }

    [Column("taught_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TaughtBy { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    [ForeignKey("ModuleId")]
    [InverseProperty("Courses")]
    public virtual Module? Module { get; set; }
}
