namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ganador")]
    public partial class Ganador
    {
        [Key]
        [StringLength(30)]
        public string Id_ganador { get; set; }

        [StringLength(30)]
        public string Lugar_ganador { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_liga { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        [StringLength(30)]
        public string Monto_ganado { get; set; }

        public virtual Liga Liga { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
