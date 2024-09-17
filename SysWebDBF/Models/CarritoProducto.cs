using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

[PrimaryKey("IdCarrito", "IdProducto")]
public partial class CarritoProducto
{
    [Key]
    [Column("idCarrito")]
    public int IdCarrito { get; set; }

    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    [Column("cantidad")]
    public int Cantidad { get; set; }

    [ForeignKey("IdCarrito")]
    [InverseProperty("CarritoProducto")]
    public virtual CarritoCompra IdCarritoNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("CarritoProducto")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
