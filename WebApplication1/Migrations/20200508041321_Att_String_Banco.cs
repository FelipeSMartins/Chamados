using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication1.Migrations
{
    public partial class Att_String_Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    cat_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cat_nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("categoria_pkey", x => x.cat_id);
                });

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    dep_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dep_nome = table.Column<string>(maxLength: 50, nullable: false),
                    dep_email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("departamento_pkey", x => x.dep_id);
                });

            migrationBuilder.CreateTable(
                name: "organizacao",
                columns: table => new
                {
                    org_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    org_nome = table.Column<string>(maxLength: 50, nullable: false),
                    org_cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    org_email = table.Column<string>(maxLength: 100, nullable: false),
                    org_telefone = table.Column<string>(maxLength: 40, nullable: false),
                    org_endereco = table.Column<string>(maxLength: 100, nullable: true),
                    org_situacao = table.Column<char>(nullable: true),
                    org_obs = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("organizacao_pkey", x => x.org_id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    pes_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pes_nome = table.Column<string>(maxLength: 50, nullable: false),
                    pes_email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pessoa_pkey", x => x.pes_id);
                });

            migrationBuilder.CreateTable(
                name: "prioridade",
                columns: table => new
                {
                    pri_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pri_nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("prioridade_pkey", x => x.pri_id);
                });

            migrationBuilder.CreateTable(
                name: "status_chamado",
                columns: table => new
                {
                    scha_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    scha_nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_chamado_pkey", x => x.scha_id);
                });

            migrationBuilder.CreateTable(
                name: "departamento_categoria",
                columns: table => new
                {
                    dc_departamentoid = table.Column<int>(nullable: false),
                    dc_categoriaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("departamento_categoria_pkey", x => new { x.dc_departamentoid, x.dc_categoriaid });
                    table.ForeignKey(
                        name: "departamento_categoria_dc_categoriaid_fkey",
                        column: x => x.dc_categoriaid,
                        principalTable: "categoria",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "departamento_categoria_dc_departamentoid_fkey",
                        column: x => x.dc_departamentoid,
                        principalTable: "departamento",
                        principalColumn: "dep_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "atendente",
                columns: table => new
                {
                    ate_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ate_pessoaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("atendente_pkey", x => x.ate_id);
                    table.ForeignKey(
                        name: "atendente_ate_pessoaid_fkey",
                        column: x => x.ate_pessoaid,
                        principalTable: "pessoa",
                        principalColumn: "pes_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cli_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cli_pessoaid = table.Column<int>(nullable: false),
                    cli_organizacaoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cliente_pkey", x => x.cli_id);
                    table.ForeignKey(
                        name: "cliente_cli_organizacaoid_fkey",
                        column: x => x.cli_organizacaoid,
                        principalTable: "organizacao",
                        principalColumn: "org_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "cliente_cli_pessoaid_fkey",
                        column: x => x.cli_pessoaid,
                        principalTable: "pessoa",
                        principalColumn: "pes_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "departamento_atendente",
                columns: table => new
                {
                    da_departamentoid = table.Column<int>(nullable: false),
                    da_atendenteid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("departamento_atendente_pkey", x => new { x.da_departamentoid, x.da_atendenteid });
                    table.ForeignKey(
                        name: "departamento_atendente_da_atendenteid_fkey",
                        column: x => x.da_atendenteid,
                        principalTable: "atendente",
                        principalColumn: "ate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "departamento_atendente_da_departamentoid_fkey",
                        column: x => x.da_departamentoid,
                        principalTable: "departamento",
                        principalColumn: "dep_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chamado",
                columns: table => new
                {
                    cha_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cha_titulo = table.Column<string>(maxLength: 50, nullable: false),
                    cha_assunto = table.Column<string>(maxLength: 100, nullable: true),
                    cha_descricao = table.Column<string>(maxLength: 999, nullable: false),
                    cha_clienteid = table.Column<int>(nullable: false),
                    cha_atendenteid = table.Column<int>(nullable: false),
                    cha_departamentoid = table.Column<int>(nullable: false),
                    cha_categoriaid = table.Column<int>(nullable: false),
                    cha_prioridadeid = table.Column<int>(nullable: false),
                    cha_statusid = table.Column<int>(nullable: false),
                    cha_data = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "CURRENT_DATE"),
                    cha_criador = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chamado_pkey", x => x.cha_id);
                    table.ForeignKey(
                        name: "chamado_cha_atendenteid_fkey",
                        column: x => x.cha_atendenteid,
                        principalTable: "atendente",
                        principalColumn: "ate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chamado_cha_categoriaid_fkey",
                        column: x => x.cha_categoriaid,
                        principalTable: "categoria",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chamado_cha_clienteid_fkey",
                        column: x => x.cha_clienteid,
                        principalTable: "cliente",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chamado_cha_departamentoid_fkey",
                        column: x => x.cha_departamentoid,
                        principalTable: "departamento",
                        principalColumn: "dep_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chamado_cha_prioridadeid_fkey",
                        column: x => x.cha_prioridadeid,
                        principalTable: "prioridade",
                        principalColumn: "pri_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "chamado_cha_statusid_fkey",
                        column: x => x.cha_statusid,
                        principalTable: "status_chamado",
                        principalColumn: "scha_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "acao_chamado",
                columns: table => new
                {
                    acao_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    acao_chamadoid = table.Column<int>(nullable: false),
                    acao_descricao = table.Column<string>(maxLength: 255, nullable: false),
                    acao_atendenteid = table.Column<int>(nullable: false),
                    acao_departamentoid = table.Column<int>(nullable: false),
                    acao_categoriaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("acao_chamado_pkey", x => x.acao_id);
                    table.ForeignKey(
                        name: "acao_chamado_acao_atendenteid_fkey",
                        column: x => x.acao_atendenteid,
                        principalTable: "atendente",
                        principalColumn: "ate_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "acao_chamado_acao_categoriaid_fkey",
                        column: x => x.acao_categoriaid,
                        principalTable: "categoria",
                        principalColumn: "cat_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "acao_chamado_acao_chamadoid_fkey",
                        column: x => x.acao_chamadoid,
                        principalTable: "chamado",
                        principalColumn: "cha_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "acao_chamado_acao_departamentoid_fkey",
                        column: x => x.acao_departamentoid,
                        principalTable: "departamento",
                        principalColumn: "dep_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_acao_chamado_acao_atendenteid",
                table: "acao_chamado",
                column: "acao_atendenteid");

            migrationBuilder.CreateIndex(
                name: "IX_acao_chamado_acao_categoriaid",
                table: "acao_chamado",
                column: "acao_categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_acao_chamado_acao_chamadoid",
                table: "acao_chamado",
                column: "acao_chamadoid");

            migrationBuilder.CreateIndex(
                name: "IX_acao_chamado_acao_departamentoid",
                table: "acao_chamado",
                column: "acao_departamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_atendente_ate_pessoaid",
                table: "atendente",
                column: "ate_pessoaid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_atendenteid",
                table: "chamado",
                column: "cha_atendenteid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_categoriaid",
                table: "chamado",
                column: "cha_categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_clienteid",
                table: "chamado",
                column: "cha_clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_departamentoid",
                table: "chamado",
                column: "cha_departamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_prioridadeid",
                table: "chamado",
                column: "cha_prioridadeid");

            migrationBuilder.CreateIndex(
                name: "IX_chamado_cha_statusid",
                table: "chamado",
                column: "cha_statusid");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cli_organizacaoid",
                table: "cliente",
                column: "cli_organizacaoid");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cli_pessoaid",
                table: "cliente",
                column: "cli_pessoaid");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_atendente_da_atendenteid",
                table: "departamento_atendente",
                column: "da_atendenteid");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_categoria_dc_categoriaid",
                table: "departamento_categoria",
                column: "dc_categoriaid");

            migrationBuilder.CreateIndex(
                name: "organizacao_org_cnpj_key",
                table: "organizacao",
                column: "org_cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "pessoa_pes_email_key",
                table: "pessoa",
                column: "pes_email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acao_chamado");

            migrationBuilder.DropTable(
                name: "departamento_atendente");

            migrationBuilder.DropTable(
                name: "departamento_categoria");

            migrationBuilder.DropTable(
                name: "chamado");

            migrationBuilder.DropTable(
                name: "atendente");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "prioridade");

            migrationBuilder.DropTable(
                name: "status_chamado");

            migrationBuilder.DropTable(
                name: "organizacao");

            migrationBuilder.DropTable(
                name: "pessoa");
        }
    }
}
