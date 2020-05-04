using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace I9OpenWebApi.Models
{
    public partial class MegaHackContext : DbContext
    {
        public MegaHackContext()
        {
        }

        public MegaHackContext(DbContextOptions<MegaHackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comercio> Comercio { get; set; }
        public virtual DbSet<Cupom> Cupom { get; set; }
        public virtual DbSet<Plano> Plano { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<TipoComercio> TipoComercio { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1N95O0N;Database=MegaHack;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.HasKey(e => e.IdComercio);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Comercio__AA57D6B44D2EA6EB")
                    .IsUnique();

                entity.Property(e => e.IdComercio).HasColumnName("Id_Comercio");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.FkTipoComercio).HasColumnName("Fk_TipoComercio");

                entity.Property(e => e.FkUsuario).HasColumnName("Fk_Usuario");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneCelular)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefoneFixo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTipoComercioNavigation)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.FkTipoComercio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comercio__Fk_Tip__44FF419A");

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.FkUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comercio__Fk_Usu__440B1D61");
            });

            modelBuilder.Entity<Cupom>(entity =>
            {
                entity.HasKey(e => e.IdCupom);

                entity.Property(e => e.IdCupom).HasColumnName("Id_Cupom");

                entity.Property(e => e.FkComercio).HasColumnName("Fk_Comercio");

                entity.Property(e => e.FkProduto).HasColumnName("Fk_Produto");

                entity.HasOne(d => d.FkComercioNavigation)
                    .WithMany(p => p.Cupom)
                    .HasForeignKey(d => d.FkComercio)
                    .HasConstraintName("FK__Cupom__Fk_Comerc__4BAC3F29");

                entity.HasOne(d => d.FkProdutoNavigation)
                    .WithMany(p => p.Cupom)
                    .HasForeignKey(d => d.FkProduto)
                    .HasConstraintName("FK__Cupom__Fk_Produt__4AB81AF0");
            });

            modelBuilder.Entity<Plano>(entity =>
            {
                entity.HasKey(e => e.IdPlano);

                entity.Property(e => e.IdPlano).HasColumnName("Id_Plano");

                entity.Property(e => e.Fim).HasColumnType("date");

                entity.Property(e => e.FkUsuario).HasColumnName("Fk_Usuario");

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Plano)
                    .HasForeignKey(d => d.FkUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Plano__Fk_Usuari__47DBAE45");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto);

                entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoComercio>(entity =>
            {
                entity.HasKey(e => e.IdTipoComercio);

                entity.Property(e => e.IdTipoComercio).HasColumnName("Id_TipoComercio");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("Id_TipoUsuario");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Usuario__C1FF93094323F634")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534290E95BB")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__Usuario__321537280E137092")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FkTipoUsuario).HasColumnName("Fk_TipoUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.FkTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__Fk_Tipo__403A8C7D");
            });
        }
    }
}
