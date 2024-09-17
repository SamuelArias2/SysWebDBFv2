using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class Ropa
{
    [Key]
    [Column("idRopa")]
    public int IdRopa { get; set; }

    [Column("talla")]
    [StringLength(5)]
    [Unicode(false)]
    public string? Talla { get; set; }

    [Column("color")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Color { get; set; }

    [ForeignKey("IdRopa")]
    [InverseProperty("Ropa")]
    public virtual Producto IdRopaNavigation { get; set; } = null!;
}
