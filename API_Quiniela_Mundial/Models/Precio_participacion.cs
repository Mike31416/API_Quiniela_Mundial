namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Precio_participacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Precio_participacion()
        {
            Factura = new HashSet<Factura>();
        }

        [Key]
        [StringLength(30)]
        public string Id_participacion { get; set; }

        [StringLength(30)]
        public string Monto { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_liga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }

        public virtual Liga Liga { get; set; }
    }
}
