using System;
using System.Collections.Generic;
using CursosOnline.Domains;
using Microsoft.EntityFrameworkCore;

namespace CursosOnline.Contexts;

public partial class CursosOnlineContext : DbContext
{
    public CursosOnlineContext()
    {
    }

    public CursosOnlineContext(DbContextOptions<CursosOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aluno> Aluno { get; set; }

    public virtual DbSet<Curso> Curso { get; set; }

    public virtual DbSet<Instrutor> Instrutor { get; set; }

    public virtual DbSet<Matricula> Matricula { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CursosOnline;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aluno>(entity =>
        {
            entity.HasKey(e => e.AlunoID).HasName("PK__Aluno__C1967C6FAEC0B4E9");

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
            entity.Property(e => e.StatusAluno).HasDefaultValue(true);
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoID).HasName("PK__Curso__7E023A376DA69454");

            entity.Property(e => e.CargaHoraria)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DisponibilidadeCurso).HasDefaultValue(true);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.Instrutor).WithMany(p => p.Curso)
                .HasForeignKey(d => d.InstrutorID)
                .HasConstraintName("FK__Curso__Instrutor__628FA481");
        });

        modelBuilder.Entity<Instrutor>(entity =>
        {
            entity.HasKey(e => e.InstrutorID).HasName("PK__Instruto__096B84F48F69EFD4");

            entity.Property(e => e.AreaEspecializacao)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.MatriculaID).HasName("PK__Matricul__908CEE2232E216FF");

            entity.Property(e => e.DataMatricula)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Aluno).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.AlunoID)
                .HasConstraintName("FK__Matricula__Aluno__66603565");

            entity.HasOne(d => d.Curso).WithMany(p => p.Matricula)
                .HasForeignKey(d => d.CursoID)
                .HasConstraintName("FK__Matricula__Curso__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
