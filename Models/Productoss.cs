using System;
using System.Collections.Generic;

namespace productospra3.Models;

public partial class Productoss
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }
}
