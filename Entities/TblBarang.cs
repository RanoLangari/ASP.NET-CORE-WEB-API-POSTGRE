using System;
using System.Collections.Generic;

namespace CRUD_ASP.POSTGRESQL.Entities;

public partial class TblBarang
{
    public int IdBarang { get; set; }

    public string? NamaBarang { get; set; }

    public string? KategoriBarang { get; set; }
}

public partial class DataBarang
{
    public string? NamaBarang { get; set; }

    public string? KategoriBarang { get; set; }
}

