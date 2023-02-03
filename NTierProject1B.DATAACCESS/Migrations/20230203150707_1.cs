using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierProject1B.DATAACCESS.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OluşturulmaZamanı = table.Column<DateTime>(name: "Oluşturulma Zamanı", type: "timestamp with time zone", nullable: false),
                    OluşturanIp = table.Column<string>(name: "Oluşturan Ip", type: "text", nullable: true),
                    OluşturanKişi = table.Column<string>(name: "Oluşturan Kişi", type: "text", nullable: true),
                    OluşturanınBilgisayarAdı = table.Column<string>(name: "Oluşturanın Bilgisayar Adı", type: "text", nullable: true),
                    OluşturanYöneticiAdı = table.Column<string>(name: "Oluşturan Yönetici Adı", type: "text", nullable: true),
                    OluşturanınBilgisayarınınDomainAdı = table.Column<string>(name: "Oluşturanın Bilgisayarının Domain Adı", type: "text", nullable: true),
                    GüncelleyenZamanı = table.Column<DateTime>(name: "Güncelleyen Zamanı", type: "timestamp with time zone", nullable: false),
                    GüncelleyenIp = table.Column<string>(name: "Güncelleyen Ip", type: "text", nullable: true),
                    GüncelleyenKişi = table.Column<string>(name: "Güncelleyen Kişi", type: "text", nullable: true),
                    GüncelleyenBilgisayarAdı = table.Column<string>(name: "Güncelleyen Bilgisayar Adı", type: "text", nullable: true),
                    GüncelleyenYöneticiAdı = table.Column<string>(name: "Güncelleyen Yönetici Adı", type: "text", nullable: true),
                    GüncelleyenBilgisayarınınDomainAdı = table.Column<string>(name: "Güncelleyen Bilgisayarının Domain Adı", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MasterId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OluşturulmaZamanı = table.Column<DateTime>(name: "Oluşturulma Zamanı", type: "timestamp with time zone", nullable: false),
                    OluşturanIp = table.Column<string>(name: "Oluşturan Ip", type: "text", nullable: true),
                    OluşturanKişi = table.Column<string>(name: "Oluşturan Kişi", type: "text", nullable: true),
                    OluşturanınBilgisayarAdı = table.Column<string>(name: "Oluşturanın Bilgisayar Adı", type: "text", nullable: true),
                    OluşturanYöneticiAdı = table.Column<string>(name: "Oluşturan Yönetici Adı", type: "text", nullable: true),
                    OluşturanınBilgisayarınınDomainAdı = table.Column<string>(name: "Oluşturanın Bilgisayarının Domain Adı", type: "text", nullable: true),
                    GüncelleyenZamanı = table.Column<DateTime>(name: "Güncelleyen Zamanı", type: "timestamp with time zone", nullable: false),
                    GüncelleyenIp = table.Column<string>(name: "Güncelleyen Ip", type: "text", nullable: true),
                    GüncelleyenKişi = table.Column<string>(name: "Güncelleyen Kişi", type: "text", nullable: true),
                    GüncelleyenBilgisayarAdı = table.Column<string>(name: "Güncelleyen Bilgisayar Adı", type: "text", nullable: true),
                    GüncelleyenYöneticiAdı = table.Column<string>(name: "Güncelleyen Yönetici Adı", type: "text", nullable: true),
                    GüncelleyenBilgisayarınınDomainAdı = table.Column<string>(name: "Güncelleyen Bilgisayarının Domain Adı", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
