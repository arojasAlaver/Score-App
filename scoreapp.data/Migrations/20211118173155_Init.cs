using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scoreapp.data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Audits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Persons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Indetification = table.Column<int>(type: "int", nullable: false),
                    cel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cel2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Municipality = table.Column<int>(type: "int", nullable: false),
                    Marital_Status = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<int>(type: "int", nullable: false),
                    LastDateBuroConsult = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Buro = table.Column<string>(type: "xml", nullable: true),
                    Dependents = table.Column<int>(type: "int", nullable: false),
                    Dwelling = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Setting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Vehicle_State = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Variables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Variables_tbl_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "tbl_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeActivity = table.Column<int>(type: "int", nullable: false),
                    TypeJob = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    Municipality = table.Column<int>(type: "int", nullable: false),
                    TimeInCompany = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Jobs_tbl_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tbl_Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRole",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRole", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PermissionRole_tbl_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "tbl_Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRole_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployerCode = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeUser = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Users_tbl_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Incomes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OtherIncomes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcceptCondition = table.Column<bool>(type: "bit", nullable: false),
                    Terms = table.Column<int>(type: "int", nullable: false),
                    AproveAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Office = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutiveAssignedId = table.Column<int>(type: "int", nullable: true),
                    OfficialAssignToId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Applications_tbl_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "tbl_Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Applications_tbl_Users_ExecutiveAssignedId",
                        column: x => x.ExecutiveAssignedId,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Applications_tbl_Users_OfficialAssignToId",
                        column: x => x.OfficialAssignToId,
                        principalTable: "tbl_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Applications_tbl_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "tbl_Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationGroup",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationGroup", x => new { x.ApplicationId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_ApplicationGroup_tbl_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "tbl_Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationGroup_tbl_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "tbl_Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_Permissions",
                columns: new[] { "Id", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8f99ec0b-0f93-46fb-9ed2-08c3085ec8f2"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.User.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("979da608-7b3f-4d9c-81ef-54f748e7fd21"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Role.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0749ed5-ff63-4a62-b7ac-3fb44fb9bf5c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.User.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d715657-5ae3-408a-829c-dfc61ce36d93"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Role.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("05e6c31a-21cc-43c5-97e5-3cfbe3ceacd6"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.User.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("58ec21de-f92e-4f5f-ae1b-ee2d3dd06b09"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.User.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7120b1a-3638-4816-b3bc-8939f121362d"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Config.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("10894c85-8e6f-4bf6-b57b-c9c26a88282c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Config.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("a86c6d87-6cfe-4b61-ac8a-2e494cad6e62"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Config.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d30dcd5-6caa-4c3f-927e-9b74ec3dbd1b"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Config.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ec758a1-3fd4-4200-aee0-c1e8853db644"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Permission.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("02b23fb6-06c2-4ca9-8a3a-a47acc4f8f3c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Permission.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("96a1f3fc-1a48-4918-898c-a24a1e7b0c5c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Permission.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("63fcfdbd-418e-43eb-95b3-8803eaccb24f"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Permission.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("0cbb8256-0147-4b4f-8240-4505ef3ce2e4"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Applications.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcc3c0c5-d524-428d-867f-5b7e909840e6"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Applications.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("150b5467-09f9-474c-b7ce-e179d91458e5"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Applications.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecfea994-c649-478c-b4b0-72465b6b3910"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Applications.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("4c2f1041-4f18-41e8-978a-789d23d857df"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.View", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("8344a1e9-8c82-4bc0-b0cb-4549c06b3ee3"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("3daf11fc-3c5c-4a81-af64-ec05338c731b"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("0fa779b6-694a-40ae-b1be-20101b686ad0"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Delete", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("0099af76-2702-4049-af18-faf8562335f2"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Role.Create", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ded4347-b7ea-4851-8656-7f052f12552f"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Permission.Role.Edit", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3b56da83-2a7b-4b5d-90d4-6335697f9dc4"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Basico", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) },
                    { new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Administrador", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Settings",
                columns: new[] { "Id", "CreatedAt", "Setting", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("ccb4f87d-9766-4a45-97db-35c962a9d704"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JWrFrMZE0RSXIRzXXQhgOGyyo2vKwrbgvHZnsKu5HJYZ6qylM2XSKLuVhR9PATqzUx-p3P9LRtRChdJ-E_PLZiJfKzENHS1_zjz1qvIawbYQ", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JGUpIm328QzMqgA3IYnJ_gq3Efww3grHkNk7N84RmI5qgJCdo4iMXJCYzln9CCzLQUJfO2BUsZe5cGKc0l5eHKmMafF8YCc8eBrEiR9RiAVA" },
                    { new Guid("e4231c1c-6f07-411f-a742-741bad8ee13d"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JUD5Mkb498xOaHmykzWxEtBYiXOzXKwRfxuTNkJb3weYFs_d8FaM62h4aXk-dyevWFcE3srNCq9s0rdpa2d8fWsKxmN5qcjmybIU_Z3rKyIQ", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IxWJSTQtVBkqftysLaUkM23Gn1Bvvfq0eudsyHyUNlzV8iowLzO4AbvlycyuXvZZl8h2WG_TxMgtFbNX-TmNL4hYiaGJf_gHwuUlwPRvC_2Q" },
                    { new Guid("36c865ea-6c4f-4885-aba6-15fe2e23b375"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JrT3v0qzBpqbA0JPqgR1LdJgD3GUtVU-0IKPKwFTBxcSLVWKWutNRlqRZeMyBjUyzDjwaA6E17vmBbBu5iJD3aZVtF85_BbV-lECi4TAuExA", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6ISluadAM9ZqERTRnJRZHnuyKLqrRoLzBsq9fVGE4uF1lHKJq2Qu8ZT4dKQHySlFJfUhziLZ-jUCzR2EsECejF0TmRiGBsezIs29scndxIs8A" },
                    { new Guid("0f95cde9-32c2-47f2-a2ba-3a11730ee8c5"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JCwGn9Txj3KiOX52j4A88LVctLlkkNBeAclPZV_T0rbHhDAWjAnfR3NS7x5AxAczdXQN6NsS-o7UnYSDuE5-Ub656DcOxSgZ8iZuLJDmVaOQ", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Lo-_IQpMt5Sx3GDfk4KWchcLUrhxJQ2zrGnok5htYij7Yz1KEEWAKtVrT3-NlT6pV_OxmGh__9qcUimzoK_Rnd_PJgq5omnGccJK6SzZPt-w" },
                    { new Guid("8058131f-0cc7-4851-8496-a99a4935c7b4"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6I-AUr3UdEgwvN80Iq8hsuHi0NKr94K3o1xLRVsVNAhsK3oJt0M8Sybuue5qDsAf7P2lAodITC-TlSuKlcTzpGLiF2-qa26XmiOHS3oDfKqAg", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IoxVEsoiWATv_xCXJIMft8p3Gv6kVbYJEN2fK6fZbrk7BD1exJp_MgskKl-4yAlM1ztswB5-tws5UtXkVcIuYqIKDZwRyqF2vuMpv0fjM8qQ" },
                    { new Guid("7082c497-df01-4f35-8599-720ffb76a561"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JyMvyAiYplx85xDQ9KRdC-aCkuMqK_WR3q6RFsNXG8ZBjiWy5nyC67qKb98f9s5A3Zn4IXLt8sAVWI5RdUN97DuThJICs_3TredtH4jsCVMg", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LetG3RD08FzbCsQZvj3HONXgIdQuDy0Pks-a43qsbBa98QQ4HtsV-TpTUkF6JZNFiDz4AG55Ycw39dga7MDgFFkHHGZuMb24hOLQsBst12PrhW-zqFpSzAtFfbXvJkkTw" },
                    { new Guid("e8eda6db-3b2e-4e17-9c07-9bde7ba2c5e0"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IOGHbjYmGRjIrgfSPRgGu_3x9spDZTN3KPhFYBzwsQNz1hBCFyvu_AH4f_br0DvzqtCAEhBu7AIhSq1ZPsuPuQ3w8KPMrmzha77hsm-XB9PQ", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6I_qxc-9NE1EMb_WDoCWM05tgLEOlAgKbvdLiicfuUuZvJ9X1_Oh1WYp5a-ivhOm1ayia6KZ1aDdSTImduQxETZd9qeFx1H-TuJlIIrIDWi7w" },
                    { new Guid("3df2145f-db63-4696-ae3f-8c3e4627c0da"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IcYVuxvG3A24kLiDwyC9d13zJmG2Lwjfghhsx8jHh_qhJUxfD9G_2GGauB2u_jk_-g2WsbsHcmTIes15-ZnlLhLyvWVTaY2RBLFOJ9JRQCZw", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JHAc7bXneHBD2n6ivckIsNDSSC64P4MUtfKf7sA054lxwrk3ldab5Qf5ab7naflH0pxEBxgfhyap4kRh5Fd2IjZlQbEj3rDonfrTcjllOpuQ" },
                    { new Guid("1967261a-b8eb-4c9a-b32f-2adb68438996"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KKZU_tPIbnzk9kUncbjDm_y3kts1rucn6cBdfvz_0Ed-AtivrDDAxUizu1zJfY8PO6DKlYktzzeWterAOjxzg-tNI90YoY87q9L_8zjixhbw", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JVL7_1yp4fgG96zHZ-LukFt-LcSEigm83QEBZHYtyc6rYFHpp-4cBzH8QBjvZDr233VUhuMhaNP5EqHrpkhz-aRZ5HAu9Z1-SFyMciBIzqoQ" },
                    { new Guid("adbe2283-ccff-4fbf-96a6-da4c6ab3829c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6L9QN3MAdjye2Cm2Rzekkamm3ci8gfJUC3ATR2OiNs0dhZxwPu7SnJRNEFgvdkrdrNRPtwfg9aNDleakf2uw-DwRZO3Lg4o6z4JcCREFmhcpA", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6L8zHSWp7y5xA7RK47F7_1HAx2pSjQWbqLbjfLtZXN8671UQ4dE56HHg0OUpa4Iygw6rllj2tSPmAq4RePEexP2i_CoxgOsFN-OY7riCBqs6h7jb__72npPIIAFZaBTGG4" },
                    { new Guid("1c223078-66b9-46a6-b929-41b54235d19a"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LRxr02zFuu-FEiKqXnKaCNsEFBcE-0F_38AbyBNkNYNZEQWWMM7kUeBGOF7wM5_b7V8kqoZ5_N2UG9U4EkxV8lRzrcUvQUN6W70vNzpv8CPw", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KP3IDADvGulc7mWI1F26UP7tdZ7oKL7F9o4ZmKTJRFH5uVYGhnfC6PoQ5awsSfOjd6RjUemq-7vkSwlluO76cm3abwW7MGi6C3BCTcRV2ZvvbF3_ECK1VEc_pZCzURAO6rb4lUylxMi3VXWz08mZ32" },
                    { new Guid("4fdef907-1bf6-4c72-890b-9e24c098be4c"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Lo8uloRGygR129GFbUGCwielTrEwDghDmHjcjdaKXOfSNURqYDkQlS5ObUzi7UNmog-E90TKT8RhvwbBG4eTcWywuLNsX7HhdxWh35UHQ7gw", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KcSzHrNa5Lk7qiHvJ9JjVfu4UpT8XN1OJYTX-NbEd92SCLaMVuag25Aks2SHOm-FgjpmBmBOXI9l8EQhuVIEYDLBD1N7qcsGr--cb25ggIUw" },
                    { new Guid("372af82f-a3e7-4dc8-bdd7-9df08e5f3d7f"), new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6J_K7xw7Y_KPBlla5PeT-yiFie9DonqOyDeknHyciGWMgh7lReb4mBiGF7Guq3FXr865TawtP65CEO2jK0o5vd8jE7vBSaasCIL0k2zmjmOPw", new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LjSV8Q6fVCZxKtJSHAdJJpLVuVD8YtDl8Oum3jAW5_QG-Ki7KlQWxMCdNECNiitk2HmvVKzdXwsyilVXoeNzQl-JaXx-Pd0WMPXAYJAJioUw" }
                });

            migrationBuilder.InsertData(
                table: "PermissionRole",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3d30dcd5-6caa-4c3f-927e-9b74ec3dbd1b"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("3daf11fc-3c5c-4a81-af64-ec05338c731b"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("8344a1e9-8c82-4bc0-b0cb-4549c06b3ee3"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("4c2f1041-4f18-41e8-978a-789d23d857df"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("ecfea994-c649-478c-b4b0-72465b6b3910"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("150b5467-09f9-474c-b7ce-e179d91458e5"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("bcc3c0c5-d524-428d-867f-5b7e909840e6"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("0cbb8256-0147-4b4f-8240-4505ef3ce2e4"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("63fcfdbd-418e-43eb-95b3-8803eaccb24f"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("96a1f3fc-1a48-4918-898c-a24a1e7b0c5c"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("02b23fb6-06c2-4ca9-8a3a-a47acc4f8f3c"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("0fa779b6-694a-40ae-b1be-20101b686ad0"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("6ec758a1-3fd4-4200-aee0-c1e8853db644"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("1ded4347-b7ea-4851-8656-7f052f12552f"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("0099af76-2702-4049-af18-faf8562335f2"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("979da608-7b3f-4d9c-81ef-54f748e7fd21"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("d0749ed5-ff63-4a62-b7ac-3fb44fb9bf5c"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("8f99ec0b-0f93-46fb-9ed2-08c3085ec8f2"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("05e6c31a-21cc-43c5-97e5-3cfbe3ceacd6"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("58ec21de-f92e-4f5f-ae1b-ee2d3dd06b09"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("d7120b1a-3638-4816-b3bc-8939f121362d"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("10894c85-8e6f-4bf6-b57b-c9c26a88282c"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("a86c6d87-6cfe-4b61-ac8a-2e494cad6e62"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") },
                    { new Guid("0d715657-5ae3-408a-829c-dfc61ce36d93"), new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616") }
                });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "EmployerCode", "IsLocal", "Mail", "Password", "Picture", "RoleId", "TypeUser", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Alaver Admin", 0, true, "", "AQAAAAEAACcQAAAAEC3lmvKXh86UnRchBeHumOLGcSITdKq+V5doEYUUl3yi4S9qvgd1yftPVRxhcokyTw==", null, new Guid("8e140b84-2336-48a6-8bac-6af0ad2ee616"), 0, new DateTime(2021, 11, 18, 13, 31, 55, 0, DateTimeKind.Unspecified), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationGroup_GroupId",
                table: "ApplicationGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRole_RoleId",
                table: "PermissionRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Applications_ExecutiveAssignedId",
                table: "tbl_Applications",
                column: "ExecutiveAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Applications_OfficialAssignToId",
                table: "tbl_Applications",
                column: "OfficialAssignToId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Applications_PersonId",
                table: "tbl_Applications",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Applications_VehicleId",
                table: "tbl_Applications",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Jobs_PersonId",
                table: "tbl_Jobs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Users_RoleId",
                table: "tbl_Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Variables_GroupId",
                table: "tbl_Variables",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationGroup");

            migrationBuilder.DropTable(
                name: "PermissionRole");

            migrationBuilder.DropTable(
                name: "tbl_Audits");

            migrationBuilder.DropTable(
                name: "tbl_Jobs");

            migrationBuilder.DropTable(
                name: "tbl_Settings");

            migrationBuilder.DropTable(
                name: "tbl_Variables");

            migrationBuilder.DropTable(
                name: "tbl_Applications");

            migrationBuilder.DropTable(
                name: "tbl_Permissions");

            migrationBuilder.DropTable(
                name: "tbl_Groups");

            migrationBuilder.DropTable(
                name: "tbl_Persons");

            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.DropTable(
                name: "tbl_Vehicles");

            migrationBuilder.DropTable(
                name: "tbl_Roles");
        }
    }
}
