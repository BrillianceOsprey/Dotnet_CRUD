using System;
using System.Collections.Generic;

namespace Dotnet_CRUD.Domain.DBContexts;

public partial class Character
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int HitPoints { get; set; }

    public int Strength { get; set; }

    public int Defence { get; set; }

    public int Intelligence { get; set; }

    public int Class { get; set; }
}
