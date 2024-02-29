using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models.EntityModel;

public  class AllergiesDetailView
{
  
    public int Id { get; set; }

    public string? Patient { get; set; }

 
    public string? Allergies { get; set; }
}
