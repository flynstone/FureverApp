using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Identity.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5373a5f-4e1c-448d-af9c-1e150930a7ec",
                column: "ConcurrencyStamp",
                value: "eca00f94-a3eb-421a-aca1-6ea48c05b974");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6027a9a-8321-403d-93a4-29b8d37e0665",
                column: "ConcurrencyStamp",
                value: "e192cc8c-ad33-48a6-b135-37edbcefe0cf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5373a5f-4e1c-448d-af9c-1e150930a7ec",
                column: "ConcurrencyStamp",
                value: "b5f60fe3-65c9-43f8-a5ad-494025fe858a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6027a9a-8321-403d-93a4-29b8d37e0665",
                column: "ConcurrencyStamp",
                value: "86e057d9-d49a-4f8f-bea8-f25cfc8d74d5");
        }
    }
}
