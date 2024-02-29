using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models.EntityModel;

[Table("NCDDetails")]
public  class NcdDetail
{
    [Key]
    public int Id { get; set; }

    public int? PatientId { get; set; }

    [Column("NCDId")]
    public int? Ncdid { get; set; }
}
