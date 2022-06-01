using System;
using System.Collections.Generic;

#nullable disable

namespace ITNotesAPI.Models.DB
{
    public partial class Note
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}
