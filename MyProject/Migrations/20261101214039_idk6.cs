using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    /// <inheritdoc />
    public partial class idk6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctorPatients",
                table: "doctorPatients");

            migrationBuilder.DropColumn(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DoctorPatientPatientsPatientId",
                table: "Patients",
                newName: "doctorpatientID");

            migrationBuilder.RenameColumn(
                name: "DoctorPatientPatientsPatientId",
                table: "Doctors",
                newName: "doctorpatientID");

            migrationBuilder.AddColumn<int>(
                name: "doctorpatientID",
                table: "doctorPatients",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctorPatients",
                table: "doctorPatients",
                column: "doctorpatientID");

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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Patients_doctorpatientID",
                table: "Patients",
                column: "doctorpatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_doctorpatientID",
                table: "Doctors",
                column: "doctorpatientID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_doctorPatients_doctorpatientID",
                table: "Doctors",
                column: "doctorpatientID",
                principalTable: "doctorPatients",
                principalColumn: "doctorpatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_doctorPatients_doctorpatientID",
                table: "Patients",
                column: "doctorpatientID",
                principalTable: "doctorPatients",
                principalColumn: "doctorpatientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_doctorPatients_doctorpatientID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_doctorPatients_doctorpatientID",
                table: "Patients");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Patients_doctorpatientID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_doctorpatientID",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_doctorPatients",
                table: "doctorPatients");

            migrationBuilder.DropColumn(
                name: "doctorpatientID",
                table: "doctorPatients");

            migrationBuilder.RenameColumn(
                name: "doctorpatientID",
                table: "Patients",
                newName: "DoctorPatientPatientsPatientId");

            migrationBuilder.RenameColumn(
                name: "doctorpatientID",
                table: "Doctors",
                newName: "DoctorPatientPatientsPatientId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_doctorPatients",
                table: "doctorPatients",
                columns: new[] { "DoctorsDoctorId", "PatientsPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" },
                principalTable: "doctorPatients",
                principalColumns: new[] { "DoctorsDoctorId", "PatientsPatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" },
                principalTable: "doctorPatients",
                principalColumns: new[] { "DoctorsDoctorId", "PatientsPatientId" });
        }
    }
}
