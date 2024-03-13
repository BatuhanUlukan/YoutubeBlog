using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeBlog.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headquarters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Choosen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headquarters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSended = table.Column<bool>(type: "bit", nullable: false),
                    IsInbox = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageSeos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSeos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmtpSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SmtpName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutgoingServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SMTPPort = table.Column<int>(type: "int", nullable: false),
                    IMAPPort = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmtpSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutImages_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Duties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMaın = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Duties_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMaın = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Socials_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSliderIsActive = table.Column<bool>(type: "bit", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientImages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogoImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogoImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogoImages_Logos_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Logos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttachmentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachmentRecords_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderImages_Sliders_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Sliders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                });


            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsConfırm = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PortfolioImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SecName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioImages_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioVisitors",
                columns: table => new
                {
                    PortfolioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioVisitors", x => new { x.PortfolioId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_PortfolioVisitors_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "Name2", "SecName", "SubContent" },
                values: new object[] { new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"), "Header", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2838), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2828), false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2828), "about", "Header", "r!weUj|jq6,N,=", "Header" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"), "b759d8a4-fa79-42c3-8301-5f3b3ebc9d39", "Superadmin", "SUPERADMIN" },
                    { new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"), "2b68f4b5-02b8-423c-b8a5-a01b003c873e", "Admin", "ADMIN" },
                    { new Guid("edf6c246-41d8-475f-8d92-41dddac3aefb"), "8d5d7a54-97dd-4fb8-9cb2-688174658925", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), null, 0, "ca5a8fcf-7394-4fd8-a020-785684f2a7e1", "admin@gmail.com", false, "Admin", "User", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAuUHQvm3QYVHKqMWaC6nbrYzn4Msy/3O5PP7iIYrOCFtTYQjdjLPxFrZR5HxyJ5zg==", "+905439999988", false, "ADSR45", "e6d57430-0761-4c2d-8426-c7d2b2455f7d", false, "admin@gmail.com" },
                    { new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), null, 0, "39483e94-e7d0-43ed-84f7-98310dd2ebac", "superadmin@gmail.com", true, "Batuhan", "Ulukan", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFcEBm7ySe9y1StQpr2siK2KosQLJ4EViLmqcOlmMXrHnFdPawk42aLAUwuqfVw45w==", "+905439999999", true, "BULU45", "a4d7e2f4-a039-4e03-82c7-f77f3dbfbfa8", false, "superadmin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "SecName", "Type" },
                values: new object[,]
                {
                    { new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4596), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4569), false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4569), "ASP.NET Core", "w&O.nCGvu^-.:qG[ZqJ{", 0 },
                    { new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4605), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4599), false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4599), "Visual Studio 2022", "Rc@Wi#RzkS3D", 0 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "IsDeleted", "Link", "ModifiedBy", "ModifiedDate", "Name", "SecName" },
                values: new object[,]
                {
                    { new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4934), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4927), false, false, "KARMOD", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4926), "KARMOD", "!%P8+K" },
                    { new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4942), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4937), false, false, "DIA", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4937), "DIA", "*|;Q7r?v}=7;" }
                });

            migrationBuilder.InsertData(
                table: "Fact",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Icon", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "SecName", "Value" },
                values: new object[,]
                {
                    { new Guid("db3f7d1d-ec14-4d06-aea8-2a69ffe9ba6c"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4698), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4691), "users", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4691), "Satisfied Customers", "Hkzlah'k*m<V", "150" },
                    { new Guid("fe50fefb-8edb-4b5f-9e70-dcd4aec46a70"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4687), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4592), "leaf", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4591), "Completed Projects", "(lP>r", "125" }
                });

            migrationBuilder.InsertData(
                table: "Headquarters",
                columns: new[] { "Id", "Address", "AddressLink", "Choosen", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "IsActive", "IsDeleted", "Location", "ModifiedBy", "ModifiedDate", "Name", "PhoneNumber", "SecName" },
                values: new object[,]
                {
                    { new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "SAMSUN", "SAMSUN", true, "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4889), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4880), "batuhanulukan@mail.com", false, false, "41.087770, 29.089148", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4879), "ASP.NET Core", "+905976543210", "=G<C?+;XG:fN#<MgpwBH" },
                    { new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "İSTANBUL", "İSTANBUL", false, "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4898), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4893), "batuhanulukan@mail.com", false, false, "41.112996, 29.021128", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(4893), "Visual Studio 2022", "+905976543210", "}$&6EH'c7L:" }
                });

            migrationBuilder.InsertData(
                table: "Logos",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName", "Slug", "Title" },
                values: new object[,]
                {
                    { new Guid("abcde123-1234-5678-90ab-cdef12345679"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5331), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5325), null, false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5324), "'WLGnQH5T", "asp.net-core-deneme-makalesi-1", "Header" },
                    { new Guid("bcdef234-2345-6789-01bc-def234567899"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5340), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5335), null, false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5334), "5;-z.BtxG[(}AniB", "vısual-studıo-deneme-makalesi-1", "Footer" }
                });

            migrationBuilder.InsertData(
                table: "PageSeos",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "IsDeleted", "Keywords", "ModifiedBy", "ModifiedDate", "Page", "SecName", "Title" },
                values: new object[,]
                {
                    { new Guid("0ecc0342-25cf-4f53-b64c-788eb22d832a"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5476), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5470), "Home", false, false, "Home", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5470), "Home", "c(a6=:lsm)rHOMH", "Home" },
                    { new Guid("9c8cea58-68db-4aa7-a54e-913ab047622c"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5466), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5458), "Contact", false, false, "Contact", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5458), "Contact", "S)krmf3#jQ-jxC?", "Contact" },
                    { new Guid("a501a204-6f7b-45a4-8fb8-969cd86e8791"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5493), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5488), "Base", false, false, "Base", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5487), "Base", "Uw.c#n@T-(#m!st4", "Base" },
                    { new Guid("dd40a305-995b-48ca-a7f8-133910fb72cb"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5485), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5481), "Portfolio", false, false, "Portfolio", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5480), "Portfolio", "Wy<?Ox[8o!!<", "Portfolio" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "SecName", "SubContent" },
                values: new object[,]
                {
                    { new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57"), "DIA", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3166), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3156), false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3155), "KARMOD", "z'F;@D-8lFV", "DIA" },
                    { new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2"), "DIA", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3190), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3185), false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3168), "DIA", "Ju<>?feF[n<t]^1;q+k", "DIA" }
                });

            migrationBuilder.InsertData(
                table: "SmtpSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IMAPPort", "IncomingServer", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "OutgoingServer", "Password", "SMTPPort", "SecName", "ServerIP", "SmtpName", "Username" },
                values: new object[] { new Guid("98c70e67-b1b2-4ffa-8174-2f67367fd6cc"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2329), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2344), 993, "mail.batuhanulukan.com.tr", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2340), "mail.batuhanulukan.com.tr", "B5x8d2u~9", 465, "KfRHgi4h+^s.f$o^", "77.245.159.27", "SMTP", "info@batuhanulukan.com.tr" });

            migrationBuilder.InsertData(
                table: "AboutImages",
                columns: new[] { "Id", "AboutId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[] { new Guid("31f7ad92-c656-488e-919e-528becc52048"), new Guid("3e008e90-80f5-48e6-bc1b-f5a49f20694a"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2679), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2680), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2679), "0p03d" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "IsActive", "IsDeleted", "IsSliderIsActive", "ModifiedBy", "ModifiedDate", "SecName", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("abcde123-1234-5678-90ab-cdef12345678"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "...", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3138), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3131), null, false, false, null, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3131), "<Mt&n?1BAT+4", "asp.net-core-deneme-makalesi-1", "Asp.net Core Deneme Makalesi 1", new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), 15 },
                    { new Guid("bcdef234-2345-6789-01bc-def234567890"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "...", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3152), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3143), null, false, false, null, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3143), "k1M-__-CW*W4<$d", "vısual-studıo-deneme-makalesi-1", "Visual Studio Deneme Makalesi 1", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7cb750cf-3612-4fb4-9f7d-a38ba8f16bf4"), new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("16ea936c-7a28-4c30-86a2-9a9704b6115e"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.InsertData(
                table: "ClientImages",
                columns: new[] { "Id", "ClientId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("557b1f83-6903-452b-b644-3b5bd01a6c7a"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4796), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4797), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4797), "|aP]&x?sV{Z9NU" },
                    { new Guid("ca3b89db-cab0-4339-93b3-b25f9ba1230c"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4806), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4807), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(4806), "yOIB1vB^" }
                });

            migrationBuilder.InsertData(
                table: "Duties",
                columns: new[] { "Id", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Icon", "IsActive", "IsDeleted", "IsMaın", "ModifiedBy", "ModifiedDate", "Name", "SecName", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "....", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5081), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5072), "eye", false, false, true, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5072), "KARMOD", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") },
                    { new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "....", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5090), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5084), "screen", false, false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(5084), "DIA", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.InsertData(
                table: "LogoImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "LogoId", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("04888be2-8f63-45b5-b580-83726665b220"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5153), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5154), "images/testimage", "jpg", false, false, new Guid("abcde123-1234-5678-90ab-cdef12345679"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5154), "VOmKc[" },
                    { new Guid("c3c151d5-15a2-4db6-ab34-37a46ed4e7f0"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5161), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5162), "images/testimage", "jpg", false, false, new Guid("bcdef234-2345-6789-01bc-def234567899"), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5161), "9MtddRGim-L3F0}" }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsActive", "IsDeleted", "Link", "ModifiedBy", "ModifiedDate", "SecName", "Slug", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("abcde123-1234-5678-90ab-cdef12345678"), new Guid("4c569a9a-5f41-478f-9d17-69ac5b02ae0b"), "...", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6860), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6850), false, false, "www.google.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6850), "&]KGP]$'#+%j&F2", "asp.net-core-deneme-makalesi-1", "Asp.net Core Deneme Makalesi 1", new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), 15 },
                    { new Guid("bcdef234-2345-6789-01bc-def234567890"), new Guid("d23e4f79-9600-4b5e-b3e9-756cdcacd2b1"), "...", "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6868), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6863), false, false, "www.google.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(6863), "F]7_?-qg##o", "vısual-studıo-deneme-makalesi-1", "Visual Studio Deneme Makalesi 1", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427"), 15 }
                });

            migrationBuilder.InsertData(
                table: "SliderImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName", "SliderId" },
                values: new object[,]
                {
                    { new Guid("32e85ca2-0ce9-4ee0-89f9-d23bbab48a2e"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3010), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3014), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3013), "V'Dd!FLX2T>=d;uoy$", new Guid("35a6ff13-92f5-4d82-b69d-77876edb1d57") },
                    { new Guid("c44f864d-d39d-4645-ade1-6f911f7f3359"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3034), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3036), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3035), "WA,pUYqp306o_]zqZ4t", new Guid("9653e768-1ea1-4f17-b9bf-04eac0bc88c2") }
                });

            migrationBuilder.InsertData(
                table: "Socials",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Icon", "IsActive", "IsDeleted", "IsMaın", "Link", "ModifiedBy", "ModifiedDate", "Name", "SecName", "UserId" },
                values: new object[,]
                {
                    { new Guid("7334e5c7-2925-4a78-b4d5-a868546b7c73"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3352), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3347), "instagram", false, false, true, "https://www.instagram.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3347), "Instagram", null, new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("e877ffac-b184-4bdd-a2a5-9100b7fe1202"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3307), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3300), "facebook", false, false, false, "https://www.facebook.com", "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 858, DateTimeKind.Local).AddTicks(3299), "Facebook", null, new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.InsertData(
                table: "UserImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName", "UserId" },
                values: new object[,]
                {
                    { new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5030), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5025), "images/vstest", "png", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5025), "T1L56jU}L%", new Guid("3aa42229-1c0f-4630-8c1a-db879ecd0427") },
                    { new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5023), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5017), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5017), "^NM[", new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") }
                });

            migrationBuilder.InsertData(
                table: "ArticleImages",
                columns: new[] { "Id", "ArticleId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "SecName" },
                values: new object[,]
                {
                    { new Guid("0b30156f-a7ac-4070-aea0-fcdadfb88cca"), new Guid("bcdef234-2345-6789-01bc-def234567890"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3006), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3008), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(3007), "ZLt{7bI!srWI3" },
                    { new Guid("d2a2c466-f8c1-4dbf-ba1a-2662819f03e6"), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2996), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2997), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 856, DateTimeKind.Local).AddTicks(2996), ".UCo7Q>ffggxIHMpl!,9" }
                });

            migrationBuilder.InsertData(
                table: "PortfolioImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedDate", "PortfolioId", "SecName" },
                values: new object[,]
                {
                    { new Guid("85a73ba6-3180-42db-ba2c-081c11bce3a3"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5702), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5698), "images/vstest", "png", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5698), new Guid("bcdef234-2345-6789-01bc-def234567890"), "y[PLEEM;@" },
                    { new Guid("dab315f2-8bfc-479e-91d6-fdc33e4ef077"), "Admin Test", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5695), "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5689), "images/testimage", "jpg", false, false, "Undefined", new DateTime(2024, 1, 31, 22, 4, 41, 857, DateTimeKind.Local).AddTicks(5689), new Guid("abcde123-1234-5678-90ab-cdef12345678"), "*}sN,xg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutImages_AboutId",
                table: "AboutImages",
                column: "AboutId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_ArticleId",
                table: "ArticleCategories",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_ArticleId",
                table: "ArticleImages",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentRecords_MessageId",
                table: "AttachmentRecords",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientImages_ClientId",
                table: "ClientImages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Duties_UserId",
                table: "Duties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogoImages_LogoId",
                table: "LogoImages",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioImages_PortfolioId",
                table: "PortfolioImages",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CategoryId",
                table: "Portfolios",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_UserId",
                table: "Portfolios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioVisitors_VisitorId",
                table: "PortfolioVisitors",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_SliderImages_SliderId",
                table: "SliderImages",
                column: "SliderId");

            migrationBuilder.CreateIndex(
                name: "IX_Socials_UserId",
                table: "Socials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutImages");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttachmentRecords");

            migrationBuilder.DropTable(
                name: "ClientImages");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Duties");

            migrationBuilder.DropTable(
                name: "Fact");

            migrationBuilder.DropTable(
                name: "Headquarters");

            migrationBuilder.DropTable(
                name: "LogoImages");

            migrationBuilder.DropTable(
                name: "PageSeos");

            migrationBuilder.DropTable(
                name: "PortfolioImages");

            migrationBuilder.DropTable(
                name: "PortfolioVisitors");

            migrationBuilder.DropTable(
                name: "SliderImages");

            migrationBuilder.DropTable(
                name: "SmtpSetting");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Logos");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
