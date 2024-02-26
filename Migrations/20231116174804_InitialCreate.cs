using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COP4365_Project3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ticker = table.Column<string>(type: "TEXT", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false),
                    Open = table.Column<double>(type: "REAL", nullable: false),
                    High = table.Column<double>(type: "REAL", nullable: false),
                    Low = table.Column<double>(type: "REAL", nullable: false),
                    Close = table.Column<double>(type: "REAL", nullable: false),
                    Volume = table.Column<long>(type: "INTEGER", nullable: false),
                    StockFilePath = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    TopPrice = table.Column<double>(type: "REAL", nullable: true),
                    BottomPrice = table.Column<double>(type: "REAL", nullable: true),
                    BodyRange = table.Column<double>(type: "REAL", nullable: true),
                    TopTail = table.Column<double>(type: "REAL", nullable: true),
                    BottomTail = table.Column<double>(type: "REAL", nullable: true),
                    IsBullish = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsBearish = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsNeutral = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsMarubozu = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDoji = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsDragonFlyDoji = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsGravestoneDoji = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsHammer = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsInvertedHammer = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
