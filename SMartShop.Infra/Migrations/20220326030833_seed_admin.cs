using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMartShop.Infra.Migrations
{
    public partial class seed_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddresses_Customers_CustomerId",
                table: "EmailAddresses");

            migrationBuilder.DropIndex(
                name: "IX_EmailAddresses_CustomerId",
                table: "EmailAddresses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "EmailAddresses");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Active", "CEP", "CityId", "Complement", "CreatedBy", "Deleted", "DeletedAt", "DeletedBy", "District", "Number", "Street", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, true, "01016050", 5267, "Casa", 0, false, null, null, "Centro", "123", "Rua Floriano Peixoto", null, null });

            migrationBuilder.InsertData(
                table: "EmailAddresses",
                columns: new[] { "Id", "Active", "CreatedBy", "Deleted", "DeletedAt", "DeletedBy", "Email", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, true, 0, false, null, null, "email@email.com", null, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 613, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 26, 0, 8, 31, 614, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedBy", "Deleted", "DeletedAt", "DeletedBy", "Login", "Password", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1, true, 0, false, null, null, "4dm1n", "5m4rt5h0p", null, null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Active", "AddressId", "CreatedBy", "DateOfBirth", "Deleted", "DeletedAt", "DeletedBy", "EmailId", "FirstName", "LastName", "MiddleName", "UpdatedAt", "UpdatedBy", "UserId" },
                values: new object[] { 1, true, 1, 0, new DateTime(2022, 3, 26, 0, 8, 31, 615, DateTimeKind.Local).AddTicks(4538), false, null, null, 1, "Super", "Admin", null, null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmailId",
                table: "Customers",
                column: "EmailId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_EmailAddresses_EmailId",
                table: "Customers",
                column: "EmailId",
                principalTable: "EmailAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_EmailAddresses_EmailId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_EmailId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmailAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "EmailAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 374, DateTimeKind.Local).AddTicks(5684));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5817));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2022, 3, 25, 23, 40, 22, 375, DateTimeKind.Local).AddTicks(5818));

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddresses_CustomerId",
                table: "EmailAddresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_Customers_CustomerId",
                table: "EmailAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
