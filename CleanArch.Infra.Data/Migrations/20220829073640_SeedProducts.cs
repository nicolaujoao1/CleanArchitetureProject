using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products VALUES('Caderno Espiral','Caderno espiral 100 folhas',7.75,50,'caderno1.jpg',1)");
            mb.Sql("INSERT INTO Products VALUES('Estojo escolar','Estojo escolar cinza',5.56,70,'estojo1.jpg',1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
