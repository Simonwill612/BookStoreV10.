using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreV10.Migrations.BookStoreV10
{
    /// <inheritdoc />
    public partial class addcolumnCoverImageFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImageData",
                table: "Book",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageData",
                table: "Book");
        }
    }
}
