using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DevApplication.Models.EntityModel;

public  class AllergiesDetail
{
    [Key]
    public int Id { get; set; }

    public int? PatienId { get; set; }

    [Column("AllergiesID")]
    public int? AllergiesId { get; set; }
}
