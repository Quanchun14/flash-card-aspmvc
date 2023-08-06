using Bogus;
using flash_card.Models;
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

            //Insert data
            Randomizer.Seed = new Random(8675309);
            var fakeWord = new Faker<Word>();
            fakeWord.RuleFor(w=>w.Title, f=>f.Random.Word());
            fakeWord.RuleFor(w=>w.Example, f=>f.Lorem.Sentence(10));
            fakeWord.RuleFor(w=>w.Defination, f=>f.Lorem.Sentence(10));
            fakeWord.RuleFor(w=>w.CreateDate, f => f.Date.Between(new DateTime(2023,2,8),new DateTime(2023,4,8)).ToString());
            fakeWord.RuleFor(w=>w.LearnTime, f=>f.Random.Number(500));

            for(int i = 0; i < 150; i++){


            Word word = fakeWord.Generate();
            migrationBuilder.InsertData(
                table: "Word",
                columns: new[] {"title", "example", "defination", "createdate", "learntimes"},
                values: new object[] {
                    word.Title,
                    word.Example,
                    word.Defination,
                    word.CreateDate,
                    word.LearnTime,
                }
            );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Word");
        }
    }
}
