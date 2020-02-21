using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocTest.Migrations
{
    public partial class snake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserResults_Users_UserId",
                table: "UserResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserResults",
                table: "UserResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "UserResults",
                newName: "user_results");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "questions");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_results",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "user_results",
                newName: "result");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_results",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_UserResults_UserId",
                table: "user_results",
                newName: "ix_user_results_user_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "questions",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Answer2",
                table: "questions",
                newName: "answer2");

            migrationBuilder.RenameColumn(
                name: "Answer1",
                table: "questions",
                newName: "answer1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "questions",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_results",
                table: "user_results",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_questions",
                table: "questions",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_results_users_user_id",
                table: "user_results",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_results_users_user_id",
                table: "user_results");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_results",
                table: "user_results");

            migrationBuilder.DropPrimaryKey(
                name: "pk_questions",
                table: "questions");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "user_results",
                newName: "UserResults");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "Questions");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "UserResults",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "result",
                table: "UserResults",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UserResults",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_user_results_user_id",
                table: "UserResults",
                newName: "IX_UserResults_UserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Questions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "answer2",
                table: "Questions",
                newName: "Answer2");

            migrationBuilder.RenameColumn(
                name: "answer1",
                table: "Questions",
                newName: "Answer1");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Questions",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserResults",
                table: "UserResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserResults_Users_UserId",
                table: "UserResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
