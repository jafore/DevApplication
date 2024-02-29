using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models.EntityModel;

public  class PatientView
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }
    public string? Diseases { get; set; }
    public bool? Epilepsy { get; set; }
}
