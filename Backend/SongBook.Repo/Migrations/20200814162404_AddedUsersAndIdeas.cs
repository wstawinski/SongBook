using Microsoft.EntityFrameworkCore.Migrations;

namespace SongBook.Repo.Migrations
{
    public partial class AddedUsersAndIdeas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ideas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaTeamMember",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    IdeaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaTeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdeaTeamMember_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaTeamMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IdeaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1L, "FirstName1", "LastName1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2L, "FirstName2", "LastName2" });

            migrationBuilder.InsertData(
                table: "IdeaTeamMember",
                columns: new[] { "Id", "IdeaId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 1L, null, 10, 1L },
                    { 3L, null, 10, 1L },
                    { 2L, null, 10, 2L },
                    { 4L, null, 10, 2L }
                });

            migrationBuilder.InsertData(
                table: "Ideas",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1L, "Description1", "Name1", 1L },
                    { 2L, "Description2", "Name2", 2L }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Content", "IdeaId", "UserId" },
                values: new object[,]
                {
                    { 1L, "Content1User1", null, 1L },
                    { 3L, "Content2User1", null, 1L },
                    { 2L, "Content1User2", null, 2L },
                    { 4L, "Content2User2", null, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaTeamMember_IdeaId",
                table: "IdeaTeamMember",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaTeamMember_UserId",
                table: "IdeaTeamMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_IdeaId",
                table: "Question",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserId",
                table: "Question",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaTeamMember");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
