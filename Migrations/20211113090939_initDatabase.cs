using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorWeb3.Models;

namespace RazorWeb3.Migrations
{
  public partial class initDatabase : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Articles",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            Content = table.Column<string>(type: "ntext", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Articles", x => x.Id);
          });

      Randomizer.Seed = new Random(12344321);
      var articleTest = new Faker<Article>();

      articleTest.RuleFor(article => article.Title, f => f.Lorem.Sentence(5, 5));
      articleTest.RuleFor(article => article.CreatedAt, f => f.Date.Between(new DateTime(2021, 10, 01), new DateTime(2021, 12, 01)));
      articleTest.RuleFor(article => article.Content, f => f.Lorem.Paragraphs(1, 5));

      for (int i = 0; i < 100; i++)
      {
        Article article = articleTest.Generate();
        migrationBuilder.InsertData(
            table: "Articles",
            columns: new[] { "Title", "CreatedAt", "Content" },
            values: new object[] {
                  article.Title,
                  article.CreatedAt,
                  article.Content
            }
        );
      }
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Articles");
    }
  }
}
