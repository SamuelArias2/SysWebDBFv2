using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

public partial class Producto
{
    [Key]
    [Column("idProducto")]
    public int IdProducto { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("precio", TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    [Column("stock")]
    public int Stock { get; set; }

    [Column("descripcion")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [InverseProperty("IdAccesorioNavigation")]
    public virtual Accesorio? Accesorio { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<CarritoProducto> CarritoProducto { get; set; } = new List<CarritoProducto>();

    [InverseProperty("IdRopaNavigation")]
    public virtual Ropa? Ropa { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<VentaProducto> VentaProducto { get; set; } = new List<VentaProducto>();
}
