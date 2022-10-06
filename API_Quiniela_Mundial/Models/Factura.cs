namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [Key]
        [StringLength(10)]
        public string Id_factura { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        [Required]
        [StringLength(30)]
        public string id_vaticinio { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_participacion { get; set; }

        public virtual Precio_participacion Precio_participacion { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Vaticinio Vaticinio { get; set; }
    }
}
