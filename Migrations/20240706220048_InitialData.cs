using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace minimalApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("4e61e1f2-3062-4a6a-a565-0570e25423b6"), "Tareas personales", "Personal", 2 },
                    { new Guid("8e3a0809-7b6f-4d3e-9e0b-7483560ad855"), "Tareas de trabajo", "Trabajo", 1 },
                    { new Guid("d02f42dd-86e7-49df-8b21-af25e3ca71f0"), "Tareas de estudio", "Estudio", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Completada", "Descripcion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("037899bd-8beb-49b4-a938-a125c5ef6418"), new Guid("4e61e1f2-3062-4a6a-a565-0570e25423b6"), false, "Ir a la panadería", 1, "Comprar pan" },
                    { new Guid("3924db39-7857-4459-923d-1bfee0600d84"), new Guid("d02f42dd-86e7-49df-8b21-af25e3ca71f0"), false, "Estudiar C# con Visual Studio", 3, "Estudiar C#" },
                    { new Guid("9c7309e2-bcfa-4070-83a2-2e6c90cff311"), new Guid("8e3a0809-7b6f-4d3e-9e0b-7483560ad855"), false, "Reunión de trabajo", 2, "Reunión" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("037899bd-8beb-49b4-a938-a125c5ef6418"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3924db39-7857-4459-923d-1bfee0600d84"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9c7309e2-bcfa-4070-83a2-2e6c90cff311"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("4e61e1f2-3062-4a6a-a565-0570e25423b6"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("8e3a0809-7b6f-4d3e-9e0b-7483560ad855"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: new Guid("d02f42dd-86e7-49df-8b21-af25e3ca71f0"));
        }
    }
}
