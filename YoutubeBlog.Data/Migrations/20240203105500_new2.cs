using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DeleteData(
                table: "AboutImages",
                keyColumn: "Id",
                keyValue: new Guid("31f7ad92-c656-488e-919e-528becc52048"));

            migrationBuilder.DeleteData(
                table: "ArticleImages",
                keyColumn: "Id",
                keyValue: new Guid("0b30156f-a7ac-4070-aea0-fcdadfb88cca"));

            migrationBuilder.DeleteData(
                table: "ArticleImages",
                keyColumn: "Id",
                keyValue: new Guid("d2a2c466-f8c1-4dbf-ba1a-2662819f03e6"));

            migrationBuilder.DeleteData(
                table: "ClientImages",
                keyColumn: "Id",
                keyValue: new Guid("557b1f83-6903-452b-b644-3b5bd01a6c7a"));

            migrationBuilder.DeleteData(
                table: "ClientImages",
                keyColumn: "Id",
                keyValue: new Guid("ca3b89db-cab0-4339-93b3-b25f9ba1230c"));

            migrationBuilder.DeleteData(
                table: "LogoImages",
                keyColumn: "Id",
                keyValue: new Guid("04888be2-8f63-45b5-b580-83726665b220"));

            migrationBuilder.DeleteData(
                table: "LogoImages",
                keyColumn: "Id",
                keyValue: new Guid("c3c151d5-15a2-4db6-ab34-37a46ed4e7f0"));

            migrationBuilder.DeleteData(
                table: "PortfolioImages",
                keyColumn: "Id",
                keyValue: new Guid("85a73ba6-3180-42db-ba2c-081c11bce3a3"));

            migrationBuilder.DeleteData(
                table: "PortfolioImages",
                keyColumn: "Id",
                keyValue: new Guid("dab315f2-8bfc-479e-91d6-fdc33e4ef077"));

            migrationBuilder.DeleteData(
                table: "SliderImages",
                keyColumn: "Id",
                keyValue: new Guid("32e85ca2-0ce9-4ee0-89f9-d23bbab48a2e"));

            migrationBuilder.DeleteData(
                table: "SliderImages",
                keyColumn: "Id",
                keyValue: new Guid("c44f864d-d39d-4645-ade1-6f911f7f3359"));

            migrationBuilder.DeleteData(
                table: "SmtpSetting",
                keyColumn: "Id",
                keyValue: new Guid("98c70e67-b1b2-4ffa-8174-2f67367fd6cc"));

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: new Guid("7334e5c7-2925-4a78-b4d5-a868546b7c73"));

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: new Guid("e877ffac-b184-4bdd-a2a5-9100b7fe1202"));

            migrationBuilder.InsertData(
                table: "AboutImages",
                columns: new[] { "Id", "AboutId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[] { new Guid("28a65ff3-4802-4eb3-be6b-22f008947dd4"), new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1456), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1458), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1457), "F?YHvp<kUk'" });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1590), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1581), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1580), "w:>].:YE(#1};I<t#" });

            migrationBuilder.InsertData(
                table: "ArticleImages",
                columns: new[] { "Id", "ArticleId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("41f987e0-6d31-459b-ac89-5517985419f1"), new Guid("bcdef234-2345-6789-01bc-def234567890"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1718), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1719), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1719), "hJlu81}&az@Lg6.#Z" },
                    { new Guid("7ea36edc-b517-4535-837a-0a77bbc445fc"), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1706), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1707), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1706), "UB<t<U9Wkk{-eup" }
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345678"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1971), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1962), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1961), "X:jaB(-Msq3" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567890"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1986), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1980), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1980), "S(EY|?JXX5J;gj8CVd" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "74616f15-53cd-4f3c-8f03-0d7828972914");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "e801a9ea-d669-44a0-b8ed-423ac570ff30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "0d21436d-4a92-4614-aa91-325f4ae5925f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17a8b33c-bee4-40c0-8616-c0ed3e4afa18", "AQAAAAEAACcQAAAAEOnPKFcdTiFwaooC8aqRgIrsnUTFjPAqkbI3FL0MNeQWgkOCx7bUDXdIPsz+GG0BGA==", "42fb7839-eb8b-442f-b109-99a8dddf5e09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89fdaac9-9c94-47f6-bc5e-67b2fa2c85c4", "AQAAAAEAACcQAAAAEBboj3rLKekoHcj3KyJv0Hkc69JP82oMRRMRSKo3zO5rH0+0qKqD/x/3+rF2M3fcYw==", "9c5c90e7-e47a-4d58-b9c1-35e186b90e3a" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3187), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3171), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3170), "V!v59kN" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3196), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3191), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3190), "Z)=WY[%3.k4Y" });

            migrationBuilder.InsertData(
                table: "ClientImages",
                columns: new[] { "Id", "ClientId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("98cfdfb1-08e3-4861-9d2b-de04bfd6c1a2"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3322), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3323), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3323), "1Q>QiBt;OIu'ngNea>u" },
                    { new Guid("db14c073-011c-4a21-947c-cea0ea1c31dd"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3313), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3314), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3314), "9HWSm!WmlxpF!" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3499), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3489), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3488), "DKP9t'W4n=T-^{bYZV2b" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3510), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3505), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3505), "H$$V21KB" });

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3620), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3613), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3627), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3623), new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "Fact",
                keyColumn: "Id",
                keyValue: new Guid("db3f7d1d-ec14-4d06-aea8-2a69ffe9ba6c"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2562), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2553), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2553), "yCmCUZC;c[xoej94HU" });

            migrationBuilder.UpdateData(
                table: "Fact",
                keyColumn: "Id",
                keyValue: new Guid("fe50fefb-8edb-4b5f-9e70-dcd4aec46a70"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2550), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2530), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2529), "_|bE&<m$R=^M|jC(}:Z)" });

            migrationBuilder.UpdateData(
                table: "Headquarters",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2803), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2794), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2793), "LH3?$5@,t|(#$KXx7XV" });

            migrationBuilder.UpdateData(
                table: "Headquarters",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2811), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2807), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2806), "q&m$DtH5gm" });

            migrationBuilder.InsertData(
                table: "LogoImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "LogoId", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("b516c9ef-c115-4ffe-b3ed-6d140616e79c"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3050), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3051), "images/testimage", "jpg", false, false, new Guid("bcdef234-2345-6789-01bc-def234567899"), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3050), "1,^9$+8" },
                    { new Guid("cd7133c0-790b-4eeb-9fda-61d6e6655206"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3042), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3043), "images/testimage", "jpg", false, false, new Guid("abcde123-1234-5678-90ab-cdef12345679"), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3043), "O?qt<T!>Q+%>jlt{u" }
                });

            migrationBuilder.UpdateData(
                table: "Logos",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345679"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3160), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3153), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3152), "57P>4|rv3g&X" });

            migrationBuilder.UpdateData(
                table: "Logos",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567899"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3169), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3164), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3164), "Y9E3)q<cNqfiI9|od" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("0ecc0342-25cf-4f53-b64c-788eb22d832a"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3291), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3285), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3285), "(S4wdh<Zs" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("9c8cea58-68db-4aa7-a54e-913ab047622c"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3279), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3273), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3272), "![@j=dds" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("a501a204-6f7b-45a4-8fb8-969cd86e8791"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3303), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3299), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3299), "q_<$sbu}^1&PU" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("dd40a305-995b-48ca-a7f8-133910fb72cb"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3297), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3293), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3292), "vM'g;n[}0dL" });

            migrationBuilder.InsertData(
                table: "PortfolioImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "PortfolioId", "SecName" },
                values: new object[,]
                {
                    { new Guid("54cb0f00-8c5c-4887-bcaf-0770f4df90d1"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3406), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3399), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3399), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "Z5%pH((cQL6" },
                    { new Guid("7931812c-1322-418c-a750-c90c84bab34f"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3465), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3461), "images/vstest", "png", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(3460), new Guid("bcdef234-2345-6789-01bc-def234567890"), "OT|1ji-p" }
                });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345678"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4444), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4436), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4436), "JHw_|uOXms{{tjS" });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567890"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4455), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4451), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(4450), "9+c9!ce,vrZV" });

            migrationBuilder.InsertData(
                table: "SliderImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName", "SliderId" },
                values: new object[,]
                {
                    { new Guid("92bb0abb-2ae2-445d-bafe-9a77ff23a468"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(350), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(353), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(353), "!CmMV6)f6j-R#V", new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57") },
                    { new Guid("c4dd2f7e-76d9-4576-a75c-a54050dae9b1"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(375), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(377), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(376), "gI!mkvIL", new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2") }
                });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(506), new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(492), new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(491), ".ITI5<'f3@A{{T" });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(513), new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(508), new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(508), "0%S?,<^RdgsO" });

            migrationBuilder.InsertData(
                table: "SmtpSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IMAPPort", "IncomingServer", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "OutgoingServer", "Password", "SMTPPort", "SecName", "ServerIP", "SmtpName", "Username" },
                values: new object[] { new Guid("f34015ec-47b5-4b07-94eb-51c6863b2d38"), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1127), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1139), 993, "mail.batuhanulukan.com.tr", false, false, "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 462, DateTimeKind.Local).AddTicks(1138), "mail.batuhanulukan.com.tr", "B5x8d2u~9", 465, "I!DgSp&bxHKzc#aH}w", "77.245.159.27", "SMTP", "info@batuhanulukan.com.tr" });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Icon", "IsActive", "IsDeleted", "IsMaın", "Link", "ModifiedBy", "ModifiedDate", "Name", "SecName", "UserId" },
                values: new object[,]
                {
                    { new Guid("257e1430-dc2b-4aa5-bca0-e68faaa3003b"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(637), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(629), "instagram", false, false, true, "https://www.instagram.com", "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(629), "Instagram", null, new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("369724cb-2a49-4c9d-9473-0727b2f31865"), "Admin Test", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(625), "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(619), "facebook", false, false, false, "https://www.facebook.com", "Undefined", new DateTime(2024, 2, 3, 13, 54, 58, 464, DateTimeKind.Local).AddTicks(618), "Facebook", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.UpdateData(
                table: "UserImages",
                keyColumn: "Id",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2939), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2933), "+LoWSZguENX!?OA=+" });

            migrationBuilder.UpdateData(
                table: "UserImages",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2925), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2920), new DateTime(2024, 2, 3, 13, 54, 58, 463, DateTimeKind.Local).AddTicks(2919), "!^oG.y>n-%3sQM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutImages",
                keyColumn: "Id",
                keyValue: new Guid("28a65ff3-4802-4eb3-be6b-22f008947dd4"));

            migrationBuilder.DeleteData(
                table: "ArticleImages",
                keyColumn: "Id",
                keyValue: new Guid("41f987e0-6d31-459b-ac89-5517985419f1"));

            migrationBuilder.DeleteData(
                table: "ArticleImages",
                keyColumn: "Id",
                keyValue: new Guid("7ea36edc-b517-4535-837a-0a77bbc445fc"));

            migrationBuilder.DeleteData(
                table: "ClientImages",
                keyColumn: "Id",
                keyValue: new Guid("98cfdfb1-08e3-4861-9d2b-de04bfd6c1a2"));

            migrationBuilder.DeleteData(
                table: "ClientImages",
                keyColumn: "Id",
                keyValue: new Guid("db14c073-011c-4a21-947c-cea0ea1c31dd"));

            migrationBuilder.DeleteData(
                table: "LogoImages",
                keyColumn: "Id",
                keyValue: new Guid("b516c9ef-c115-4ffe-b3ed-6d140616e79c"));

            migrationBuilder.DeleteData(
                table: "LogoImages",
                keyColumn: "Id",
                keyValue: new Guid("cd7133c0-790b-4eeb-9fda-61d6e6655206"));

            migrationBuilder.DeleteData(
                table: "PortfolioImages",
                keyColumn: "Id",
                keyValue: new Guid("54cb0f00-8c5c-4887-bcaf-0770f4df90d1"));

            migrationBuilder.DeleteData(
                table: "PortfolioImages",
                keyColumn: "Id",
                keyValue: new Guid("7931812c-1322-418c-a750-c90c84bab34f"));

            migrationBuilder.DeleteData(
                table: "SliderImages",
                keyColumn: "Id",
                keyValue: new Guid("92bb0abb-2ae2-445d-bafe-9a77ff23a468"));

            migrationBuilder.DeleteData(
                table: "SliderImages",
                keyColumn: "Id",
                keyValue: new Guid("c4dd2f7e-76d9-4576-a75c-a54050dae9b1"));

            migrationBuilder.DeleteData(
                table: "SmtpSetting",
                keyColumn: "Id",
                keyValue: new Guid("f34015ec-47b5-4b07-94eb-51c6863b2d38"));

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: new Guid("257e1430-dc2b-4aa5-bca0-e68faaa3003b"));

            migrationBuilder.DeleteData(
                table: "Socials",
                keyColumn: "Id",
                keyValue: new Guid("369724cb-2a49-4c9d-9473-0727b2f31865"));

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutImages",
                columns: new[] { "Id", "AboutId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[] { new Guid("31f7ad92-c656-488e-919e-528becc52048"), new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2679), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2680), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2679), "0p03d" });

            migrationBuilder.UpdateData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2838), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2828), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2828), "r!weUj|jq6,N,=" });

            migrationBuilder.InsertData(
                table: "ArticleImages",
                columns: new[] { "Id", "ArticleId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("0b30156f-a7ac-4070-aea0-fcdadfb88cca"), new Guid("bcdef234-2345-6789-01bc-def234567890"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3006), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3008), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3007), "ZLt{7bI!srWI3" },
                    { new Guid("d2a2c466-f8c1-4dbf-ba1a-2662819f03e6"), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2996), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2997), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2996), ".UCo7Q>ffggxIHMpl!,9" }
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345678"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3138), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3131), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3131), "<Mt&n?1BAT+4" });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567890"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3152), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3143), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3143), "k1M-__-CW*W4<$d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"),
                column: "ConcurrencyStamp",
                value: "b759d8a4-fa79-42c3-8301-5f3b3ebc9d39");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"),
                column: "ConcurrencyStamp",
                value: "2b68f4b5-02b8-423c-b8a5-a01b003c873e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"),
                column: "ConcurrencyStamp",
                value: "8d5d7a54-97dd-4fb8-9cb2-688174658925");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca5a8fcf-7394-4fd8-a020-785684f2a7e1", "AQAAAAEAACcQAAAAEAuUHQvm3QYVHKqMWaC6nbrYzn4Msy/3O5PP7iIYrOCFtTYQjdjLPxFrZR5HxyJ5zg==", "e6d57430-0761-4c2d-8426-c7d2b2455f7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39483e94-e7d0-43ed-84f7-98310dd2ebac", "AQAAAAEAACcQAAAAEFcEBm7ySe9y1StQpr2siK2KosQLJ4EViLmqcOlmMXrHnFdPawk42aLAUwuqfVw45w==", "a4d7e2f4-a039-4e03-82c7-f77f3dbfbfa8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4596), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4569), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4569), "w&O.nCGvu^-.:qG[ZqJ{" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4605), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4599), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4599), "Rc@Wi#RzkS3D" });

            migrationBuilder.InsertData(
                table: "ClientImages",
                columns: new[] { "Id", "ClientId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("557b1f83-6903-452b-b644-3b5bd01a6c7a"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4796), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4797), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4797), "|aP]&x?sV{Z9NU" },
                    { new Guid("ca3b89db-cab0-4339-93b3-b25f9ba1230c"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4806), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4807), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4806), "yOIB1vB^" }
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4934), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4927), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4926), "!%P8+K" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4942), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4937), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4937), "*|;Q7r?v}=7;" });

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5081), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5072), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5072) });

            migrationBuilder.UpdateData(
                table: "Duties",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5090), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5084), new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5084) });

            migrationBuilder.UpdateData(
                table: "Fact",
                keyColumn: "Id",
                keyValue: new Guid("db3f7d1d-ec14-4d06-aea8-2a69ffe9ba6c"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4698), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4691), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4691), "Hkzlah'k*m<V" });

            migrationBuilder.UpdateData(
                table: "Fact",
                keyColumn: "Id",
                keyValue: new Guid("fe50fefb-8edb-4b5f-9e70-dcd4aec46a70"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4687), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4592), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4591), "(lP>r" });

            migrationBuilder.UpdateData(
                table: "Headquarters",
                keyColumn: "Id",
                keyValue: new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4889), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4880), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4879), "=G<C?+;XG:fN#<MgpwBH" });

            migrationBuilder.UpdateData(
                table: "Headquarters",
                keyColumn: "Id",
                keyValue: new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4898), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4893), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4893), "}$&6EH'c7L:" });

            migrationBuilder.InsertData(
                table: "LogoImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "LogoId", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("04888be2-8f63-45b5-b580-83726665b220"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5153), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5154), "images/testimage", "jpg", false, false, new Guid("abcde123-1234-5678-90ab-cdef12345679"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5154), "VOmKc[" },
                    { new Guid("c3c151d5-15a2-4db6-ab34-37a46ed4e7f0"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5161), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5162), "images/testimage", "jpg", false, false, new Guid("bcdef234-2345-6789-01bc-def234567899"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5161), "9MtddRGim-L3F0}" }
                });

            migrationBuilder.UpdateData(
                table: "Logos",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345679"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5331), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5325), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5324), "'WLGnQH5T" });

            migrationBuilder.UpdateData(
                table: "Logos",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567899"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5340), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5335), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5334), "5;-z.BtxG[(}AniB" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("0ecc0342-25cf-4f53-b64c-788eb22d832a"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5476), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5470), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5470), "c(a6=:lsm)rHOMH" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("9c8cea58-68db-4aa7-a54e-913ab047622c"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5466), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5458), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5458), "S)krmf3#jQ-jxC?" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("a501a204-6f7b-45a4-8fb8-969cd86e8791"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5493), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5488), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5487), "Uw.c#n@T-(#m!st4" });

            migrationBuilder.UpdateData(
                table: "PageSeos",
                keyColumn: "Id",
                keyValue: new Guid("dd40a305-995b-48ca-a7f8-133910fb72cb"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5485), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5481), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5480), "Wy<?Ox[8o!!<" });

            migrationBuilder.InsertData(
                table: "PortfolioImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "PortfolioId", "SecName" },
                values: new object[,]
                {
                    { new Guid("85a73ba6-3180-42db-ba2c-081c11bce3a3"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5702), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5698), "images/vstest", "png", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5698), new Guid("bcdef234-2345-6789-01bc-def234567890"), "y[PLEEM;@" },
                    { new Guid("dab315f2-8bfc-479e-91d6-fdc33e4ef077"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5695), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5689), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5689), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "*}sN,xg" }
                });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: new Guid("abcde123-1234-5678-90ab-cdef12345678"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6860), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6850), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6850), "&]KGP]$'#+%j&F2" });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumn: "Id",
                keyValue: new Guid("bcdef234-2345-6789-01bc-def234567890"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6868), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6863), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6863), "F]7_?-qg##o" });

            migrationBuilder.InsertData(
                table: "SliderImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName", "SliderId" },
                values: new object[,]
                {
                    { new Guid("32e85ca2-0ce9-4ee0-89f9-d23bbab48a2e"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3010), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3014), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3013), "V'Dd!FLX2T>=d;uoy$", new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57") },
                    { new Guid("c44f864d-d39d-4645-ade1-6f911f7f3359"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3034), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3036), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3035), "WA,pUYqp306o_]zqZ4t", new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2") }
                });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3166), new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3156), new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3155), "z'F;@D-8lFV" });

            migrationBuilder.UpdateData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3190), new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3185), new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3168), "Ju<>?feF[n<t]^1;q+k" });

            migrationBuilder.InsertData(
                table: "SmtpSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IMAPPort", "IncomingServer", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "OutgoingServer", "Password", "SMTPPort", "SecName", "ServerIP", "SmtpName", "Username" },
                values: new object[] { new Guid("98c70e67-b1b2-4ffa-8174-2f67367fd6cc"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2329), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2344), 993, "mail.batuhanulukan.com.tr", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2340), "mail.batuhanulukan.com.tr", "B5x8d2u~9", 465, "KfRHgi4h+^s.f$o^", "77.245.159.27", "SMTP", "info@batuhanulukan.com.tr" });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Icon", "IsActive", "IsDeleted", "IsMaın", "Link", "ModifiedBy", "ModifiedDate", "Name", "SecName", "UserId" },
                values: new object[,]
                {
                    { new Guid("7334e5c7-2925-4a78-b4d5-a868546b7c73"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3352), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3347), "instagram", false, false, true, "https://www.instagram.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3347), "Instagram", null, new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("e877ffac-b184-4bdd-a2a5-9100b7fe1202"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3307), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3300), "facebook", false, false, false, "https://www.facebook.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3299), "Facebook", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.UpdateData(
                table: "UserImages",
                keyColumn: "Id",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5030), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5025), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5025), "T1L56jU}L%" });

            migrationBuilder.UpdateData(
                table: "UserImages",
                keyColumn: "Id",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                columns: new[] { "CreatedDate", "DeletedDate", "ModifiedDate", "SecName" },
                values: new object[] { new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5023), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5017), new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5017), "^NM[" });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");
        }
    }
}
