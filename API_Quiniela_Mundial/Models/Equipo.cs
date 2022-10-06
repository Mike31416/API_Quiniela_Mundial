namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipo")]
    public partial class Equipo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipo()
        {
            Fecha = new HashSet<Fecha>();
            Nombre_distintivo = new HashSet<Nombre_distintivo>();
            Puntos = new HashSet<Puntos>();
        }

        [Key]
        [StringLength(10)]
        public string Id_equipo { get; set; }

        [StringLength(50)]
        public string Nombre_equipo { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_clasificacion { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_grupos { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }

        public virtual Grupos Grupos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fecha> Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nombre_distintivo> Nombre_distintivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puntos> Puntos { get; set; }
    }
}
