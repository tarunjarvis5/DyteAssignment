using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logwarts.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaDataModel",
                columns: table => new
                {
                    MetaDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentResourceId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDataModel", x => x.MetaDataId);
                });

            migrationBuilder.CreateTable(
                name: "LogEntryModel",
                columns: table => new
                {
                    LogEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    traceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spanId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    commit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntryModel", x => x.LogEntryId);
                    table.ForeignKey(
                        name: "FK_LogEntryModel_MetaDataModel_MetaDataId",
                        column: x => x.MetaDataId,
                        principalTable: "MetaDataModel",
                        principalColumn: "MetaDataId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogEntryModel_MetaDataId",
                table: "LogEntryModel",
                column: "MetaDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogEntryModel");

            migrationBuilder.DropTable(
                name: "MetaDataModel");
        }
    }
}
