using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysWebDBF.Models;

[Index("Email", Name = "UQ__Cliente__AB6E6164DD29124D", IsUnique = true)]
public partial class Cliente
{
    [Key]
    [Column("idCliente")]
    public int IdCliente { get; set; }

    [Column("nombre")]
    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column("direccion")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Direccion { get; set; }

    [Column("telefono")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Telefono { get; set; }

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<CarritoCompra> CarritoCompra { get; set; } = new List<CarritoCompra>();

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
