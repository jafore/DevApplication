using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models.EntityModel;

[Table("NCDDetails")]
public  class NcdDetailView
{
 
    public int Id { get; set; }

    public String? Patient { get; set; }


    public String? Ncd { get; set; }
}
