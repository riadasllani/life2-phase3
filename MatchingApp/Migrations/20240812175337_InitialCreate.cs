using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchingApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "SenderId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FirstUserId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SecondUserId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "MessageDate",
                table: "Messages",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "Messages",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Messages",
                newName: "MessageId");

            migrationBuilder.RenameColumn(
                name: "MatchDate",
                table: "Matches",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "IsMutual",
                table: "Matches",
                newName: "Mutual");

            migrationBuilder.AlterColumn<long>(
                name: "Credits",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reciever",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LikeUser",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LikedUser",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Reciever",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "LikeUser",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LikedUser",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Messages",
                newName: "MessageContent");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Messages",
                newName: "MessageDate");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Messages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Mutual",
                table: "Matches",
                newName: "IsMutual");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Matches",
                newName: "MatchDate");

            migrationBuilder.AlterColumn<int>(
                name: "Credits",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Messages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstUserId",
                table: "Matches",
                type: "int",
                nullable: true);

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
