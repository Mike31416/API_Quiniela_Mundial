namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Puntos
    {
        [Key]
        [StringLength(10)]
        public string Id_puntos { get; set; }

        [Column("Puntos")]
        [StringLength(10)]
        public string Puntos1 { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_equipo { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
