using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class CarritoCompra
{
    [Key]
    [Column("idCarrito")]
    public int IdCarrito { get; set; }

    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("total", TypeName = "decimal(10, 2)")]
    public decimal? Total { get; set; }

    [InverseProperty("IdCarritoNavigation")]
    public virtual ICollection<CarritoProducto> CarritoProducto { get; set; } = new List<CarritoProducto>();

    [ForeignKey("IdCliente")]
    [InverseProperty("CarritoCompra")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
