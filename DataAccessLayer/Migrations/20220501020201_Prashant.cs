using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Prashant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReimbursementEntity",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReimbursementType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RequestedValue = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RequestPhase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReceiptAttached = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SignUp_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReimbursementEntity", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "SignUpEntity",
                columns: table => new
                {
                    SignUp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PanNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsApprover = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpEntity", x => x.SignUp_Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalEntity",
                columns: table => new
                {
                    SignUp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedValue = table.Column<int>(type: "int", nullable: true),
                    InternalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    ReimbursementEntityClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalEntity", x => x.SignUp_Id);
                    table.ForeignKey(
                        name: "FK_ApprovalEntity_ReimbursementEntity_ReimbursementEntityClaimId",
                        column: x => x.ReimbursementEntityClaimId,
                        principalTable: "ReimbursementEntity",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalEntity_ReimbursementEntityClaimId",
                table: "ApprovalEntity",
                column: "ReimbursementEntityClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalEntity");

            migrationBuilder.DropTable(
                name: "SignUpEntity");

            migrationBuilder.DropTable(
                name: "ReimbursementEntity");
        }
    }
}
