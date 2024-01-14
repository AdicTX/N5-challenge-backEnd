using System;
using System.Collections.Generic;

namespace N5challenge.Models;

public partial class Permission
{
    public int Id { get; set; }

    public string Nombreempleado { get; set; } = null!;

    public string Apellidoempleado { get; set; } = null!;

    public int Tipopermiso { get; set; }

    public DateOnly Fechapermiso { get; set; }

    public virtual PermissionType TipopermisoNavigation { get; set; } = null!;
}
