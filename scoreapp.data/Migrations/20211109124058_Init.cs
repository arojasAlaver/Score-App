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
                    { new Guid("e9255b28-b18a-4ded-b05f-71bafe72bff3"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.User.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4b6c506-2ff2-407c-8bb6-4243f10bf254"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Role.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc83b4f6-dcc7-4ab1-a9f3-e0428e6b93ee"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Role.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("663b706a-449f-4a9d-acfe-005e9392e3aa"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.User.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("a64aa401-7ad4-4147-ba7f-d59262b992dd"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Permission.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("605611e4-e294-40c0-8e10-9508ffc777c3"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.User.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("96588204-bb74-4da6-8435-8a68d9c7483b"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.User.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("54d1b147-ad48-49ca-8f24-a948abd48e06"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Config.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("08f89e69-22a1-416c-bba9-f879a95a0a76"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Config.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("72cdd7be-5544-4227-9845-b936a5329fe0"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Config.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("61b931f3-2c95-4721-b7a8-1943017a2131"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Config.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("8bb1e7a6-4f17-4a12-a81c-79a8ae598599"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Permission.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1e6cfec-9590-4953-b31e-387cad717f05"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Permission.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("600a3c17-7276-488f-961b-12fdff516a0e"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Permission.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb2c0823-1040-4b1b-b930-29919ba76be6"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Applications.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("16c9d900-0780-4ec5-b4e6-aaad06a5c42e"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Applications.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("39f78798-bcf0-4b0e-829a-99400348c7ff"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Applications.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("939bb875-21bb-481f-b55c-86f848244e49"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Applications.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("f243f0bc-3452-4e3d-847f-6fd790050bb7"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.View", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("46e18edf-5afa-4959-b872-3849679e3ba8"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Create", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("695a94c6-6b1a-40f0-b9b0-b627f0ee3209"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("4830b7b8-3f90-4316-be0c-27f3eed311e3"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.GroupVariable.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e890718-0077-4b75-aa27-40324a9a4420"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Role.Edit", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b487ca9-257c-473f-ba0f-13dc37a2f8d7"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Permission.Role.Delete", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5c3b4a97-f3cb-4cc4-ad9e-87a144cbed18"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Basico", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) },
                    { new Guid("963e229d-a461-422c-931f-b364f70dab0d"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Administrador", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tbl_Settings",
                columns: new[] { "Id", "CreatedAt", "Setting", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { new Guid("37c20aad-a46e-4e38-b12b-09ce99eb855c"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IbvAcdxlC5H_ICfOrErxnywJuHhIDsuF4ilWU02vCzplmD4EVrsWmh46iZ5Ez5pGNwDEczhhTLmtccEzKcVxq4yYLuE9h-u8MWQKPfJvJGZA", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IQKOloMVnrQ5pFfqLAfRN6uJlgKyw0TJXLTg5D7VzvEPzbxwUW93mVZaBtJJz-uO_pjBr0xr4AvYtRq76KHLmzksL_TOAblTakNfQ6R6JGQw" },
                    { new Guid("3beb5cc7-17b7-4263-bc37-fa8824c12322"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KghKDsfkccqV_rws2dzqlfLMA2FvTqvOScJjmNYUJnWSUunnZDcVzjVlcJakgFwF_Hw5-1PUVMCxCVqWVmB7iwHkny2AxTA0a8nNf27JddEA", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LMeIfUtZYdVQrzyevxmw3A4ftME53RKBup7faZnMGRMGGr66xtah3ncvayfy7Y4coiXufJ7TmNeRrm-yk1AjWLLPdjtdystySemJCceWC3YA" },
                    { new Guid("2ecfaab4-763b-47e7-9873-eea52975c0c4"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LJdw5xeUSjF8BoGleV4CbZzgwgD1H7Q4PEbmoUBASz0am9ewBQQQR-kJnZnNELVE_OVPi_5JdPNfa49ZXRO3NYbHpUQdSe_RTfAQgOEaHt1g", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IrMRtmVeXLq-5sdysYOT6eCPXrhioj9Pyics4QCcjKHI1KDdi4fTbcESEudCzh6Ho5zAlRK3Cqg_HByOimSy9tkh97y8idPlA_H-PwGeUqOg" },
                    { new Guid("a960a5df-ef8d-4364-a2a4-971610b2c5ab"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JwKV-o0E_r5NlpQ6CJI4DH-z_9tFIozzXbWERSaID1oPCj1krYyugIcd0X26J92iors9nqsITwcpgT5TFnK5L5wQ9hH267jvsXZW1HD42eqQ", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IWeTCwwgscrBRP5sf0QnYu8YsAbKvTRYBT41W-c_9vt73wtl4Y5GDn2e4jMQBIapIKBxNJaGbsB-ZPY3FnTqta2HLxhF7fSpVA3IIcPNYoPQ" },
                    { new Guid("96879612-0b86-42c1-be9f-6f0661a31766"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JwBMXRhd5eeL9jIpSbQ7XL5_Q6Zp-Zck1u9D2ARYxhTSOR-Dz-RuyOAdox2h2QE0CeVjhtQVGcChDmwnhWmM2e-mTMJ-a5EX9AVyjlsN2JxA", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IiYbvT7hqHtYLuafGZlSR7fPTPZsfyB31bGjLIahUEAXfuIgrRtX7MV2y1SYnqOJsmH1TAJe5pw09Wu7PTuVu6ayQVpcJoNchfEVa45fL-UpMERrmpn-h3W_pkYiQ1aPc" },
                    { new Guid("d18e163d-6e62-44b8-bf57-a375dfa0279e"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JHa72ZSl95tz31-yoKglZ9g-CF6l63-CnNU8Go3ADbRAZN6ArEuEf2uuOnSggPDE6TcApC0_0orTf4ePvxWZpacICybHaUDTaKQYKVz5e-zA", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6KueyB0FKyPB5B0rxPs0x_JpgWryk5rtn5wcf70EtsN9TI8vWLg40DzpB5GE2YN_E752ldpyagVIGem56GMs9byIaEsJlKdXW2NHtZHscUHOw" },
                    { new Guid("ab934932-cc29-43b4-9482-c1046235e374"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6Knq-qDy2QqDMKvynlyBv_88nBVhWuRuO_obk52vr2sfOOGU6L_pwjgzOZfBiiB5N6Fyal3xROpeKWmL9RRTEWxZLiGgRDh5KwVKrD1l3UcWQ", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6JP_TaOlaAKxo26IQtrgO0Tw1znbw1zMNkPOCs5FRxOmGWSruYWuSLG1FEOKyzt2iamMYN2NV7BBu5bySI3kqgnwUmnWOEyKXTvnaa4v5FQ-Q" },
                    { new Guid("c678979c-a7c2-4c39-b712-65511a965c4c"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LB2U1DVHuQP753nmSNPyq24gWZMZwVMzpLJ-qt6EUg0DKFdDSe8JlZo5cN0B7F84r6QmGUOXe0Or0cWHcPlCzKQt05qb5TY_5a-fe-2eSgHw", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6LLeKijkP5QDlCY6KpFKjJzEtNacQeoS4QYwlD912d5Sfl4Pvf-zWIk0XMd6yXQHQeasuk-27CaAeB7zyftmTajWpUgW8Zs6opi5zgaXsGWIg" },
                    { new Guid("2c3b3b21-0981-4889-96a7-01ec9a9cf833"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6I3i76QQhuabGhYQMYSsFANlAtpYin5_he5SIg6MDyLu20L3sMbcuHs9yTILwMiftM68ZTOrCdyEaUc7Z43idyUoHBaqWb951A0Sp5eh9tIaQ", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6J9rg2zr63BC4FeaCpqvNQhG8c04yUe4YR3Zyr93MGgvEAMntLaQvjTk8Wz7j2XDkGSD0Vg474adomh_Hv5PNiOJ3sN8cFbadARIyXH_E8VsPSW99E0liXxdN83QxDfE6E" },
                    { new Guid("4a23f822-ed7b-4816-9757-caa866f5f35c"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IrkKftn8a4sBFhlk8FQTxzD8r7uyqlI-Hr-X88Hpn2JC3XNFmaISFr9gRO3py4GpLs3Q0Am4df88SwkOu3QegBlNIQKTmO5kHSTuznWcV27A", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6J5LOzxbXUUmOnh96usGtbTQiEz6uGl0k-GNjqwlkx9p2IyUl6evSQZbozF7WD6wUp-JlQ0qkIp0DtjdsT0rOTZaybMjH2XOmzJcQNO9DUfgVyvT1gB2NL6GYHHITjUG1sOduESlA3Gu6fVNfGG90FR" },
                    { new Guid("6ad8a77e-f6dc-4aff-aa90-cd82af44f260"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IXhO-AvNqPxaPG-QpN4liOkjC67ZfZg4JkdB1okJBdA4ljhr5dqy6ewpfo_cUq3M6X8Xlry2TtoNNQY-lSCcINqtTJT2jvVuQhPzmFQH0epQ", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6IFVmaGsPtUNGo3BVnWDkvx2h5bDG5Eq9m_xkV8BDi8GjTtbtqqkqM1LhrlLZvLItvn_OssnSBVZTYZUeYHUszVca7eImTi4hDQpZyUn-kmuA" },
                    { new Guid("877ac9af-0c4f-408b-bb69-9409f440f3aa"), new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6J3CVrTsWrWo82AHNJgUw3R-O3-G5U98z6rajhJ-ekcZtSyFU2s7CN4O5uYMKKUfD1NgQI6Fvh2mF9IaiaA-y-uvLdCRPeoXPVP6wDoZR6t_Q", new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "CfDJ8K8zXOoJ6PVKg0EdUGTqX6J67HD0GY5C8B340HwjVPPV_7Cg8XEog7S2ZVz7lygwx-5sO65VaSqoSc9EvVdJFtl9_iVtP2Uxhki4GJ2ln-EOdEJ6hcM0XFjJQHxVRLbLfw" }
                });

            migrationBuilder.InsertData(
                table: "PermissionRole",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("61b931f3-2c95-4721-b7a8-1943017a2131"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("695a94c6-6b1a-40f0-b9b0-b627f0ee3209"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("46e18edf-5afa-4959-b872-3849679e3ba8"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("f243f0bc-3452-4e3d-847f-6fd790050bb7"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("939bb875-21bb-481f-b55c-86f848244e49"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("39f78798-bcf0-4b0e-829a-99400348c7ff"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("16c9d900-0780-4ec5-b4e6-aaad06a5c42e"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("eb2c0823-1040-4b1b-b930-29919ba76be6"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("600a3c17-7276-488f-961b-12fdff516a0e"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("c1e6cfec-9590-4953-b31e-387cad717f05"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("8bb1e7a6-4f17-4a12-a81c-79a8ae598599"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("4830b7b8-3f90-4316-be0c-27f3eed311e3"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("a64aa401-7ad4-4147-ba7f-d59262b992dd"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("3e890718-0077-4b75-aa27-40324a9a4420"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("e4b6c506-2ff2-407c-8bb6-4243f10bf254"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("dc83b4f6-dcc7-4ab1-a9f3-e0428e6b93ee"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("663b706a-449f-4a9d-acfe-005e9392e3aa"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("e9255b28-b18a-4ded-b05f-71bafe72bff3"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("605611e4-e294-40c0-8e10-9508ffc777c3"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("96588204-bb74-4da6-8435-8a68d9c7483b"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("54d1b147-ad48-49ca-8f24-a948abd48e06"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("08f89e69-22a1-416c-bba9-f879a95a0a76"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("72cdd7be-5544-4227-9845-b936a5329fe0"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") },
                    { new Guid("0b487ca9-257c-473f-ba0f-13dc37a2f8d7"), new Guid("963e229d-a461-422c-931f-b364f70dab0d") }
                });

            migrationBuilder.InsertData(
                table: "tbl_Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "EmployerCode", "IsLocal", "Mail", "Password", "Picture", "RoleId", "TypeUser", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Alaver Admin", 0, true, "", "AQAAAAEAACcQAAAAEDdhb0xCdqgDnzNTZTZrEfuK9ojTKqCbQh77/lwB/QWoxSQQ3s+nMZSXTcyPO53tYQ==", null, new Guid("963e229d-a461-422c-931f-b364f70dab0d"), 0, new DateTime(2021, 11, 9, 8, 40, 58, 0, DateTimeKind.Unspecified), "Admin" });

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
