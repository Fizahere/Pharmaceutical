using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmaceutical.Migrations
{
    /// <inheritdoc />
    public partial class tablesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blendings",
                columns: table => new
                {
                    BlendingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlendingImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TypeOfBlending = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MixingSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MixingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blendings", x => x.BlendingID);
                });

            migrationBuilder.CreateTable(
                name: "Capsules",
                columns: table => new
                {
                    CapsuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapsuleImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapsuleSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capsules", x => x.CapsuleID);
                });

            migrationBuilder.CreateTable(
                name: "LiquidFillings",
                columns: table => new
                {
                    LiquidFillingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiquidFillingImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirVolume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillingSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillingRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiquidFillings", x => x.LiquidFillingID);
                });

            migrationBuilder.CreateTable(
                name: "ProcessEquipments",
                columns: table => new
                {
                    ProcessEquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProcessEquipmentImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialOfConstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEquipments", x => x.ProcessEquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteID);
                });

            migrationBuilder.CreateTable(
                name: "Tablets",
                columns: table => new
                {
                    TabletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TabletImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxDiameter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxDepthOfFill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MachineSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Netweight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablets", x => x.TabletID);
                });

            migrationBuilder.CreateTable(
                name: "UsedEquipments",
                columns: table => new
                {
                    UsedEquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedEquipmentImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousUsage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonsForSelling = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedEquipments", x => x.UsedEquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "UserCareers",
                columns: table => new
                {
                    UserCareerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CGPA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCareers", x => x.UserCareerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blendings");

            migrationBuilder.DropTable(
                name: "Capsules");

            migrationBuilder.DropTable(
                name: "LiquidFillings");

            migrationBuilder.DropTable(
                name: "ProcessEquipments");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "Tablets");

            migrationBuilder.DropTable(
                name: "UsedEquipments");

            migrationBuilder.DropTable(
                name: "UserCareers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
