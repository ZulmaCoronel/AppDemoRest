using System;
using AppDemoREST.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDemoREST.Data
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options) : base(options)
        {
            //CONSTRUCTOR
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {
            }
            catch (Exception e)
            {
            }//CONFIGURACION DE LA CONEXION
        }

        //Gestion de Inventarios
        public DbSet<zt_cat_estatus> zt_cat_estatus { get; set; }
        public DbSet<zt_cat_cedis> zt_cat_cedis { get; set; }
        public DbSet<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public DbSet<zt_inventarios> zt_inventarios { get; set; }
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        //Catalogos Unidades de Medida
        public DbSet<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public DbSet<zt_cat_productos> zt_cat_productos { get; set; }
        public DbSet<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public DbSet<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        //Catalogo CEDIS y Almacenes
        public DbSet<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public DbSet<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                // #endregion

                #region INVENTARIOS
                /*CREACION DE LLAVES PRIMARIAS*/
                modelBuilder.Entity<zt_cat_cedis>()
                    .HasKey(c => new { c.IdCEDI });

                modelBuilder.Entity<zt_cat_almacenes>()
                    .HasKey(c => new { c.IdAlmacen });

                modelBuilder.Entity<zt_cat_grupos_sku>()
                    .HasKey(c => new { c.IdGrupoSKU });

                modelBuilder.Entity<zt_cat_productos>()
                    .HasKey(c => new { c.IdSKU });

                modelBuilder.Entity<zt_cat_unidad_medidas>()
                    .HasKey(c => new { c.IdUnidadMedida });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                    .HasKey(c => new { c.IdAlmacen, c.IdUbicacion });

                modelBuilder.Entity<zt_cat_estatus>()
                    .HasKey(c => new { c.IdEstatus });

                modelBuilder.Entity<zt_inventarios>()
                    .HasKey(c => new { c.IdInventario });

                modelBuilder.Entity<zt_cat_ubicaciones>()
                    .HasKey(c => new { c.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>()
                    .HasKey(c => new { c.NumConteo, c.IdInventario, c.IdAlmacen, c.IdSKU, c.IdUnidadMedida, c.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.NumConteo).IsUnique(false);

                modelBuilder.Entity<zt_cat_productos_medidas>()
                    .HasKey(c => new { c.IdSKU, c.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                   .HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida });

                /*CREACION DE LLAVES FORANEAS*/
                modelBuilder.Entity<zt_cat_almacenes>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_estatus).
                WithMany().HasForeignKey(s => new { s.IdEstatus });

                modelBuilder.Entity<zt_cat_productos>()
                .HasOne(s => s.zt_cat_grupos_sku).
                WithMany().HasForeignKey(s => new { s.IdGrupoSKU });

                modelBuilder.Entity<zt_cat_productos>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUMedidaBase });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                .HasOne(s => s.zt_cat_ubicaciones).
                WithMany().HasForeignKey(s => new { s.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_ubicaciones).
                WithMany().HasForeignKey(s => new { s.IdUbicacion });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_acumulados>()

                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });
                #endregion
            }
            catch (Exception e)
            {
                //Alerta
            }
        }//Configuration of the model

    }//CLASS
}
