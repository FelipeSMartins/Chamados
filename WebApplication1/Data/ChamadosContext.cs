using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1
{
    public partial class ChamadosContext : DbContext
    {
        public ChamadosContext()
        {
        }

        public ChamadosContext(DbContextOptions<ChamadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcaoChamado> AcaoChamado { get; set; }
        public virtual DbSet<Atendente> Atendente { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Chamado> Chamado { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<DepartamentoAtendente> DepartamentoAtendente { get; set; }
        public virtual DbSet<DepartamentoCategoria> DepartamentoCategoria { get; set; }
        public virtual DbSet<Organizacao> Organizacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Prioridade> Prioridade { get; set; }
        public virtual DbSet<StatusChamado> StatusChamado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcaoChamado>(entity =>
            {
                entity.HasKey(e => e.AcaoId)
                    .HasName("acao_chamado_pkey");

                entity.ToTable("acao_chamado");

                entity.Property(e => e.AcaoId).HasColumnName("acao_id");

                entity.Property(e => e.AcaoAtendenteid).HasColumnName("acao_atendenteid");

                entity.Property(e => e.AcaoCategoriaid).HasColumnName("acao_categoriaid");

                entity.Property(e => e.AcaoChamadoid).HasColumnName("acao_chamadoid");

                entity.Property(e => e.AcaoDepartamentoid).HasColumnName("acao_departamentoid");

                entity.Property(e => e.AcaoDescricao)
                    .IsRequired()
                    .HasColumnName("acao_descricao")
                    .HasMaxLength(255);

                entity.HasOne(d => d.AcaoAtendente)
                    .WithMany(p => p.AcaoChamado)
                    .HasForeignKey(d => d.AcaoAtendenteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acao_chamado_acao_atendenteid_fkey");

                entity.HasOne(d => d.AcaoCategoria)
                    .WithMany(p => p.AcaoChamado)
                    .HasForeignKey(d => d.AcaoCategoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acao_chamado_acao_categoriaid_fkey");

                entity.HasOne(d => d.AcaoChamadoNavigation)
                    .WithMany(p => p.AcaoChamado)
                    .HasForeignKey(d => d.AcaoChamadoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acao_chamado_acao_chamadoid_fkey");

                entity.HasOne(d => d.AcaoDepartamento)
                    .WithMany(p => p.AcaoChamado)
                    .HasForeignKey(d => d.AcaoDepartamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("acao_chamado_acao_departamentoid_fkey");
            });

            modelBuilder.Entity<Atendente>(entity =>
            {
                entity.HasKey(e => e.AteId)
                    .HasName("atendente_pkey");

                entity.ToTable("atendente");

                entity.Property(e => e.AteId).HasColumnName("ate_id");

                entity.Property(e => e.AtePessoaid).HasColumnName("ate_pessoaid");

                entity.HasOne(d => d.AtePessoa)
                    .WithMany(p => p.Atendente)
                    .HasForeignKey(d => d.AtePessoaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atendente_ate_pessoaid_fkey");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("categoria_pkey");

                entity.ToTable("categoria");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.CatNome)
                    .IsRequired()
                    .HasColumnName("cat_nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Chamado>(entity =>
            {
                entity.HasKey(e => e.ChaId)
                    .HasName("chamado_pkey");

                entity.ToTable("chamado");

                entity.Property(e => e.ChaId).HasColumnName("cha_id");

                entity.Property(e => e.ChaAssunto)
                    .HasColumnName("cha_assunto")
                    .HasMaxLength(100);

                entity.Property(e => e.ChaAtendenteid).HasColumnName("cha_atendenteid");

                entity.Property(e => e.ChaCategoriaid).HasColumnName("cha_categoriaid");

                entity.Property(e => e.ChaClienteid).HasColumnName("cha_clienteid");

                entity.Property(e => e.ChaCriador)
                    .IsRequired()
                    .HasColumnName("cha_criador")
                    .HasMaxLength(100);

                entity.Property(e => e.ChaData)
                    .HasColumnName("cha_data")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.ChaDepartamentoid).HasColumnName("cha_departamentoid");

                entity.Property(e => e.ChaDescricao)
                    .IsRequired()
                    .HasColumnName("cha_descricao")
                    .HasMaxLength(999);

                entity.Property(e => e.ChaPrioridadeid).HasColumnName("cha_prioridadeid");

                entity.Property(e => e.ChaStatusid).HasColumnName("cha_statusid");

                entity.Property(e => e.ChaTitulo)
                    .IsRequired()
                    .HasColumnName("cha_titulo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ChaAtendente)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaAtendenteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_atendenteid_fkey");

                entity.HasOne(d => d.ChaCategoria)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaCategoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_categoriaid_fkey");

                entity.HasOne(d => d.ChaCliente)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaClienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_clienteid_fkey");

                entity.HasOne(d => d.ChaDepartamento)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaDepartamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_departamentoid_fkey");

                entity.HasOne(d => d.ChaPrioridade)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaPrioridadeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_prioridadeid_fkey");

                entity.HasOne(d => d.ChaStatus)
                    .WithMany(p => p.Chamado)
                    .HasForeignKey(d => d.ChaStatusid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("chamado_cha_statusid_fkey");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CliId)
                    .HasName("cliente_pkey");

                entity.ToTable("cliente");

                entity.Property(e => e.CliId).HasColumnName("cli_id");

                entity.Property(e => e.CliOrganizacaoid).HasColumnName("cli_organizacaoid");

                entity.Property(e => e.CliPessoaid).HasColumnName("cli_pessoaid");

                entity.HasOne(d => d.CliOrganizacao)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CliOrganizacaoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_cli_organizacaoid_fkey");

                entity.HasOne(d => d.CliPessoa)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.CliPessoaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cliente_cli_pessoaid_fkey");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("departamento_pkey");

                entity.ToTable("departamento");

                entity.Property(e => e.DepId).HasColumnName("dep_id");

                entity.Property(e => e.DepEmail)
                    .IsRequired()
                    .HasColumnName("dep_email")
                    .HasMaxLength(100);

                entity.Property(e => e.DepNome)
                    .IsRequired()
                    .HasColumnName("dep_nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DepartamentoAtendente>(entity =>
            {
                entity.HasKey(e => new { e.DaDepartamentoid, e.DaAtendenteid })
                    .HasName("departamento_atendente_pkey");

                entity.ToTable("departamento_atendente");

                entity.Property(e => e.DaDepartamentoid).HasColumnName("da_departamentoid");

                entity.Property(e => e.DaAtendenteid).HasColumnName("da_atendenteid");

                entity.HasOne(d => d.DaAtendente)
                    .WithMany(p => p.DepartamentoAtendente)
                    .HasForeignKey(d => d.DaAtendenteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departamento_atendente_da_atendenteid_fkey");

                entity.HasOne(d => d.DaDepartamento)
                    .WithMany(p => p.DepartamentoAtendente)
                    .HasForeignKey(d => d.DaDepartamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departamento_atendente_da_departamentoid_fkey");
            });

            modelBuilder.Entity<DepartamentoCategoria>(entity =>
            {
                entity.HasKey(e => new { e.DcDepartamentoid, e.DcCategoriaid })
                    .HasName("departamento_categoria_pkey");

                entity.ToTable("departamento_categoria");

                entity.Property(e => e.DcDepartamentoid).HasColumnName("dc_departamentoid");

                entity.Property(e => e.DcCategoriaid).HasColumnName("dc_categoriaid");

                entity.HasOne(d => d.DcCategoria)
                    .WithMany(p => p.DepartamentoCategoria)
                    .HasForeignKey(d => d.DcCategoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departamento_categoria_dc_categoriaid_fkey");

                entity.HasOne(d => d.DcDepartamento)
                    .WithMany(p => p.DepartamentoCategoria)
                    .HasForeignKey(d => d.DcDepartamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("departamento_categoria_dc_departamentoid_fkey");
            });

            modelBuilder.Entity<Organizacao>(entity =>
            {
                entity.HasKey(e => e.OrgId)
                    .HasName("organizacao_pkey");

                entity.ToTable("organizacao");

                entity.HasIndex(e => e.OrgCnpj)
                    .HasName("organizacao_org_cnpj_key")
                    .IsUnique();

                entity.Property(e => e.OrgId).HasColumnName("org_id");

                entity.Property(e => e.OrgCnpj)
                    .IsRequired()
                    .HasColumnName("org_cnpj")
                    .HasMaxLength(14);

                entity.Property(e => e.OrgEmail)
                    .IsRequired()
                    .HasColumnName("org_email")
                    .HasMaxLength(100);

                entity.Property(e => e.OrgEndereco)
                    .HasColumnName("org_endereco")
                    .HasMaxLength(100);

                entity.Property(e => e.OrgNome)
                    .IsRequired()
                    .HasColumnName("org_nome")
                    .HasMaxLength(50);

                entity.Property(e => e.OrgObs)
                    .HasColumnName("org_obs")
                    .HasMaxLength(255);

                entity.Property(e => e.OrgSituacao).HasColumnName("org_situacao");

                entity.Property(e => e.OrgTelefone)
                    .IsRequired()
                    .HasColumnName("org_telefone")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.PesId)
                    .HasName("pessoa_pkey");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.PesEmail)
                    .HasName("pessoa_pes_email_key")
                    .IsUnique();

                entity.Property(e => e.PesId).HasColumnName("pes_id");

                entity.Property(e => e.PesEmail)
                    .IsRequired()
                    .HasColumnName("pes_email")
                    .HasMaxLength(100);

                entity.Property(e => e.PesNome)
                    .IsRequired()
                    .HasColumnName("pes_nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prioridade>(entity =>
            {
                entity.HasKey(e => e.PriId)
                    .HasName("prioridade_pkey");

                entity.ToTable("prioridade");

                entity.Property(e => e.PriId).HasColumnName("pri_id");

                entity.Property(e => e.PriNome)
                    .IsRequired()
                    .HasColumnName("pri_nome")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StatusChamado>(entity =>
            {
                entity.HasKey(e => e.SchaId)
                    .HasName("status_chamado_pkey");

                entity.ToTable("status_chamado");

                entity.Property(e => e.SchaId).HasColumnName("scha_id");

                entity.Property(e => e.SchaNome)
                    .IsRequired()
                    .HasColumnName("scha_nome")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
