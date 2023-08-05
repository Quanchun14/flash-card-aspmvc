using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flash_card.Migrations
{
    /// <inheritdoc />
    public partial class FlashCardCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    example = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    defination = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    createdate = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    learntimes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Word", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}
