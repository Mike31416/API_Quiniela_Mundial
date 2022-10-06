namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Liga_ganador
    {
        [Key]
        [StringLength(30)]
        public string Id_liga_gan { get; set; }

        [StringLength(10)]
        public string Monto_ganado { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_liga { get; set; }

        public virtual Liga Liga { get; set; }
    }
}
