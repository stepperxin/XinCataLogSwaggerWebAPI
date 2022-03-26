using System;
using System.Collections.Generic;

#nullable disable

namespace XinCataLogSwaggerWebAPI.Data
{
    public partial class XinComic
    {
        public int Id { get; set; }
        public string Series { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
    }
}
