namespace Backend.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OyunlarTurler")]
    public partial class OyunlarTurler
    {
        public int Id { get; set; }

        public int OyunId { get; set; }

        public int TurId { get; set; }

        public virtual Oyunlar Oyunlar { get; set; }

        public virtual Turler Turler { get; set; }
    }
}
