using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShepherdsPies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cheeses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheeses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sauces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sauces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SizeCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false),
                    TableNumber = table.Column<int>(type: "integer", nullable: true),
                    DriverId = table.Column<int>(type: "integer", nullable: true),
                    TipAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DateTimePlaced = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_DriverId",
                        column: x => x.DriverId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_UserProfiles_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SizeId = table.Column<int>(type: "integer", nullable: false),
                    CheeseId = table.Column<int>(type: "integer", nullable: false),
                    SauceId = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Cheeses_CheeseId",
                        column: x => x.CheeseId,
                        principalTable: "Cheeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sauces_SauceId",
                        column: x => x.SauceId,
                        principalTable: "Sauces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pizzas_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaToppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzaId = table.Column<int>(type: "integer", nullable: false),
                    ToppingId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaToppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4720b947-07cb-4dff-8c96-dfc5dba209d8", "4c42fad9-bef1-4698-bad8-977465e5188d", null, null },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "8963bb06-1059-4cb6-afb1-ed28df713223", "Admin", "admin" },
                    { "f2498ab4-e4b6-4e61-92c0-9568e96a8145", "764017eb-68b3-4eb2-9c7e-5c4bc363458d", "Courtney", "courtney" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6a2f5d0b-3eac-4dab-ae9d-7f26d77e4a8c", 0, "1f7ceff1-886d-47a7-8154-bcbd5e113910", "rick@gmail.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAELDRv+5zTX7q6qPXOlBnwTBl5P3WtVLdxSnHG4EI/3TzowTkzGCHioFWViSebIBo5Q==", null, false, "8d26cad1-ae8a-4330-b80f-07f816ab31ad", false, "Rick" },
                    { "a7bc4dd9-8f10-4e24-8c0c-ef09a24ec9a5", 0, "56e33f95-64f4-4cfa-a019-5adbc2cb6c15", "sean@gmail.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEHcOHTCCfqg5mr/YbTShFJy+1/lYXIna74sqH+u8d/3jLDWjgqoHE5mFvnjnHIaZYA==", null, false, "ddd9a983-eccb-4009-ad8e-912eb388bcc2", false, "Sean" },
                    { "d9b5145a-739c-42d3-9e94-d2d439063d7e", 0, "1845aff6-af09-41e9-9e7e-179a97a47634", "jeremy@gmail.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEG9Xh0C1i/U+tGX2rwPkwf4B2HYwwVOiOdYpLug0YC/Mdq4HtxrYEWW3xH+veYBDzw==", null, false, "67e71b5a-cf09-4d6c-a104-194832854d33", false, "Jeremy" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "ff905e18-090b-4d7b-b685-e4e99121b3eb", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENfafNZWOhENHLF8qVdnBps94NDTrNI8vlpzWP9DmvN106bL1ZQattDaXkcmBkJPrw==", null, false, "c55bc310-e817-46d6-8b38-4cebed20f478", false, "Administrator" },
                    { "f2498ab4-e4b6-4e61-92c0-9568e96a8145", 0, "f773cdb4-d766-43f5-82d8-7b0a2984dd4f", "courtney@gmail.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEF8+etH0O1adMHS0mpa8BgDYtpoFL4F5cVV1JmUO0omCsGjGYLAViYP03A3rBRYjKw==", null, false, "c7c2f4aa-3efa-429b-95d3-ec0a8ba0bd2d", false, "Courtney" }
                });

            migrationBuilder.InsertData(
                table: "Cheeses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Buffalo Mozzarella" },
                    { 2, "Four Cheese" },
                    { 3, "Vegan" },
                    { 4, "None (cheeseless)" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "Name", "OrderId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "John Doe", 1, "555-123-4567" },
                    { 2, "456 Elm St", "Jane Smith", 2, "555-987-6543" },
                    { 3, "789 Oak Lane", "Bob Johnson", 3, "555-234-5678" },
                    { 4, "321 Birch Road", "Alice Brown", 4, "555-876-5432" },
                    { 5, "527 Main Street", "Tamara Goins", 5, "555-257-2858" },
                    { 6, "286 Ocean Avenue", "Amy Jaekel", 6, "555-573-5468" },
                    { 7, "25 1st Avenue", "Tamara Goins", 7, "555-825-8275" },
                    { 8, "98 Fake Street", "Joey Holland", 8, "555-292-2260" },
                    { 9, "82 Baker Lane", "Jeff Gribble", 9, "555-885-8820" }
                });

            migrationBuilder.InsertData(
                table: "Sauces",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Marinara" },
                    { 2, "Arrabbiata" },
                    { 3, "Garlic White" },
                    { 4, "None (sauceless)" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name", "SizeCost" },
                values: new object[,]
                {
                    { 1, "Small", 10.00m },
                    { 2, "Medium", 12.00m },
                    { 3, "Large", 15.00m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sausage" },
                    { 2, "Pepperoni" },
                    { 3, "Mushroom" },
                    { 4, "Onion" },
                    { 5, "Green Pepper" },
                    { 6, "Black Olive" },
                    { 7, "Basil" },
                    { 8, "Extra Cheese" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "555 Ocean Avenue", "Courtney", "f2498ab4-e4b6-4e61-92c0-9568e96a8145", "Gulledge" },
                    { 3, "555 Ocean Avenue", "Jeremy", "d9b5145a-739c-42d3-9e94-d2d439063d7e", "Gibeault" },
                    { 4, "555 Ocean Avenue", "Sean", "a7bc4dd9-8f10-4e24-8c0c-ef09a24ec9a5", "Gulledge" },
                    { 5, "555 Ocean Avenue", "Rick", "6a2f5d0b-3eac-4dab-ae9d-7f26d77e4a8c", "Gibeault" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DateTimePlaced", "DriverId", "EmployeeId", "TableNumber", "TipAmount" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 3, 6.80m },
                    { 2, null, new DateTime(2023, 9, 16, 14, 25, 22, 0, DateTimeKind.Unspecified), 3, 2, null, 11m },
                    { 3, null, new DateTime(2023, 9, 27, 12, 4, 35, 0, DateTimeKind.Unspecified), null, 3, 4, null },
                    { 4, null, new DateTime(2023, 9, 28, 12, 4, 11, 0, DateTimeKind.Unspecified), 3, 4, null, 8.75m },
                    { 5, null, new DateTime(2023, 9, 28, 13, 48, 37, 0, DateTimeKind.Unspecified), 3, 3, null, 4.95m },
                    { 6, null, new DateTime(2023, 9, 28, 15, 22, 58, 0, DateTimeKind.Unspecified), null, 4, 1, 12m },
                    { 7, null, new DateTime(2023, 9, 29, 11, 7, 47, 0, DateTimeKind.Unspecified), null, 2, 2, null },
                    { 8, null, new DateTime(2023, 9, 29, 12, 34, 51, 0, DateTimeKind.Unspecified), 3, 3, null, 8.55m },
                    { 9, null, new DateTime(2023, 9, 29, 14, 41, 8, 0, DateTimeKind.Unspecified), 3, 2, null, 6.39m }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CheeseId", "OrderId", "SauceId", "SizeId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2 },
                    { 2, 2, 2, 2, 1 },
                    { 3, 3, 2, 3, 2 },
                    { 4, 4, 3, 4, 3 },
                    { 5, 2, 4, 2, 3 },
                    { 6, 2, 4, 4, 1 },
                    { 7, 1, 5, 3, 1 },
                    { 8, 3, 6, 1, 1 },
                    { 9, 4, 6, 4, 2 },
                    { 10, 3, 6, 1, 3 },
                    { 11, 2, 7, 1, 1 },
                    { 12, 1, 8, 2, 2 },
                    { 13, 1, 8, 3, 1 },
                    { 14, 1, 9, 3, 2 },
                    { 15, 2, 9, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "PizzaToppings",
                columns: new[] { "Id", "PizzaId", "Quantity", "ToppingId" },
                values: new object[,]
                {
                    { 1, 1, 8, 1 },
                    { 2, 1, 8, 8 },
                    { 3, 1, 8, 5 },
                    { 4, 2, 10, 1 },
                    { 5, 3, 11, 1 },
                    { 6, 3, 7, 2 },
                    { 7, 4, 9, 1 },
                    { 8, 5, 12, 3 },
                    { 9, 5, 15, 4 },
                    { 10, 5, 7, 5 },
                    { 11, 6, 7, 1 },
                    { 12, 6, 4, 7 },
                    { 13, 7, 10, 1 },
                    { 14, 8, 11, 2 },
                    { 15, 9, 12, 8 },
                    { 16, 9, 10, 1 },
                    { 17, 10, 5, 4 },
                    { 18, 11, 6, 1 },
                    { 19, 11, 8, 3 },
                    { 20, 11, 7, 6 },
                    { 21, 12, 8, 1 },
                    { 22, 12, 9, 5 },
                    { 23, 13, 10, 1 },
                    { 24, 14, 10, 2 },
                    { 25, 15, 7, 2 },
                    { 26, 15, 8, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_CheeseId",
                table: "Pizzas",
                column: "CheeseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_OrderId",
                table: "Pizzas",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SauceId",
                table: "Pizzas",
                column: "SauceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_SizeId",
                table: "Pizzas",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_PizzaId",
                table: "PizzaToppings",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "PizzaToppings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Cheeses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sauces");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
