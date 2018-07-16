namespace EntityFramework.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schedules
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
