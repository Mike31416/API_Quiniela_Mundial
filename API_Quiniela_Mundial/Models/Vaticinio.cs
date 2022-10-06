namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaticinio")]
    public partial class Vaticinio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vaticinio()
        {
            Factura = new HashSet<Factura>();
            Vaticinio_usuario = new HashSet<Vaticinio_usuario>();
        }

        [Key]
        [StringLength(30)]
        public string id_vaticinio { get; set; }

        [StringLength(30)]
        public string Fase { get; set; }

        [StringLength(30)]
        public string Evento { get; set; }

        [StringLength(10)]
        public string Pronostico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Factura> Factura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaticinio_usuario> Vaticinio_usuario { get; set; }
    }
}
