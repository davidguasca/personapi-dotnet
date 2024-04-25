﻿using Microsoft.EntityFrameworkCore;

namespace personapi_donet.Models
{
    public partial class labdbContext : DbContext
    {
        public labdbContext()
        {
        }

        public labdbContext(DbContextOptions<labdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudio> Estudios { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Profesion> Profesions { get; set; } = null!;
        public virtual DbSet<Telefono> Telefonos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NOVAGUA\\SQLEXPRESS;Database=lab-db;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => new { e.IdProf, e.CcPer })
                    .HasName("PK__estudios__FB3F71A6F487F0A2");

                entity.ToTable("estudios");

                entity.Property(e => e.IdProf).HasColumnName("id_prof");

                entity.Property(e => e.CcPer).HasColumnName("cc_per");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Univer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("univer");

                entity.HasOne(d => d.CcPerNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.CcPer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudios__cc_per__3D5E1FD2");

                entity.HasOne(d => d.IdProfNavigation)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.IdProf)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estudios__id_pro__3C69FB99");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Cc)
                    .HasName("PK__persona__3213666D0D11D4FF");

                entity.ToTable("persona");

                entity.Property(e => e.Cc)
                    .ValueGeneratedNever()
                    .HasColumnName("cc");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("genero")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.ToTable("profesion");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Des)
                    .HasColumnType("text")
                    .HasColumnName("des");

                entity.Property(e => e.Nom)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("nom");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__telefono__DF908D65FB75B395");

                entity.ToTable("telefono");

                entity.Property(e => e.Num)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("num");

                entity.Property(e => e.Duenio).HasColumnName("duenio");

                entity.Property(e => e.Oper)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("oper");

                entity.HasOne(d => d.DuenioNavigation)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.Duenio)
                    .HasConstraintName("FK__telefono__duenio__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
