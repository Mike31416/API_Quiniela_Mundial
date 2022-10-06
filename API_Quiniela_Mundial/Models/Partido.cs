namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partido")]
    public partial class Partido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partido()
        {
            Fecha = new HashSet<Fecha>();
            Vaticinio_usuario = new HashSet<Vaticinio_usuario>();
        }

        [Key]
        [StringLength(10)]
        public string Id_partido { get; set; }

        [StringLength(10)]
        public string Resultado { get; set; }

        [StringLength(30)]
        public string Visitante { get; set; }

        [StringLength(30)]
        public string Local { get; set; }

        [StringLength(30)]
        public string Horario { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_estadio { get; set; }

        [Required]
        [StringLength(20)]
        public string Id_fase { get; set; }

        public virtual Estadio Estadio { get; set; }

        public virtual Fase Fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fecha> Fecha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vaticinio_usuario> Vaticinio_usuario { get; set; }
    }
}
