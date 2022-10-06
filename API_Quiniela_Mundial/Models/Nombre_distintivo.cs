namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Nombre_distintivo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Id_nom_distintivo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Id_equipo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string Id_user { get; set; }

        [Column("Nombre_distintivo")]
        [StringLength(50)]
        public string Nombre_distintivo1 { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_liga { get; set; }

        public virtual Equipo Equipo { get; set; }

        public virtual Liga Liga { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
