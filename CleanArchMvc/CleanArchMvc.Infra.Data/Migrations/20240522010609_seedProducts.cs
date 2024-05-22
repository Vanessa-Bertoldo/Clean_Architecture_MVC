using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Products(Name, Description,Price,Stock,Image,CategoryId)" +
                                "VALUES('Estojo Escolar','Estojo Escolar Cinza',5.65,70,'estojo1.jpg',1)");

            migrationBuilder.Sql("INSERT INTO Products(Name, Description,Price,Stock,Image,CategoryId)" +
                                "VALUES('Caderno Espiral','Caderno Espiral 100 folhas',7.65,50,'caderno1.jpg',1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM Products");
                
        }
    }
}
