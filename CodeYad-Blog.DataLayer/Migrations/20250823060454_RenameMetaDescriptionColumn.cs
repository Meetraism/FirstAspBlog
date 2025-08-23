using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeYad_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenameMetaDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Rename: MetaDiscription  →  MetaDescription
            migrationBuilder.RenameColumn(
                name: "MetaDiscription",
                table: "Categories",
                newName: "MetaDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rollback rename
            migrationBuilder.RenameColumn(
                name: "MetaDescription",
                table: "Categories",
                newName: "MetaDiscription");
        }
    }
}
