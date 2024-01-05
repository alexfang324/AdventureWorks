using System;
using System.Collections.Generic;

namespace AdventureWorks.EfModels;

public partial class BuildVersion
{
    public long SystemInformationId { get; set; }

    public string DatabaseVersion { get; set; } = null!;

    public string VersionDate { get; set; } = null!;

    public string ModifiedDate { get; set; } = null!;
}
