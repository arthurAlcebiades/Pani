using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspCore_Scaffolding.Models;

public partial class PanificadoradbContext : DbContext
{
    public PanificadoradbContext()
    {
    }

    public PanificadoradbContext(DbContextOptions<PanificadoradbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=PANIFICADORADB;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey_ClientID");

            entity.ToTable("TB_CLIENTES");

            entity.Property(e => e.ContatoCliente).HasColumnName("CONTATO_CLIENTE");
            entity.Property(e => e.CpfCnpj).HasColumnName("CPF_CNPJ");
            entity.Property(e => e.EnderecoCliente).HasColumnName("ENDERECO_CLIENTE");
            entity.Property(e => e.NomeCliente).HasColumnName("NOME_CLIENTE");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.NomeUsuario).HasColumnName("NOME_USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
