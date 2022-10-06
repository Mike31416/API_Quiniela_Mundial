namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tarjeta_credito
    {
        [Key]
        [StringLength(10)]
        public string id_tarjera { get; set; }

        [StringLength(30)]
        public string Tipo_banco { get; set; }

        [StringLength(20)]
        public string Fecha_vencimiento { get; set; }

        [StringLength(20)]
        public string Fecha_emisión { get; set; }

        [StringLength(30)]
        public string Nombre_persona { get; set; }

        [StringLength(10)]
        public string Codigo_seguridad { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
