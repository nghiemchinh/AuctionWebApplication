using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionWebApplication.Migrations.Dbauction
{
    /// <inheritdoc />
    public partial class updaterating1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionsComment_Auction_AuctionId",
                table: "AuctionsComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuctionsComment",
                table: "AuctionsComment");

            migrationBuilder.RenameTable(
                name: "AuctionsComment",
                newName: "AuctionsComments");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionsComment_AuctionId",
                table: "AuctionsComments",
                newName: "IX_AuctionsComments_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuctionsComments",
                table: "AuctionsComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionsComments_Auction_AuctionId",
                table: "AuctionsComments",
                column: "AuctionId",
                principalTable: "Auction",
                principalColumn: "auction_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionsComments_Auction_AuctionId",
                table: "AuctionsComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuctionsComments",
                table: "AuctionsComments");

            migrationBuilder.RenameTable(
                name: "AuctionsComments",
                newName: "AuctionsComment");

            migrationBuilder.RenameIndex(
                name: "IX_AuctionsComments_AuctionId",
                table: "AuctionsComment",
                newName: "IX_AuctionsComment_AuctionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuctionsComment",
                table: "AuctionsComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionsComment_Auction_AuctionId",
                table: "AuctionsComment",
                column: "AuctionId",
                principalTable: "Auction",
                principalColumn: "auction_id");
        }
    }
}
