using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchingApp.Migrations
{
    /// <inheritdoc />
    public partial class AddingTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_FirstUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_SecondUserId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Matches_FirstUserId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_SecondUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FirstUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchDate",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondUserId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "MessageDate",
                table: "Messages",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "Messages",
                newName: "Content");

            migrationBuilder.AlterColumn<string>(
                name: "Credits",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "SenderId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "RecieverId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserRecievedId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSentId",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GotLiked",
                table: "Matches",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "HasLike",
                table: "Matches",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UserGotLikedId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserHasLikedId",
                table: "Matches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserRecievedId",
                table: "Messages",
                column: "UserRecievedId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserSentId",
                table: "Messages",
                column: "UserSentId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UserGotLikedId",
                table: "Matches",
                column: "UserGotLikedId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_UserHasLikedId",
                table: "Matches",
                column: "UserHasLikedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserGotLikedId",
                table: "Matches",
                column: "UserGotLikedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_UserHasLikedId",
                table: "Matches",
                column: "UserHasLikedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserRecievedId",
                table: "Messages",
                column: "UserRecievedId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserSentId",
                table: "Messages",
                column: "UserSentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserGotLikedId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Users_UserHasLikedId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserRecievedId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserSentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserRecievedId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserSentId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Matches_UserGotLikedId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_UserHasLikedId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "RecieverId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserRecievedId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserSentId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "GotLiked",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "HasLike",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UserGotLikedId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "UserHasLikedId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Messages",
                newName: "MessageDate");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "MessageContent");

            migrationBuilder.AlterColumn<int>(
                name: "Credits",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Messages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstUserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MatchDate",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SecondUserId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstUserId",
                table: "Matches",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondUserId",
                table: "Matches",
                column: "SecondUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_FirstUserId",
                table: "Matches",
                column: "FirstUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Users_SecondUserId",
                table: "Matches",
                column: "SecondUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
