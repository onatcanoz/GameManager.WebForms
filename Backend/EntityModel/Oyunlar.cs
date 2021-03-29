namespace Backend.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oyunlar")]
    public partial class Oyunlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oyunlar()
        {
            OyunlarTurler = new HashSet<OyunlarTurler>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Adi { get; set; }

        public double? Maliyeti { get; set; }

        public double? Kazanci { get; set; }

        public int? YapimciId { get; set; }

        public DateTime? YapimTarihi { get; set; }

        public virtual Yapimcilar Yapimcilar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OyunlarTurler> OyunlarTurler { get; set; }
    }
}
