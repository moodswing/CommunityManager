﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CommunityManager.Models;

namespace CommunityManager.DataAccessLayer
{
    public class CommunityContext : DbContext
    {
        public CommunityContext() : base("CommunityContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        public DbSet<PublicacionVista> PublicacionesVistas { get; set; }
        public DbSet<PublicacionSeguida> PublicacionesSeguidas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>()
            //.HasMany(f => f.PublicacionesVistas)
            //.WithRequired()
            //.WillCascadeOnDelete(false);

            modelBuilder.Entity<PublicacionVista>()
            .HasRequired(f => f.Usuario)
            .WithMany()
            .HasForeignKey(f => f.UsuarioID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublicacionSeguida>()
            .HasRequired(f => f.Usuario)
            .WithMany()
            .HasForeignKey(f => f.UsuarioID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comentario>()
            .HasRequired(f => f.Publicacion)
            //.WithMany()
            .WithMany(f => f.Comentarios)
            .HasForeignKey(f => f.PublicacionId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comentario>()
            .HasRequired(f => f.Usuario)
            .WithMany()
            .HasForeignKey(f => f.UsuarioId)
            .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}