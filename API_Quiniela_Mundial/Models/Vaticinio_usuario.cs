namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vaticinio_usuario
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Id_partido { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string id_vaticinio { get; set; }

        [StringLength(10)]
        public string Puntos { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        public virtual Partido Partido { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Vaticinio Vaticinio { get; set; }
    }
}
