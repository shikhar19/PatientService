using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientService.Migrations
{
    /// <inheritdoc />
    public partial class Fixmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Beds_BedId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BedId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MedicalConditions",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Medications",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "Immunizations",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "TestResults",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "BedId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "PreviousSurgeries",
                table: "Patients",
                newName: "PhotoPath");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Treatments",
                table: "MedicalHistories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MedicalHistories",
                newName: "MedicalHistoryId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Patients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "MedicalHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Beds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientId",
                table: "Beds",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientId",
                table: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Beds_PatientId",
                table: "Beds");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Beds");

            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Patients",
                newName: "PreviousSurgeries");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Patients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "MedicalHistories",
                newName: "Treatments");

            migrationBuilder.RenameColumn(
                name: "MedicalHistoryId",
                table: "MedicalHistories",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalConditions",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medications",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "MedicalHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Immunizations",
                table: "MedicalHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestResults",
                table: "MedicalHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BedId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BedId",
                table: "Patients",
                column: "BedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Beds_BedId",
                table: "Patients",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
