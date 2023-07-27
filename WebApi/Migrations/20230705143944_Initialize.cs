using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    FailedMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailLogs_MailMessages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "MailMessages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MailRecipients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailRecipients_MailMessages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "MailMessages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MailRecipients_Recipients_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Recipients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailLogs_MessageId",
                table: "MailLogs",
                column: "MessageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MailRecipients_MessageId",
                table: "MailRecipients",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_MailRecipients_RecipientId",
                table: "MailRecipients",
                column: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailLogs");

            migrationBuilder.DropTable(
                name: "MailRecipients");

            migrationBuilder.DropTable(
                name: "MailMessages");

            migrationBuilder.DropTable(
                name: "Recipients");
        }
    }
}
