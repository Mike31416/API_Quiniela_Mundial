namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mundial")]
    public partial class Mundial
    {
        [Key]
        [StringLength(50)]
        public string Id_mundial { get; set; }

        [StringLength(50)]
        public string Nombre_mundial { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_user { get; set; }

        [Required]
        [StringLength(10)]
        public string Id_sede { get; set; }

        public virtual Sede Sede { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
