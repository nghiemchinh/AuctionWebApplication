using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionWebApplication.Migrations.Dbauction
{
    /// <inheritdoc />
    public partial class updaterating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionsComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuctionId = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionsComment_Auction_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auction",
                        principalColumn: "auction_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionsComment_AuctionId",
                table: "AuctionsComment",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionsComment");
        }
    }
}
