using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealStateSearchPortal.Infrastructure.Migrations
{
    public partial class AddedInitalSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ListingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    CarSpots = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Favorites",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.UserId, x.PropertyId });
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "Description", "ImageUrls", "ListingType", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Melbourne", 3, 2, 1, "Cozy Cottage 1 located in Melbourne", "https://picsum.photos/seed/1/300/200", "Rent", 1244744m, "Cozy Cottage 1" },
                    { 2, "Perth", 2, 1, 0, "Beachfront Condo 2 located in Perth", "https://picsum.photos/seed/2/300/200", "Sale", 256453m, "Beachfront Condo 2" },
                    { 3, "Melbourne", 3, 4, 2, "Cozy Cottage 3 located in Melbourne", "https://picsum.photos/seed/3/300/200", "Sale", 425605m, "Cozy Cottage 3" },
                    { 4, "Brisbane", 3, 2, 2, "Beachfront Condo 4 located in Brisbane", "https://picsum.photos/seed/4/300/200", "Rent", 1484986m, "Beachfront Condo 4" },
                    { 5, "Perth", 2, 2, 0, "Beachfront Condo 5 located in Perth", "https://picsum.photos/seed/5/300/200", "Sale", 745013m, "Beachfront Condo 5" },
                    { 6, "Adelaide", 3, 1, 2, "City Apartment 6 located in Adelaide", "https://picsum.photos/seed/6/300/200", "Rent", 871551m, "City Apartment 6" },
                    { 7, "Melbourne", 2, 1, 2, "Modern House 7 located in Melbourne", "https://picsum.photos/seed/7/300/200", "Rent", 682266m, "Modern House 7" },
                    { 8, "Sydney", 2, 4, 1, "Beachfront Condo 8 located in Sydney", "https://picsum.photos/seed/8/300/200", "Sale", 1625172m, "Beachfront Condo 8" },
                    { 9, "Adelaide", 1, 1, 1, "Modern House 9 located in Adelaide", "https://picsum.photos/seed/9/300/200", "Sale", 698115m, "Modern House 9" },
                    { 10, "Adelaide", 1, 3, 2, "Modern House 10 located in Adelaide", "https://picsum.photos/seed/10/300/200", "Sale", 433978m, "Modern House 10" },
                    { 11, "Adelaide", 3, 1, 0, "Beachfront Condo 11 located in Adelaide", "https://picsum.photos/seed/11/300/200", "Sale", 1425009m, "Beachfront Condo 11" },
                    { 12, "Melbourne", 1, 2, 0, "Cozy Cottage 12 located in Melbourne", "https://picsum.photos/seed/12/300/200", "Sale", 864960m, "Cozy Cottage 12" },
                    { 13, "Brisbane", 1, 3, 0, "Beachfront Condo 13 located in Brisbane", "https://picsum.photos/seed/13/300/200", "Sale", 1086988m, "Beachfront Condo 13" },
                    { 14, "Sydney", 3, 2, 0, "Cozy Cottage 14 located in Sydney", "https://picsum.photos/seed/14/300/200", "Sale", 1369290m, "Cozy Cottage 14" },
                    { 15, "Adelaide", 2, 5, 1, "Beachfront Condo 15 located in Adelaide", "https://picsum.photos/seed/15/300/200", "Rent", 1425699m, "Beachfront Condo 15" },
                    { 16, "Perth", 2, 1, 1, "Cozy Cottage 16 located in Perth", "https://picsum.photos/seed/16/300/200", "Sale", 1229153m, "Cozy Cottage 16" },
                    { 17, "Brisbane", 1, 1, 2, "Cozy Cottage 17 located in Brisbane", "https://picsum.photos/seed/17/300/200", "Rent", 1558635m, "Cozy Cottage 17" },
                    { 18, "Sydney", 1, 2, 1, "Cozy Cottage 18 located in Sydney", "https://picsum.photos/seed/18/300/200", "Rent", 1047575m, "Cozy Cottage 18" },
                    { 19, "Melbourne", 1, 5, 0, "Luxury Villa 19 located in Melbourne", "https://picsum.photos/seed/19/300/200", "Sale", 1473341m, "Luxury Villa 19" },
                    { 20, "Adelaide", 1, 5, 2, "City Apartment 20 located in Adelaide", "https://picsum.photos/seed/20/300/200", "Sale", 1901216m, "City Apartment 20" },
                    { 21, "Perth", 2, 2, 1, "City Apartment 21 located in Perth", "https://picsum.photos/seed/21/300/200", "Rent", 627792m, "City Apartment 21" },
                    { 22, "Perth", 2, 1, 0, "Beachfront Condo 22 located in Perth", "https://picsum.photos/seed/22/300/200", "Sale", 1741496m, "Beachfront Condo 22" },
                    { 23, "Sydney", 1, 5, 0, "Cozy Cottage 23 located in Sydney", "https://picsum.photos/seed/23/300/200", "Sale", 613572m, "Cozy Cottage 23" },
                    { 24, "Sydney", 1, 5, 1, "City Apartment 24 located in Sydney", "https://picsum.photos/seed/24/300/200", "Sale", 1253866m, "City Apartment 24" },
                    { 25, "Sydney", 1, 3, 0, "Beachfront Condo 25 located in Sydney", "https://picsum.photos/seed/25/300/200", "Sale", 1820780m, "Beachfront Condo 25" },
                    { 26, "Adelaide", 3, 5, 2, "Cozy Cottage 26 located in Adelaide", "https://picsum.photos/seed/26/300/200", "Rent", 439527m, "Cozy Cottage 26" },
                    { 27, "Melbourne", 2, 2, 2, "City Apartment 27 located in Melbourne", "https://picsum.photos/seed/27/300/200", "Sale", 1775916m, "City Apartment 27" },
                    { 28, "Sydney", 3, 2, 0, "Modern House 28 located in Sydney", "https://picsum.photos/seed/28/300/200", "Sale", 1392568m, "Modern House 28" },
                    { 29, "Adelaide", 2, 4, 1, "City Apartment 29 located in Adelaide", "https://picsum.photos/seed/29/300/200", "Sale", 1147502m, "City Apartment 29" },
                    { 30, "Perth", 1, 2, 0, "Luxury Villa 30 located in Perth", "https://picsum.photos/seed/30/300/200", "Rent", 1571343m, "Luxury Villa 30" },
                    { 31, "Adelaide", 1, 2, 0, "Modern House 31 located in Adelaide", "https://picsum.photos/seed/31/300/200", "Sale", 869290m, "Modern House 31" },
                    { 32, "Sydney", 3, 3, 1, "Modern House 32 located in Sydney", "https://picsum.photos/seed/32/300/200", "Sale", 532837m, "Modern House 32" },
                    { 33, "Sydney", 3, 1, 2, "City Apartment 33 located in Sydney", "https://picsum.photos/seed/33/300/200", "Sale", 600890m, "City Apartment 33" },
                    { 34, "Brisbane", 2, 5, 2, "Cozy Cottage 34 located in Brisbane", "https://picsum.photos/seed/34/300/200", "Rent", 1227063m, "Cozy Cottage 34" },
                    { 35, "Brisbane", 3, 1, 0, "Beachfront Condo 35 located in Brisbane", "https://picsum.photos/seed/35/300/200", "Sale", 356581m, "Beachfront Condo 35" },
                    { 36, "Perth", 3, 1, 2, "Modern House 36 located in Perth", "https://picsum.photos/seed/36/300/200", "Sale", 1337918m, "Modern House 36" },
                    { 37, "Perth", 1, 2, 1, "Cozy Cottage 37 located in Perth", "https://picsum.photos/seed/37/300/200", "Sale", 585629m, "Cozy Cottage 37" },
                    { 38, "Sydney", 3, 5, 2, "City Apartment 38 located in Sydney", "https://picsum.photos/seed/38/300/200", "Sale", 1536761m, "City Apartment 38" },
                    { 39, "Adelaide", 1, 5, 0, "City Apartment 39 located in Adelaide", "https://picsum.photos/seed/39/300/200", "Rent", 1432299m, "City Apartment 39" },
                    { 40, "Perth", 1, 1, 0, "City Apartment 40 located in Perth", "https://picsum.photos/seed/40/300/200", "Sale", 1585664m, "City Apartment 40" },
                    { 41, "Adelaide", 3, 1, 1, "Modern House 41 located in Adelaide", "https://picsum.photos/seed/41/300/200", "Rent", 1801711m, "Modern House 41" },
                    { 42, "Sydney", 1, 5, 1, "Beachfront Condo 42 located in Sydney", "https://picsum.photos/seed/42/300/200", "Sale", 1005625m, "Beachfront Condo 42" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "Description", "ImageUrls", "ListingType", "Price", "Title" },
                values: new object[,]
                {
                    { 43, "Sydney", 2, 3, 0, "Modern House 43 located in Sydney", "https://picsum.photos/seed/43/300/200", "Sale", 1372494m, "Modern House 43" },
                    { 44, "Melbourne", 3, 2, 2, "Cozy Cottage 44 located in Melbourne", "https://picsum.photos/seed/44/300/200", "Rent", 937798m, "Cozy Cottage 44" },
                    { 45, "Adelaide", 1, 3, 0, "Cozy Cottage 45 located in Adelaide", "https://picsum.photos/seed/45/300/200", "Sale", 778124m, "Cozy Cottage 45" },
                    { 46, "Adelaide", 1, 1, 0, "Modern House 46 located in Adelaide", "https://picsum.photos/seed/46/300/200", "Sale", 1048215m, "Modern House 46" },
                    { 47, "Melbourne", 1, 5, 2, "Beachfront Condo 47 located in Melbourne", "https://picsum.photos/seed/47/300/200", "Sale", 940200m, "Beachfront Condo 47" },
                    { 48, "Adelaide", 2, 2, 0, "Luxury Villa 48 located in Adelaide", "https://picsum.photos/seed/48/300/200", "Rent", 1944116m, "Luxury Villa 48" },
                    { 49, "Perth", 3, 2, 2, "City Apartment 49 located in Perth", "https://picsum.photos/seed/49/300/200", "Sale", 895103m, "City Apartment 49" },
                    { 50, "Perth", 1, 1, 2, "Luxury Villa 50 located in Perth", "https://picsum.photos/seed/50/300/200", "Sale", 251158m, "Luxury Villa 50" },
                    { 51, "Brisbane", 3, 5, 1, "Modern House 51 located in Brisbane", "https://picsum.photos/seed/51/300/200", "Rent", 478251m, "Modern House 51" },
                    { 52, "Sydney", 2, 4, 0, "Beachfront Condo 52 located in Sydney", "https://picsum.photos/seed/52/300/200", "Sale", 266686m, "Beachfront Condo 52" },
                    { 53, "Melbourne", 1, 4, 1, "City Apartment 53 located in Melbourne", "https://picsum.photos/seed/53/300/200", "Sale", 876348m, "City Apartment 53" },
                    { 54, "Adelaide", 2, 5, 1, "Beachfront Condo 54 located in Adelaide", "https://picsum.photos/seed/54/300/200", "Rent", 1664271m, "Beachfront Condo 54" },
                    { 55, "Brisbane", 3, 4, 0, "Luxury Villa 55 located in Brisbane", "https://picsum.photos/seed/55/300/200", "Rent", 1885585m, "Luxury Villa 55" },
                    { 56, "Adelaide", 2, 3, 0, "Cozy Cottage 56 located in Adelaide", "https://picsum.photos/seed/56/300/200", "Rent", 1840776m, "Cozy Cottage 56" },
                    { 57, "Perth", 1, 5, 2, "Cozy Cottage 57 located in Perth", "https://picsum.photos/seed/57/300/200", "Sale", 1800608m, "Cozy Cottage 57" },
                    { 58, "Perth", 2, 3, 1, "City Apartment 58 located in Perth", "https://picsum.photos/seed/58/300/200", "Sale", 752005m, "City Apartment 58" },
                    { 59, "Melbourne", 2, 5, 1, "City Apartment 59 located in Melbourne", "https://picsum.photos/seed/59/300/200", "Rent", 1928249m, "City Apartment 59" },
                    { 60, "Melbourne", 3, 4, 0, "Modern House 60 located in Melbourne", "https://picsum.photos/seed/60/300/200", "Sale", 1558574m, "Modern House 60" },
                    { 61, "Adelaide", 2, 2, 2, "Modern House 61 located in Adelaide", "https://picsum.photos/seed/61/300/200", "Sale", 897474m, "Modern House 61" },
                    { 62, "Sydney", 1, 5, 0, "Cozy Cottage 62 located in Sydney", "https://picsum.photos/seed/62/300/200", "Rent", 1196851m, "Cozy Cottage 62" },
                    { 63, "Adelaide", 1, 2, 0, "City Apartment 63 located in Adelaide", "https://picsum.photos/seed/63/300/200", "Sale", 655297m, "City Apartment 63" },
                    { 64, "Adelaide", 1, 3, 1, "Cozy Cottage 64 located in Adelaide", "https://picsum.photos/seed/64/300/200", "Sale", 850079m, "Cozy Cottage 64" },
                    { 65, "Melbourne", 3, 4, 2, "Beachfront Condo 65 located in Melbourne", "https://picsum.photos/seed/65/300/200", "Sale", 544056m, "Beachfront Condo 65" },
                    { 66, "Melbourne", 3, 1, 2, "Luxury Villa 66 located in Melbourne", "https://picsum.photos/seed/66/300/200", "Sale", 1701614m, "Luxury Villa 66" },
                    { 67, "Brisbane", 1, 4, 1, "City Apartment 67 located in Brisbane", "https://picsum.photos/seed/67/300/200", "Rent", 1694767m, "City Apartment 67" },
                    { 68, "Sydney", 3, 5, 1, "Beachfront Condo 68 located in Sydney", "https://picsum.photos/seed/68/300/200", "Sale", 1882983m, "Beachfront Condo 68" },
                    { 69, "Perth", 3, 5, 1, "Beachfront Condo 69 located in Perth", "https://picsum.photos/seed/69/300/200", "Sale", 691525m, "Beachfront Condo 69" },
                    { 70, "Perth", 3, 5, 0, "Modern House 70 located in Perth", "https://picsum.photos/seed/70/300/200", "Sale", 1224515m, "Modern House 70" },
                    { 71, "Brisbane", 2, 1, 2, "City Apartment 71 located in Brisbane", "https://picsum.photos/seed/71/300/200", "Rent", 522399m, "City Apartment 71" },
                    { 72, "Sydney", 2, 4, 2, "Cozy Cottage 72 located in Sydney", "https://picsum.photos/seed/72/300/200", "Sale", 1893982m, "Cozy Cottage 72" },
                    { 73, "Sydney", 2, 1, 0, "Cozy Cottage 73 located in Sydney", "https://picsum.photos/seed/73/300/200", "Rent", 258279m, "Cozy Cottage 73" },
                    { 74, "Melbourne", 2, 4, 2, "Luxury Villa 74 located in Melbourne", "https://picsum.photos/seed/74/300/200", "Sale", 644800m, "Luxury Villa 74" },
                    { 75, "Sydney", 1, 3, 1, "Beachfront Condo 75 located in Sydney", "https://picsum.photos/seed/75/300/200", "Sale", 1770319m, "Beachfront Condo 75" },
                    { 76, "Melbourne", 3, 3, 2, "City Apartment 76 located in Melbourne", "https://picsum.photos/seed/76/300/200", "Sale", 952304m, "City Apartment 76" },
                    { 77, "Brisbane", 2, 3, 2, "Cozy Cottage 77 located in Brisbane", "https://picsum.photos/seed/77/300/200", "Rent", 480933m, "Cozy Cottage 77" },
                    { 78, "Adelaide", 3, 3, 0, "Beachfront Condo 78 located in Adelaide", "https://picsum.photos/seed/78/300/200", "Sale", 1013933m, "Beachfront Condo 78" },
                    { 79, "Adelaide", 2, 1, 0, "City Apartment 79 located in Adelaide", "https://picsum.photos/seed/79/300/200", "Sale", 1093305m, "City Apartment 79" },
                    { 80, "Adelaide", 1, 1, 2, "Luxury Villa 80 located in Adelaide", "https://picsum.photos/seed/80/300/200", "Sale", 868950m, "Luxury Villa 80" },
                    { 81, "Brisbane", 3, 2, 1, "City Apartment 81 located in Brisbane", "https://picsum.photos/seed/81/300/200", "Rent", 1132323m, "City Apartment 81" },
                    { 82, "Sydney", 3, 2, 1, "Cozy Cottage 82 located in Sydney", "https://picsum.photos/seed/82/300/200", "Rent", 786421m, "Cozy Cottage 82" },
                    { 83, "Brisbane", 3, 5, 1, "Cozy Cottage 83 located in Brisbane", "https://picsum.photos/seed/83/300/200", "Rent", 240520m, "Cozy Cottage 83" },
                    { 84, "Melbourne", 2, 1, 2, "Luxury Villa 84 located in Melbourne", "https://picsum.photos/seed/84/300/200", "Sale", 1744728m, "Luxury Villa 84" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Bathrooms", "Bedrooms", "CarSpots", "Description", "ImageUrls", "ListingType", "Price", "Title" },
                values: new object[,]
                {
                    { 85, "Melbourne", 2, 1, 1, "Beachfront Condo 85 located in Melbourne", "https://picsum.photos/seed/85/300/200", "Sale", 695800m, "Beachfront Condo 85" },
                    { 86, "Melbourne", 1, 2, 2, "Modern House 86 located in Melbourne", "https://picsum.photos/seed/86/300/200", "Sale", 1299972m, "Modern House 86" },
                    { 87, "Adelaide", 1, 3, 2, "Luxury Villa 87 located in Adelaide", "https://picsum.photos/seed/87/300/200", "Sale", 1493368m, "Luxury Villa 87" },
                    { 88, "Brisbane", 1, 3, 1, "Beachfront Condo 88 located in Brisbane", "https://picsum.photos/seed/88/300/200", "Sale", 1353147m, "Beachfront Condo 88" },
                    { 89, "Perth", 3, 4, 0, "Luxury Villa 89 located in Perth", "https://picsum.photos/seed/89/300/200", "Rent", 212088m, "Luxury Villa 89" },
                    { 90, "Sydney", 1, 1, 1, "Luxury Villa 90 located in Sydney", "https://picsum.photos/seed/90/300/200", "Rent", 1624867m, "Luxury Villa 90" },
                    { 91, "Adelaide", 3, 5, 0, "City Apartment 91 located in Adelaide", "https://picsum.photos/seed/91/300/200", "Rent", 414325m, "City Apartment 91" },
                    { 92, "Brisbane", 3, 2, 2, "Luxury Villa 92 located in Brisbane", "https://picsum.photos/seed/92/300/200", "Rent", 348122m, "Luxury Villa 92" },
                    { 93, "Perth", 1, 5, 0, "Beachfront Condo 93 located in Perth", "https://picsum.photos/seed/93/300/200", "Rent", 1269319m, "Beachfront Condo 93" },
                    { 94, "Perth", 1, 3, 1, "Modern House 94 located in Perth", "https://picsum.photos/seed/94/300/200", "Rent", 294751m, "Modern House 94" },
                    { 95, "Adelaide", 3, 1, 2, "Beachfront Condo 95 located in Adelaide", "https://picsum.photos/seed/95/300/200", "Sale", 812672m, "Beachfront Condo 95" },
                    { 96, "Melbourne", 2, 4, 0, "Luxury Villa 96 located in Melbourne", "https://picsum.photos/seed/96/300/200", "Rent", 825992m, "Luxury Villa 96" },
                    { 97, "Brisbane", 1, 3, 2, "City Apartment 97 located in Brisbane", "https://picsum.photos/seed/97/300/200", "Sale", 274284m, "City Apartment 97" },
                    { 98, "Adelaide", 1, 2, 1, "Luxury Villa 98 located in Adelaide", "https://picsum.photos/seed/98/300/200", "Sale", 612213m, "Luxury Villa 98" },
                    { 99, "Brisbane", 1, 3, 2, "Luxury Villa 99 located in Brisbane", "https://picsum.photos/seed/99/300/200", "Sale", 319977m, "Luxury Villa 99" },
                    { 100, "Melbourne", 2, 1, 1, "Beachfront Condo 100 located in Melbourne", "https://picsum.photos/seed/100/300/200", "Sale", 1284706m, "Beachfront Condo 100" }
                });

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
                name: "IX_Favorites_PropertyId",
                table: "Favorites",
                column: "PropertyId");
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
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
