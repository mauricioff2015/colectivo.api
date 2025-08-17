using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colectivo.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMiembroColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioLogins",
                table: "UsuarioLogins");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Miembros");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UsuarioLogins");

            migrationBuilder.RenameTable(
                name: "Miembros",
                newName: "miembros");

            migrationBuilder.RenameTable(
                name: "UsuarioLogins",
                newName: "usuarios_login");

            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "miembros",
                newName: "Dni");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "miembros",
                newName: "fecha_nacimiento");

            migrationBuilder.RenameIndex(
                name: "IX_Miembros_DNI",
                table: "miembros",
                newName: "IX_miembros_Dni");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "miembros",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_nacimiento",
                table: "miembros",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "miembros",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "miembros",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Empleado",
                table: "miembros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "miembros",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfesionOficio",
                table: "miembros",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "miembros",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "miembros",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Territorio",
                table: "miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrabajaraMesaGenerales2025",
                table: "miembros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TrabajoMesas",
                table: "miembros",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_registro",
                table: "miembros",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "usuarios_login",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "usuarios_login",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "usuarios_login",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Territorio",
                table: "usuarios_login",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_miembros",
                table: "miembros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios_login",
                table: "usuarios_login",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_login_Usuario",
                table: "usuarios_login",
                column: "Usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_miembros",
                table: "miembros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios_login",
                table: "usuarios_login");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_login_Usuario",
                table: "usuarios_login");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Empleado",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "ProfesionOficio",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Territorio",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "TrabajaraMesaGenerales2025",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "TrabajoMesas",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "fecha_registro",
                table: "miembros");

            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "usuarios_login");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "usuarios_login");

            migrationBuilder.DropColumn(
                name: "Territorio",
                table: "usuarios_login");

            migrationBuilder.RenameTable(
                name: "miembros",
                newName: "Miembros");

            migrationBuilder.RenameTable(
                name: "usuarios_login",
                newName: "UsuarioLogins");

            migrationBuilder.RenameColumn(
                name: "Dni",
                table: "Miembros",
                newName: "DNI");

            migrationBuilder.RenameColumn(
                name: "fecha_nacimiento",
                table: "Miembros",
                newName: "FechaNacimiento");

            migrationBuilder.RenameIndex(
                name: "IX_miembros_Dni",
                table: "Miembros",
                newName: "IX_Miembros_DNI");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Miembros",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Miembros",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario",
                table: "UsuarioLogins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UsuarioLogins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Miembros",
                table: "Miembros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioLogins",
                table: "UsuarioLogins",
                column: "Id");
        }
    }
}
