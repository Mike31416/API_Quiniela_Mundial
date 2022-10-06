namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Liga")]
    public partial class Liga
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Liga()
        {
            Ganador = new HashSet<Ganador>();
            Ganadores_individuales = new HashSet<Ganadores_individuales>();
            Liga_ganador = new HashSet<Liga_ganador>();
            Nombre_distintivo = new HashSet<Nombre_distintivo>();
            Precio_participacion = new HashSet<Precio_participacion>();
            Rol = new HashSet<Rol>();
        }

        [Key]
        [StringLength(30)]
        public string Id_liga { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_tipo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre_liga { get; set; }

        [StringLength(10)]
        public string Puntos_liga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ganador> Ganador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ganadores_individuales> Ganadores_individuales { get; set; }

        public virtual Tipo_liga Tipo_liga { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Liga_ganador> Liga_ganador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nombre_distintivo> Nombre_distintivo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Precio_participacion> Precio_participacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rol> Rol { get; set; }
    }
}
