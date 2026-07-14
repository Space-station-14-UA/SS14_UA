using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class RenameSichSponsorsToMriyaSponsors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sponsor_role_assignments_sich_sponsors_sponsor_user_id",
                table: "sponsor_role_assignments");

            migrationBuilder.RenameTable(
                name: "sich_sponsors",
                newName: "mriya_sponsors");

            migrationBuilder.RenameIndex(
                name: "IX_sich_sponsors_selected_ghost_rank_id",
                table: "mriya_sponsors",
                newName: "IX_mriya_sponsors_selected_ghost_rank_id");

            migrationBuilder.RenameIndex(
                name: "IX_sich_sponsors_selected_ooc_rank_id",
                table: "mriya_sponsors",
                newName: "IX_mriya_sponsors_selected_ooc_rank_id");

            migrationBuilder.AddForeignKey(
                name: "FK_sponsor_role_assignments_mriya_sponsors_sponsor_user_id",
                table: "sponsor_role_assignments",
                column: "user_id",
                principalTable: "mriya_sponsors",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Дії для скасування міграції (відкат)
            migrationBuilder.DropForeignKey(
                name: "FK_sponsor_role_assignments_mriya_sponsors_sponsor_user_id",
                table: "sponsor_role_assignments");

            migrationBuilder.RenameTable(
                name: "mriya_sponsors",
                newName: "sich_sponsors");

            migrationBuilder.RenameIndex(
                name: "IX_mriya_sponsors_selected_ghost_rank_id",
                table: "sich_sponsors",
                newName: "IX_sich_sponsors_selected_ghost_rank_id");

            migrationBuilder.RenameIndex(
                name: "IX_mriya_sponsors_selected_ooc_rank_id",
                table: "sich_sponsors",
                newName: "IX_sich_sponsors_selected_ooc_rank_id");

            migrationBuilder.AddForeignKey(
                name: "FK_sponsor_role_assignments_sich_sponsors_sponsor_user_id",
                table: "sponsor_role_assignments",
                column: "user_id",
                principalTable: "sich_sponsors",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}