using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Contact", "Name" },
                values: new object[,]
                {
                    { 1, "testAddress1", "1234567890", "test1" },
                    { 2, "testAddress2", "2345678901", "test2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Name", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "testAddress1", "Admin", "AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+BTOEEwsNEyYuyrdX6F3ggAAAAACAAAAAAAQZgAAAAEAACAAAAAvUVkEph/QVYMyxqa4G/g0vqbenGbScpAv2OwQOlpW/AAAAAAOgAAAAAIAACAAAAB4NN9Tot7baAdmTaQ4OK49a1jLv7/0VXqNkhdEuJblhhAAAAAhaX8x4tX0JKz8wynz22nlQAAAALXmRHXQEBHoeNRNkno/UODqRcSV/fuAPBt+/gQGv24lvzt/A+UQasFMzuJ7Y4I7tRanuMYeNPnRAmfcW6PLpRQ=", "admin" },
                    { 2, "testAddress2", "Employee", "AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA+BTOEEwsNEyYuyrdX6F3ggAAAAACAAAAAAAQZgAAAAEAACAAAACLmArT294T5BOSJpnA+EXB+NclqmGsO4DyVHYu82nHVQAAAAAOgAAAAAIAACAAAADvlRpV5YqTD0sQ9seNH4r+MjHW3SBdY4BOXnZ4EQB+IiAAAAD9JEtN9/NR4Um3PojeImpURNVuYSBLrtbvE6I6T2MbsEAAAAC2uFAQHByw0EHd7PuZOBqxxJAX62t6pllJobzxKFVVFt+NYKO48OuYzKawjL4fx5VeLVJbmiR8G627+wcGXs1h", "employee" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
