namespace Backend.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yapimcilar")]
    public partial class Yapimcilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Yapimcilar()
        {
            Oyunlar = new HashSet<Oyunlar>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Adi { get; set; }

        public int UlkeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oyunlar> Oyunlar { get; set; }

        public virtual Ulkeler Ulkeler { get; set; }
    }
}
