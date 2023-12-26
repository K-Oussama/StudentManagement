using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagmentSystem.Models;

public partial class Evaluation
{
    [Key]
    [Column("evaluation_id")]
    public int EvaluationId { get; set; }

    [Column("course_id")]
    public int? CourseId { get; set; }

    [Column("student_id")]
    public int? StudentId { get; set; }

    [Column("evaluation_type")]
    [StringLength(20)]
    [Unicode(false)]
    public string? EvaluationType { get; set; }

    [Column("score", TypeName = "decimal(4, 2)")]
    public decimal? Score { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Evaluations")]
    public virtual Course? Course { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Evaluations")]
    public virtual Student? Student { get; set; }
}
