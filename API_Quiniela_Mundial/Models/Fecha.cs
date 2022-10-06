namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fecha")]
    public partial class Fecha
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Id_equipo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Id_partido { get; set; }

        [Column("Fecha")]
        [StringLength(30)]
        public string Fecha1 { get; set; }

        [StringLength(10)]
        public string Resultado { get; set; }

        public virtual Equipo Equipo { get; set; }

        public virtual Partido Partido { get; set; }
    }
}
