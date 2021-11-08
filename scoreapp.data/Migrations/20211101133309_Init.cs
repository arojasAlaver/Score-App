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
                    { new Guid("a3942513-e2e0-4ca6-a0e3-c02a3f8e0dc8"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.User.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("849f8b73-eb20-47a9-a40a-4b5301e18bb8"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Role.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("1e5386a7-4ca9-478b-af1e-146234bda2d4"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Role.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab5f73a9-7071-4e10-bec3-4be55f72adcf"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Role.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("d12eaaf5-77e5-407e-b890-c8a58f5fd42e"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Permission.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c2a7799-6cc8-4670-a3ac-bfdd327f4c88"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.User.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("0bc92952-08eb-4303-baf9-c1f788adfc8e"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.User.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("131fe351-5680-49ad-8925-9e50deb52792"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.User.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("368ec5b8-7d1a-411d-a731-d5cdef785a3c"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Config.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("7ce75f0f-98fe-486a-9429-5734404b0b05"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Config.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1ae4940-0101-421f-b47e-4100f08fefc8"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Config.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("7604b0ae-cb90-4b6c-b90b-eee8467220d7"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Config.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c7659f4-81dc-46a1-9688-e8b6e5faa471"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Permission.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("e004bdb2-1aa3-43d2-92c6-9e544f144075"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Permission.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("20be5f0a-7176-4842-be6a-47d0608fd8a7"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Applications.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("35400278-9d52-461b-ad51-90b99a1f980e"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Applications.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb5e286b-be2c-4c91-8f9b-a9f76135ed6e"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Applications.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("b05bc5de-dcc8-419f-bbef-20d5ead9b3cf"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Applications.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b69cc89-4463-4715-87db-f7627c377b95"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bea32db-152b-49f3-af09-d45548479e79"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Create", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("16824188-348f-4113-8ce1-ae252bbeb82f"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Edit", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f56915b-45a3-438b-8c33-c759622f43b1"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7325fec-1e19-412f-a1be-43f01dbe889b"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Role.Delete", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcf791fa-1552-430a-b282-e7d5e16893bd"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Permission.Permission.View", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("da83f7b0-1229-460c-85bf-c289bbb6149d"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Basico", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) },
                    { new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Administrador", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Settings",
                columns: new[] { "Id", "CreatedAt", "Setting", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("06e05c48-5080-48ec-840e-cc4f84c1193d"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JmO6ZW5u8_0sQZabxM_jx0yHb6LrIozwASDDNLQfWo470Lmzkzf-rtySmsKVikoU1sEawS8tGMzB8JLv9od7pwVXWQxSEcuuFx1ZzJ5KFl7g", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IBXxn-XyvkPqm6gBkCz7Cz_q2AsKFIBGhSl6Gt9hiB6jXa8q-lvWIm98KXkvOPca5iHM2T_OKHKKbf4uyauXvtzYm5bljS4_jZcEHiL0ZXHA" },
                    { new Guid("82d10de5-9c41-4dba-aac3-c779859e0660"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LG-1nGaIizQDNdUAHFrSCIKtS-k9QVb-mVJw4CRZnjSreaL7A9XqGWkEP80Yl7ORhKrN_gKeObFVqx0yodMCyuctQVvQXHZpW25khf3dfqJw", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Injo_nJKtsAuujHAqeXRaeu1fBfceTMSS4-Uu36kgF3TkYsLZLiJZJb5gQ7skx-ElWifFYD4o6PojDAw65it-0ihy5YKrrfQcj1wKbO-I7Dg" },
                    { new Guid("e5965aea-ebe7-478b-84da-e72a2741b62b"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Izs0Shy-gtwlwz-P3Jx9tpUVKNYwTuTwHDgXzHVrwXlExjD4nI5wB5imE_qAB1tQbEw6Xru505CEJHgYtY0XJODEVt3HEbtb0x0e73n1rbUA", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Kod9uCUaizvWZH7m1Xbx226jYkMNx1pcGKJrfaJwz5mlvG20uuUzRY69QhuCJE_LkB0kvNy9qSQWbBKfNNM-I46K03u7y40KVlKydj6_pwpw" },
                    { new Guid("c2304986-a40e-4f93-a37e-bf8fdf32ec19"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KlV1uglBxIhuihUeFVyQFRfY4NJ3cuOn_-z7igcxfO8xQaDZhoaYR-8Xz2RZ3gvx0YfXyMhleChrjlkNfMJWeHkClKUyZFRpiMVv-ykc9xmw", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IYoinYE8mZdi2yNYv_nfIvmRXSbjZGMSH7k8u7OeWMEZFuIoBfPTjcBIZoBqAaNaBfXoLZJqe3VKHVf4iXv3IdnJvKayYVDu4_eRaJzCzlBPHskWiYgCGVDoeqPpozRaE" },
                    { new Guid("33320b96-5d8c-49e1-97c2-cc5173264e19"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IzS2M4XAeh-v8ZZa_5tMbiInNow7r7tlS4tqdaVEFXVjgrTtBVAYLGOCye402OeSa4tboeXlDbMhrCkRtLtVpvDSv8Q1-PcCavVnITEBiLvw", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6K2G-19LtIj3TAJtKMSl5ByVL_udRgJlQN1_b2VhzPScl6JpVpMluDAnMCK50--pCWMAt3oqBe85ztXL6MN6y_CHkk7tTecmVMyCiBBnQq71A" },
                    { new Guid("f8b07541-2ed6-48f1-921c-cd5c62ad38e8"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JqUEIL5jXTFOyG5ee3cHAhRts1M0aG3TFmT3uSeTPe53G5EZvv67bhI71aikf_D5La0ol0VXtu-9aU1vzWABp3p0q3LKGBtJXBGPQX1MwR4A", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LAgeu2lY_7etzSMTd5rOMfFAPguv_ztoRuBO2FI3ukGH9-Dw1Yd3dv6xI3SxfzJBPdcyMjRq6AHTH1Mpzlxrt7zRPg1m30DBzZq1SfW4yWEQ" },
                    { new Guid("cdeae839-ad90-489c-9d71-361689ce67ea"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6I5m5l4JfplZhiaAIUj2cdMEfhLf8FbkdZgHydarOYkXx5v0IcKkcQ1s0d_T3J1_zghRUz39dSxkehxdawCBAHl04qeIIN6WYMadbftI86i3A", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KgjMpBmPZqc2ZPCIr6lehhoEG170NoB3X52xGOSFmLlyDTICFDI5kSzPbajW6QABvqUkbNzJ32_YgU0DNJ_clxxCLNDJYWnwgHWvJKpLAJbg" },
                    { new Guid("c66b989e-fd2a-4c2d-98fb-4a33a975dad2"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JXR9gNF2G1TH8KoDxlVNv0CUGpEQtkjK2_zSZ_P0AJWLWYvMuHpkNu2Ieid6YWQvDYYwecy2gAwyyMCR_IuNqBXOS0j7xqODPVq6VNJtAdJw", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Ix9RiNZBj6OCUitNZS0DFvGLFYSXR0SjhmSth7YGqOsthGJJtnB8VjfaNOGodnJ6Le9sGh0yNgVETKp_Nt4J8decyOrJ3eSDGHaJbbI-pBQdAzLBzCnAGJRv38OktqLwQ" },
                    { new Guid("625f60d7-3476-4c12-a154-f8b4bd8f8705"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LcsCA-e7oafUtkE7BTZq065Mf_LpKii_sXR5NVWDbhCvON_6ULEplTGLx4rb7wdUc3EHw96tAEnQQjTGE3vKXEdQKxeSS7BU4kgtB3fHjzHA", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LaM8X_ki1P1KzKohLS4T-BzRr2IR9gTGZcNSrIe5ft1oXhP9JRAeYiub238BmUNaRyOhD_4wHNcD1bu-wGMxzf4gYW2F6ncMJ-SzcHZ8H0ux37WGmiGLx2vcIBi2-qE8G3i656Xl9K66gcI7aHBMY0" },
                    { new Guid("83b3898f-fb65-49da-bcd1-ed876419a455"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KfljevfytI-hkDiMkV0nb32RkXcbRWI_52xKdP9akiv97X_yskueXCTYsgdcAsq0Cmb7dUB64OIkymvVBz3-hE1hMJFNBUP78nUbTGRl0IzQ", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JBsdjwMRg2LSZKQuGfOkCCag-rdPjZWL1vR_Tzxf5PNvBO__dZonEcCK71hKJ8E-KCS3Y37nKcVKxCheQT1smd-TC4kNynb0qKlf6N8-WNEQ" },
                    { new Guid("00c05a1c-f27d-45a9-adac-734fbfd57f7f"), new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LMk2_nxN-VIlVnqTJF13XxPB8TnZEjxD9Qoc_-aQoypZ1kMzlwxc5nzOyuYmtf6R1Jc7i-7TaWCJ3_J4Jx5uXj_Dhm7NOTAcNyCSRLPCbtlw", new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LESiHIjqoY3iJFoj1H0OFVq3D-X4F0KWLMOHFTbQKwIK1VCEHW2dViVBie6wg_dW62-tMUpYA5Bfs-b2lqqZ3xnEiQc5FODGzTkYjCX89STg" }
                });

            migrationBuilder.InsertData(
                table: "PermissionRole",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("7604b0ae-cb90-4b6c-b90b-eee8467220d7"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("16824188-348f-4113-8ce1-ae252bbeb82f"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("7bea32db-152b-49f3-af09-d45548479e79"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("4b69cc89-4463-4715-87db-f7627c377b95"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("b05bc5de-dcc8-419f-bbef-20d5ead9b3cf"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("cb5e286b-be2c-4c91-8f9b-a9f76135ed6e"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("35400278-9d52-461b-ad51-90b99a1f980e"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("20be5f0a-7176-4842-be6a-47d0608fd8a7"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("e004bdb2-1aa3-43d2-92c6-9e544f144075"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("0c7659f4-81dc-46a1-9688-e8b6e5faa471"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("d12eaaf5-77e5-407e-b890-c8a58f5fd42e"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("9f56915b-45a3-438b-8c33-c759622f43b1"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("dcf791fa-1552-430a-b282-e7d5e16893bd"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("849f8b73-eb20-47a9-a40a-4b5301e18bb8"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("1e5386a7-4ca9-478b-af1e-146234bda2d4"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("ab5f73a9-7071-4e10-bec3-4be55f72adcf"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("a3942513-e2e0-4ca6-a0e3-c02a3f8e0dc8"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("9c2a7799-6cc8-4670-a3ac-bfdd327f4c88"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("0bc92952-08eb-4303-baf9-c1f788adfc8e"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("131fe351-5680-49ad-8925-9e50deb52792"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("368ec5b8-7d1a-411d-a731-d5cdef785a3c"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("7ce75f0f-98fe-486a-9429-5734404b0b05"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("a1ae4940-0101-421f-b47e-4100f08fefc8"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") },
                    { new Guid("e7325fec-1e19-412f-a1be-43f01dbe889b"), new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81") }
                });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "EmployerCode", "IsLocal", "Mail", "Password", "Picture", "RoleId", "TypeUser", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Alaver Admin", 0, true, "", "AQAAAAEAACcQAAAAEGbgwG8sr87WQQkdYRWd+L8nHYk4injPbNUctxdUvDZuxduTk94l/KG3UYpJ8HCu2g==", null, new Guid("2e4a34e2-40fa-4506-a46a-766d60e9cb81"), 2, new DateTime(2021, 11, 1, 9, 33, 8, 0, DateTimeKind.Unspecified), "Admin" });

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
