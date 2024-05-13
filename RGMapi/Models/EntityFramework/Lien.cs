using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RGMapi.Models.EntityFramework;

[Table("lien")]
public partial class Lien
{
    [Key]
    [Column("lienid")]
    public int Lienid { get; set; }

    [Column("liendesc")]
    [StringLength(100)]
    public string? Liendesc { get; set; }

    [Column("lien")]
    [StringLength(100)]
    public string? Lien1 { get; set; }
}
