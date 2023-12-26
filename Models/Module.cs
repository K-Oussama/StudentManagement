using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentManagmentSystem.Models;

public partial class Module
{
    [Key]
    [Column("module_id")]
    public int ModuleId { get; set; }

    [Column("module_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ModuleName { get; set; }

    [Column("module_level")]
    public int? ModuleLevel { get; set; }

    [Column("passed")]
    public bool? Passed { get; set; }

    [InverseProperty("Module")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
