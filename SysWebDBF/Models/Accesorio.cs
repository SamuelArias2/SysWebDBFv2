using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class Accesorio
{
    [Key]
    [Column("idAccesorio")]
    public int IdAccesorio { get; set; }

    [Column("material")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Material { get; set; }

    [ForeignKey("IdAccesorio")]
    [InverseProperty("Accesorio")]
    public virtual Producto IdAccesorioNavigation { get; set; } = null!;
}
