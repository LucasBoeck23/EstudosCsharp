using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias (Nome, ImagemUrl) Values('Bebidas', 'Bebidas.jpeg')");
            mb.Sql("Insert into Categorias (Nome, ImagemUrl) Values('Lanches', 'Lanches.jpeg')");
            mb.Sql("Insert into Categorias (Nome, ImagemUrl) Values('Sobremesas', 'Sobremesas.jpeg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
        }
    }
}
