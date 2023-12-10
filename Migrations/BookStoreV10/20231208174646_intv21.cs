using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreV10.Migrations.BookStoreV10
{
    /// <inheritdoc />
    public partial class intv21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Book",
                newName: "PublisherNameNavigationPublisherId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Book",
                newName: "AuthorNameNavigationAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                newName: "IX_Book_PublisherNameNavigationPublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                newName: "IX_Book_AuthorNameNavigationAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorNameNavigationAuthorId",
                table: "Book",
                column: "AuthorNameNavigationAuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherNameNavigationPublisherId",
                table: "Book",
                column: "PublisherNameNavigationPublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorNameNavigationAuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherNameNavigationPublisherId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "PublisherNameNavigationPublisherId",
                table: "Book",
                newName: "PublisherId");

            migrationBuilder.RenameColumn(
                name: "AuthorNameNavigationAuthorId",
                table: "Book",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherNameNavigationPublisherId",
                table: "Book",
                newName: "IX_Book_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_AuthorNameNavigationAuthorId",
                table: "Book",
                newName: "IX_Book_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "PublisherId");
        }
    }
}
