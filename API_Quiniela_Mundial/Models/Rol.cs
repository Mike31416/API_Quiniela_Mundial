namespace API_Quiniela_Mundial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rol")]
    public partial class Rol
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Id_liga { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Id_user { get; set; }

        [Required]
        [StringLength(30)]
        public string Id_tipoRoles { get; set; }

        public virtual Liga Liga { get; set; }

        public virtual Tipo_roles Tipo_roles { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
