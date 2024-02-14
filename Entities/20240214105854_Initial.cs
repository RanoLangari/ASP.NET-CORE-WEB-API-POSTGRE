using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_ASP.POSTGRESQL.Entities
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_barang",
                columns: table => new
                {
                    id_barang = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('tbl_baranf_id_barang_seq'::regclass)"),
                    nama_barang = table.Column<string>(type: "text", nullable: true),
                    kategori_barang = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tbl_baranf_pkey", x => x.id_barang);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_barang");
        }
    }
}
