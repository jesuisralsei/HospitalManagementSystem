using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    /// <inheritdoc />
    public partial class idk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientPatientsPatientId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorPatientPatientsPatientId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "doctorPatients",
                columns: table => new
                {
                    DoctorsDoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorPatients", x => new { x.DoctorsDoctorId, x.PatientsPatientId });
                    table.ForeignKey(
                        name: "FK_doctorPatients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_doctorPatients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors",
                columns: new[] { "DoctorPatientDoctorsDoctorId", "DoctorPatientPatientsPatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_doctorPatients_DoctorId",
                table: "doctorPatients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_doctorPatients_PatientId",
                table: "doctorPatients",
                column: "PatientId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_doctorPatients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "doctorPatients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorPatientDoctorsDoctorId_DoctorPatientPatientsPatientId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorPatientPatientsPatientId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorPatientDoctorsDoctorId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorPatientPatientsPatientId",
                table: "Doctors");
        }
    }
}
