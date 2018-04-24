using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace vcoresrobotics.website.Migrations
{
    public partial class updated_Post_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppComments_AppPosts_CommentId",
                table: "AppComments");

            migrationBuilder.DropIndex(
                name: "IX_AppComments_CommentId",
                table: "AppComments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "AppComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "AppComments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppComments_CommentId",
                table: "AppComments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppComments_AppPosts_CommentId",
                table: "AppComments",
                column: "CommentId",
                principalTable: "AppPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
