namespace Bono.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DatosBonoes", "Metodo", c => c.String(nullable: false));
            AlterColumn("dbo.DatosBonoes", "TipoAno", c => c.String(nullable: false));
            AlterColumn("dbo.DatosBonoes", "FrecPago", c => c.String(nullable: false));
            AlterColumn("dbo.PGracias", "Tipo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PGracias", "Tipo", c => c.String());
            AlterColumn("dbo.DatosBonoes", "FrecPago", c => c.String());
            AlterColumn("dbo.DatosBonoes", "TipoAno", c => c.String());
            AlterColumn("dbo.DatosBonoes", "Metodo", c => c.String());
        }
    }
}
