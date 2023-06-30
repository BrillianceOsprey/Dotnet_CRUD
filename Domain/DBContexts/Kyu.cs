using System;
using System.Collections.Generic;

namespace Dotnet_CRUD.Domain.DBContexts;

public partial class Kyu
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }
}
