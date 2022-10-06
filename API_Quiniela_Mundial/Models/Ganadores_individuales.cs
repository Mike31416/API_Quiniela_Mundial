namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ganadores_individuales
    {
        [Key]
        [StringLength(30)]
        public string Id_gan_ind { get; set; }

        [StringLength(30)]
        public string Monto_gan { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_liga { get; set; }

        public virtual Liga Liga { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
