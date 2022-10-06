using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace API_Quiniela_Mundial.Models
{
    public partial class BDD_Quiniela_Mundial : DbContext
    {
        public BDD_Quiniela_Mundial()
            : base("name=BDD_Quiniela_Mundial")
        {
        }

        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Fase> Fase { get; set; }
        public virtual DbSet<Fecha> Fecha { get; set; }
        public virtual DbSet<Ganador> Ganador { get; set; }
        public virtual DbSet<Ganadores_individuales> Ganadores_individuales { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Liga> Liga { get; set; }
        public virtual DbSet<Liga_ganador> Liga_ganador { get; set; }
        public virtual DbSet<Mundial> Mundial { get; set; }
        public virtual DbSet<Nombre_distintivo> Nombre_distintivo { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Precio_participacion> Precio_participacion { get; set; }
        public virtual DbSet<Puntos> Puntos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sede> Sede { get; set; }
        public virtual DbSet<Tarjeta_credito> Tarjeta_credito { get; set; }
        public virtual DbSet<Tipo_liga> Tipo_liga { get; set; }
        public virtual DbSet<Tipo_roles> Tipo_roles { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vaticinio> Vaticinio { get; set; }
        public virtual DbSet<Vaticinio_usuario> Vaticinio_usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clasificacion>()
                .Property(e => e.Id_clasificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Clasificacion>()
                .Property(e => e.Tipo_clasificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Clasificacion>()
                .HasMany(e => e.Equipo)
                .WithRequired(e => e.Clasificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Id_equipo)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Nombre_equipo)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Id_clasificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Id_grupos)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Fecha)
                .WithRequired(e => e.Equipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Nombre_distintivo)
                .WithRequired(e => e.Equipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Equipo>()
                .HasMany(e => e.Puntos)
                .WithRequired(e => e.Equipo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estadio>()
                .Property(e => e.Id_estadio)
                .IsUnicode(false);

            modelBuilder.Entity<Estadio>()
                .Property(e => e.Nombre_estadio)
                .IsUnicode(false);

            modelBuilder.Entity<Estadio>()
                .Property(e => e.Capacidad)
                .IsUnicode(false);

            modelBuilder.Entity<Estadio>()
                .Property(e => e.Id_sede)
                .IsUnicode(false);

            modelBuilder.Entity<Estadio>()
                .HasMany(e => e.Partido)
                .WithRequired(e => e.Estadio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Id_factura)
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.id_vaticinio)
                .IsUnicode(false);

            modelBuilder.Entity<Factura>()
                .Property(e => e.Id_participacion)
                .IsUnicode(false);

            modelBuilder.Entity<Fase>()
                .Property(e => e.Id_fase)
                .IsUnicode(false);

            modelBuilder.Entity<Fase>()
                .Property(e => e.Nombre_fase)
                .IsUnicode(false);

            modelBuilder.Entity<Fase>()
                .HasMany(e => e.Partido)
                .WithRequired(e => e.Fase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fecha>()
                .Property(e => e.Id_equipo)
                .IsUnicode(false);

            modelBuilder.Entity<Fecha>()
                .Property(e => e.Id_partido)
                .IsUnicode(false);

            modelBuilder.Entity<Fecha>()
                .Property(e => e.Fecha1)
                .IsUnicode(false);

            modelBuilder.Entity<Fecha>()
                .Property(e => e.Resultado)
                .IsUnicode(false);

            modelBuilder.Entity<Ganador>()
                .Property(e => e.Id_ganador)
                .IsUnicode(false);

            modelBuilder.Entity<Ganador>()
                .Property(e => e.Lugar_ganador)
                .IsUnicode(false);

            modelBuilder.Entity<Ganador>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Ganador>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Ganador>()
                .Property(e => e.Monto_ganado)
                .IsUnicode(false);

            modelBuilder.Entity<Ganadores_individuales>()
                .Property(e => e.Id_gan_ind)
                .IsUnicode(false);

            modelBuilder.Entity<Ganadores_individuales>()
                .Property(e => e.Monto_gan)
                .IsUnicode(false);

            modelBuilder.Entity<Ganadores_individuales>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Ganadores_individuales>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .Property(e => e.Id_grupos)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .Property(e => e.Nombre_grupo)
                .IsUnicode(false);

            modelBuilder.Entity<Grupos>()
                .HasMany(e => e.Equipo)
                .WithRequired(e => e.Grupos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Liga>()
                .Property(e => e.Id_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Liga>()
                .Property(e => e.Nombre_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Liga>()
                .Property(e => e.Puntos_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Ganador)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Ganadores_individuales)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Liga_ganador)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Nombre_distintivo)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Precio_participacion)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga>()
                .HasMany(e => e.Rol)
                .WithRequired(e => e.Liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Liga_ganador>()
                .Property(e => e.Id_liga_gan)
                .IsUnicode(false);

            modelBuilder.Entity<Liga_ganador>()
                .Property(e => e.Monto_ganado)
                .IsUnicode(false);

            modelBuilder.Entity<Liga_ganador>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Mundial>()
                .Property(e => e.Id_mundial)
                .IsUnicode(false);

            modelBuilder.Entity<Mundial>()
                .Property(e => e.Nombre_mundial)
                .IsUnicode(false);

            modelBuilder.Entity<Mundial>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mundial>()
                .Property(e => e.Id_sede)
                .IsUnicode(false);

            modelBuilder.Entity<Nombre_distintivo>()
                .Property(e => e.Id_nom_distintivo)
                .IsUnicode(false);

            modelBuilder.Entity<Nombre_distintivo>()
                .Property(e => e.Id_equipo)
                .IsUnicode(false);

            modelBuilder.Entity<Nombre_distintivo>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Nombre_distintivo>()
                .Property(e => e.Nombre_distintivo1)
                .IsUnicode(false);

            modelBuilder.Entity<Nombre_distintivo>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Id_partido)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Resultado)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Visitante)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Local)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Horario)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Id_estadio)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .Property(e => e.Id_fase)
                .IsUnicode(false);

            modelBuilder.Entity<Partido>()
                .HasMany(e => e.Fecha)
                .WithRequired(e => e.Partido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Partido>()
                .HasMany(e => e.Vaticinio_usuario)
                .WithRequired(e => e.Partido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.CUI)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Precio_participacion>()
                .Property(e => e.Id_participacion)
                .IsUnicode(false);

            modelBuilder.Entity<Precio_participacion>()
                .Property(e => e.Monto)
                .IsUnicode(false);

            modelBuilder.Entity<Precio_participacion>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Precio_participacion>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Precio_participacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Puntos>()
                .Property(e => e.Id_puntos)
                .IsUnicode(false);

            modelBuilder.Entity<Puntos>()
                .Property(e => e.Puntos1)
                .IsUnicode(false);

            modelBuilder.Entity<Puntos>()
                .Property(e => e.Id_equipo)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Id_liga)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Id_tipoRoles)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .Property(e => e.Id_sede)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .Property(e => e.Nombre_sede)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Estadio)
                .WithRequired(e => e.Sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Mundial)
                .WithRequired(e => e.Sede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.id_tarjera)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Tipo_banco)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Fecha_vencimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Fecha_emisión)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Nombre_persona)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Codigo_seguridad)
                .IsUnicode(false);

            modelBuilder.Entity<Tarjeta_credito>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_liga>()
                .Property(e => e.Id_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_liga>()
                .Property(e => e.Nombre_tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_liga>()
                .HasMany(e => e.Liga)
                .WithRequired(e => e.Tipo_liga)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_roles>()
                .Property(e => e.Id_tipoRoles)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_roles>()
                .Property(e => e.Nombre_rol)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_roles>()
                .HasMany(e => e.Rol)
                .WithRequired(e => e.Tipo_roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Id_user)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre_usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Constrasenha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ganador)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ganadores_individuales)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Mundial)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Nombre_distintivo)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Persona)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Rol)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tarjeta_credito)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Vaticinio_usuario)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vaticinio>()
                .Property(e => e.id_vaticinio)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio>()
                .Property(e => e.Fase)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio>()
                .Property(e => e.Evento)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio>()
                .Property(e => e.Pronostico)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio>()
                .HasMany(e => e.Factura)
                .WithRequired(e => e.Vaticinio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vaticinio>()
                .HasMany(e => e.Vaticinio_usuario)
                .WithRequired(e => e.Vaticinio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vaticinio_usuario>()
                .Property(e => e.Id_partido)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio_usuario>()
                .Property(e => e.id_vaticinio)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio_usuario>()
                .Property(e => e.Puntos)
                .IsUnicode(false);

            modelBuilder.Entity<Vaticinio_usuario>()
                .Property(e => e.Id_user)
                .IsUnicode(false);
        }
    }
}
