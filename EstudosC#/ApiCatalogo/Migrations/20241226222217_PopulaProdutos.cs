using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                    "Values ('Coca-Cola Zero','Refrigerante',5.45,'coquinhaGelada.png',50,now(),1)");

            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                    "Values ('Lanche de Atum','Atum',10,'Aaaatum.png',10,now(),2)");

            mb.Sql("Insert into Produtos (Nome,Descricao,Preco,ImagemUrl,Estoque,DataCadastro,CategoriaId)" +
                   "Values ('Pave','É pave ou pra cume?',15,'Pave.png',5,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
