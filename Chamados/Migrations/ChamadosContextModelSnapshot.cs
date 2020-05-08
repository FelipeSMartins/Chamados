﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ChamadosContext))]
    partial class ChamadosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApplication1.AcaoChamado", b =>
                {
                    b.Property<int>("AcaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("acao_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AcaoAtendenteid")
                        .HasColumnName("acao_atendenteid")
                        .HasColumnType("integer");

                    b.Property<int>("AcaoCategoriaid")
                        .HasColumnName("acao_categoriaid")
                        .HasColumnType("integer");

                    b.Property<int>("AcaoChamadoid")
                        .HasColumnName("acao_chamadoid")
                        .HasColumnType("integer");

                    b.Property<int>("AcaoDepartamentoid")
                        .HasColumnName("acao_departamentoid")
                        .HasColumnType("integer");

                    b.Property<string>("AcaoDescricao")
                        .IsRequired()
                        .HasColumnName("acao_descricao")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("AcaoId")
                        .HasName("acao_chamado_pkey");

                    b.HasIndex("AcaoAtendenteid");

                    b.HasIndex("AcaoCategoriaid");

                    b.HasIndex("AcaoChamadoid");

                    b.HasIndex("AcaoDepartamentoid");

                    b.ToTable("acao_chamado");
                });

            modelBuilder.Entity("WebApplication1.Atendente", b =>
                {
                    b.Property<int>("AteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ate_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AtePessoaid")
                        .HasColumnName("ate_pessoaid")
                        .HasColumnType("integer");

                    b.HasKey("AteId")
                        .HasName("atendente_pkey");

                    b.HasIndex("AtePessoaid");

                    b.ToTable("atendente");
                });

            modelBuilder.Entity("WebApplication1.Categoria", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cat_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CatNome")
                        .IsRequired()
                        .HasColumnName("cat_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("CatId")
                        .HasName("categoria_pkey");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("WebApplication1.Chamado", b =>
                {
                    b.Property<int>("ChaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cha_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ChaAssunto")
                        .HasColumnName("cha_assunto")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<int>("ChaAtendenteid")
                        .HasColumnName("cha_atendenteid")
                        .HasColumnType("integer");

                    b.Property<int>("ChaCategoriaid")
                        .HasColumnName("cha_categoriaid")
                        .HasColumnType("integer");

                    b.Property<int>("ChaClienteid")
                        .HasColumnName("cha_clienteid")
                        .HasColumnType("integer");

                    b.Property<string>("ChaCriador")
                        .IsRequired()
                        .HasColumnName("cha_criador")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ChaData")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cha_data")
                        .HasColumnType("date")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<int>("ChaDepartamentoid")
                        .HasColumnName("cha_departamentoid")
                        .HasColumnType("integer");

                    b.Property<string>("ChaDescricao")
                        .IsRequired()
                        .HasColumnName("cha_descricao")
                        .HasColumnType("character varying(999)")
                        .HasMaxLength(999);

                    b.Property<int>("ChaPrioridadeid")
                        .HasColumnName("cha_prioridadeid")
                        .HasColumnType("integer");

                    b.Property<int>("ChaStatusid")
                        .HasColumnName("cha_statusid")
                        .HasColumnType("integer");

                    b.Property<string>("ChaTitulo")
                        .IsRequired()
                        .HasColumnName("cha_titulo")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("ChaId")
                        .HasName("chamado_pkey");

                    b.HasIndex("ChaAtendenteid");

                    b.HasIndex("ChaCategoriaid");

                    b.HasIndex("ChaClienteid");

                    b.HasIndex("ChaDepartamentoid");

                    b.HasIndex("ChaPrioridadeid");

                    b.HasIndex("ChaStatusid");

                    b.ToTable("chamado");
                });

            modelBuilder.Entity("WebApplication1.Cliente", b =>
                {
                    b.Property<int>("CliId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cli_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CliOrganizacaoid")
                        .HasColumnName("cli_organizacaoid")
                        .HasColumnType("integer");

                    b.Property<int>("CliPessoaid")
                        .HasColumnName("cli_pessoaid")
                        .HasColumnType("integer");

                    b.HasKey("CliId")
                        .HasName("cliente_pkey");

                    b.HasIndex("CliOrganizacaoid");

                    b.HasIndex("CliPessoaid");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("WebApplication1.Departamento", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("dep_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DepEmail")
                        .IsRequired()
                        .HasColumnName("dep_email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DepNome")
                        .IsRequired()
                        .HasColumnName("dep_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("DepId")
                        .HasName("departamento_pkey");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("WebApplication1.DepartamentoAtendente", b =>
                {
                    b.Property<int>("DaDepartamentoid")
                        .HasColumnName("da_departamentoid")
                        .HasColumnType("integer");

                    b.Property<int>("DaAtendenteid")
                        .HasColumnName("da_atendenteid")
                        .HasColumnType("integer");

                    b.HasKey("DaDepartamentoid", "DaAtendenteid")
                        .HasName("departamento_atendente_pkey");

                    b.HasIndex("DaAtendenteid");

                    b.ToTable("departamento_atendente");
                });

            modelBuilder.Entity("WebApplication1.DepartamentoCategoria", b =>
                {
                    b.Property<int>("DcDepartamentoid")
                        .HasColumnName("dc_departamentoid")
                        .HasColumnType("integer");

                    b.Property<int>("DcCategoriaid")
                        .HasColumnName("dc_categoriaid")
                        .HasColumnType("integer");

                    b.HasKey("DcDepartamentoid", "DcCategoriaid")
                        .HasName("departamento_categoria_pkey");

                    b.HasIndex("DcCategoriaid");

                    b.ToTable("departamento_categoria");
                });

            modelBuilder.Entity("WebApplication1.Organizacao", b =>
                {
                    b.Property<int>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("org_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("OrgCnpj")
                        .IsRequired()
                        .HasColumnName("org_cnpj")
                        .HasColumnType("character varying(14)")
                        .HasMaxLength(14);

                    b.Property<string>("OrgEmail")
                        .IsRequired()
                        .HasColumnName("org_email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OrgEndereco")
                        .HasColumnName("org_endereco")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("OrgNome")
                        .IsRequired()
                        .HasColumnName("org_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OrgObs")
                        .HasColumnName("org_obs")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<char?>("OrgSituacao")
                        .HasColumnName("org_situacao")
                        .HasColumnType("character(1)");

                    b.Property<string>("OrgTelefone")
                        .IsRequired()
                        .HasColumnName("org_telefone")
                        .HasColumnType("character varying(40)")
                        .HasMaxLength(40);

                    b.HasKey("OrgId")
                        .HasName("organizacao_pkey");

                    b.HasIndex("OrgCnpj")
                        .IsUnique()
                        .HasName("organizacao_org_cnpj_key");

                    b.ToTable("organizacao");
                });

            modelBuilder.Entity("WebApplication1.Pessoa", b =>
                {
                    b.Property<int>("PesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pes_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PesEmail")
                        .IsRequired()
                        .HasColumnName("pes_email")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PesNome")
                        .IsRequired()
                        .HasColumnName("pes_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("PesId")
                        .HasName("pessoa_pkey");

                    b.HasIndex("PesEmail")
                        .IsUnique()
                        .HasName("pessoa_pes_email_key");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("WebApplication1.Prioridade", b =>
                {
                    b.Property<int>("PriId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pri_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PriNome")
                        .IsRequired()
                        .HasColumnName("pri_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("PriId")
                        .HasName("prioridade_pkey");

                    b.ToTable("prioridade");
                });

            modelBuilder.Entity("WebApplication1.StatusChamado", b =>
                {
                    b.Property<int>("SchaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("scha_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SchaNome")
                        .IsRequired()
                        .HasColumnName("scha_nome")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("SchaId")
                        .HasName("status_chamado_pkey");

                    b.ToTable("status_chamado");
                });

            modelBuilder.Entity("WebApplication1.AcaoChamado", b =>
                {
                    b.HasOne("WebApplication1.Atendente", "AcaoAtendente")
                        .WithMany("AcaoChamado")
                        .HasForeignKey("AcaoAtendenteid")
                        .HasConstraintName("acao_chamado_acao_atendenteid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Categoria", "AcaoCategoria")
                        .WithMany("AcaoChamado")
                        .HasForeignKey("AcaoCategoriaid")
                        .HasConstraintName("acao_chamado_acao_categoriaid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Chamado", "AcaoChamadoNavigation")
                        .WithMany("AcaoChamado")
                        .HasForeignKey("AcaoChamadoid")
                        .HasConstraintName("acao_chamado_acao_chamadoid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Departamento", "AcaoDepartamento")
                        .WithMany("AcaoChamado")
                        .HasForeignKey("AcaoDepartamentoid")
                        .HasConstraintName("acao_chamado_acao_departamentoid_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Atendente", b =>
                {
                    b.HasOne("WebApplication1.Pessoa", "AtePessoa")
                        .WithMany("Atendente")
                        .HasForeignKey("AtePessoaid")
                        .HasConstraintName("atendente_ate_pessoaid_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Chamado", b =>
                {
                    b.HasOne("WebApplication1.Atendente", "ChaAtendente")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaAtendenteid")
                        .HasConstraintName("chamado_cha_atendenteid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Categoria", "ChaCategoria")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaCategoriaid")
                        .HasConstraintName("chamado_cha_categoriaid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Cliente", "ChaCliente")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaClienteid")
                        .HasConstraintName("chamado_cha_clienteid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Departamento", "ChaDepartamento")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaDepartamentoid")
                        .HasConstraintName("chamado_cha_departamentoid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Prioridade", "ChaPrioridade")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaPrioridadeid")
                        .HasConstraintName("chamado_cha_prioridadeid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.StatusChamado", "ChaStatus")
                        .WithMany("Chamado")
                        .HasForeignKey("ChaStatusid")
                        .HasConstraintName("chamado_cha_statusid_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Cliente", b =>
                {
                    b.HasOne("WebApplication1.Organizacao", "CliOrganizacao")
                        .WithMany("Cliente")
                        .HasForeignKey("CliOrganizacaoid")
                        .HasConstraintName("cliente_cli_organizacaoid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Pessoa", "CliPessoa")
                        .WithMany("Cliente")
                        .HasForeignKey("CliPessoaid")
                        .HasConstraintName("cliente_cli_pessoaid_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.DepartamentoAtendente", b =>
                {
                    b.HasOne("WebApplication1.Atendente", "DaAtendente")
                        .WithMany("DepartamentoAtendente")
                        .HasForeignKey("DaAtendenteid")
                        .HasConstraintName("departamento_atendente_da_atendenteid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Departamento", "DaDepartamento")
                        .WithMany("DepartamentoAtendente")
                        .HasForeignKey("DaDepartamentoid")
                        .HasConstraintName("departamento_atendente_da_departamentoid_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.DepartamentoCategoria", b =>
                {
                    b.HasOne("WebApplication1.Categoria", "DcCategoria")
                        .WithMany("DepartamentoCategoria")
                        .HasForeignKey("DcCategoriaid")
                        .HasConstraintName("departamento_categoria_dc_categoriaid_fkey")
                        .IsRequired();

                    b.HasOne("WebApplication1.Departamento", "DcDepartamento")
                        .WithMany("DepartamentoCategoria")
                        .HasForeignKey("DcDepartamentoid")
                        .HasConstraintName("departamento_categoria_dc_departamentoid_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
