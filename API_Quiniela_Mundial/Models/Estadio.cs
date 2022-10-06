namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estadio")]
    public partial class Estadio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estadio()
        {
            Partido = new HashSet<Partido>();
        }

        [Key]
        [StringLength(10)]
        public string Id_estadio { get; set; }

        [StringLength(50)]
        public string Nombre_estadio { get; set; }

        [StringLength(50)]
        public string Capacidad { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_sede { get; set; }

        public virtual Sede Sede { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partido> Partido { get; set; }
    }
}
