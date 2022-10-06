namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fase")]
    public partial class Fase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fase()
        {
            Partido = new HashSet<Partido>();
        }

        [Key]
        [StringLength(20)]
        public string Id_fase { get; set; }

        [StringLength(50)]
        public string Nombre_fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
