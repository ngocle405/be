using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApi.Data.Migrations
{
    public partial class initTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BroadcastProgram",
                columns: table => new
                {
                    BroadcastProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BroadcastProgramName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadcastProgram", x => x.BroadcastProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CardName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CardSendDate = table.Column<DateTime>(type: "date", nullable: false),
                    CardRecipient = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CardSender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "IngestGenre",
                columns: table => new
                {
                    IngestGenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngestGenreName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestGenre", x => x.IngestGenreId);
                });

            migrationBuilder.CreateTable(
                name: "Ingest",
                columns: table => new
                {
                    IngestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Reporter = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Subscriber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Production = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    film = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BroadcastProgramId = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IngestGenreId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    SavaData = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProcessingHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingest", x => x.IngestId);
                    table.ForeignKey(
                        name: "FK_Ingest_BroadcastProgram_BroadcastProgramId",
                        column: x => x.BroadcastProgramId,
                        principalTable: "BroadcastProgram",
                        principalColumn: "BroadcastProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingest_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingest_IngestGenre_IngestGenreId",
                        column: x => x.IngestGenreId,
                        principalTable: "IngestGenre",
                        principalColumn: "IngestGenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingest_BroadcastProgramId",
                table: "Ingest",
                column: "BroadcastProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingest_CardId",
                table: "Ingest",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingest_IngestGenreId",
                table: "Ingest",
                column: "IngestGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingest");

            migrationBuilder.DropTable(
                name: "BroadcastProgram");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "IngestGenre");
        }
    }
}
