using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon2023.Data.Migrations
{
    public partial class applicants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduationMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SponsorshipNeeded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedInURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resume = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagsApplicants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagID = table.Column<int>(type: "int", nullable: true),
                    ApplicantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagsApplicants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagsApplicants_Applicants_ApplicantID",
                        column: x => x.ApplicantID,
                        principalTable: "Applicants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TagsApplicants_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagsApplicants_ApplicantID",
                table: "TagsApplicants",
                column: "ApplicantID");

            migrationBuilder.CreateIndex(
                name: "IX_TagsApplicants_TagID",
                table: "TagsApplicants",
                column: "TagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagsApplicants");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
