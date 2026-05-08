using System;
using System.Collections.Generic;

namespace EFAA.Entities;

public partial class Designer
{
    public int DesignerId { get; set; }

    public string DesignerName { get; set; } = null!;

    public virtual ICollection<Garment> Garments { get; set; } = new List<Garment>();
    public int DesingnerId { get; set; }
}
