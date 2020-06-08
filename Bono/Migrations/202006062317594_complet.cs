namespace Bono.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class complet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatosBonoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Metodo = c.String(),
                        ValNominal = c.Double(nullable: false),
                        ValComercial = c.Double(nullable: false),
                        AnosVida = c.Int(nullable: false),
                        TipoAno = c.String(),
                        FrecPago = c.String(),
                        Tea = c.Double(nullable: false),
                        Tdea = c.Double(nullable: false),
                        Ianual = c.Double(nullable: false),
                        Ir = c.Double(nullable: false),
                        Pprima = c.Double(nullable: false),
                        Pestimacion = c.Double(nullable: false),
                        Pcolocacion = c.Double(nullable: false),
                        Pflotacion = c.Double(nullable: false),
                        PCavali = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        ResultadoBono_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResultadoBonoes", t => t.ResultadoBono_Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ResultadoBono_Id);
            
            CreateTable(
                "dbo.PGracias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatosBonoId = c.Int(nullable: false),
                        Tipo = c.String(),
                        Periodo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DatosBonoes", t => t.DatosBonoId, cascadeDelete: true)
                .Index(t => t.DatosBonoId);
            
            CreateTable(
                "dbo.ResultadoBonoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Van = c.Double(nullable: false),
                        Va = c.Double(nullable: false),
                        Tcea = c.Double(nullable: false),
                        Tir = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlujoBonistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periodo = c.Int(nullable: false),
                        Monto = c.Double(nullable: false),
                        ResultadoBonoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResultadoBonoes", t => t.ResultadoBonoId, cascadeDelete: true)
                .Index(t => t.ResultadoBonoId);
            
            CreateTable(
                "dbo.FlujoEmisors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periodo = c.Int(nullable: false),
                        Monto = c.Double(nullable: false),
                        ResultadoBonoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResultadoBonoes", t => t.ResultadoBonoId, cascadeDelete: true)
                .Index(t => t.ResultadoBonoId);
            
            CreateTable(
                "dbo.FlujoEmisorEscs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Periodo = c.Int(nullable: false),
                        Monto = c.Double(nullable: false),
                        ResultadoBonoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResultadoBonoes", t => t.ResultadoBonoId, cascadeDelete: true)
                .Index(t => t.ResultadoBonoId);
            
            AlterColumn("dbo.Users", "nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "correo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatosBonoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.DatosBonoes", "ResultadoBono_Id", "dbo.ResultadoBonoes");
            DropForeignKey("dbo.FlujoEmisorEscs", "ResultadoBonoId", "dbo.ResultadoBonoes");
            DropForeignKey("dbo.FlujoEmisors", "ResultadoBonoId", "dbo.ResultadoBonoes");
            DropForeignKey("dbo.FlujoBonistas", "ResultadoBonoId", "dbo.ResultadoBonoes");
            DropForeignKey("dbo.PGracias", "DatosBonoId", "dbo.DatosBonoes");
            DropIndex("dbo.FlujoEmisorEscs", new[] { "ResultadoBonoId" });
            DropIndex("dbo.FlujoEmisors", new[] { "ResultadoBonoId" });
            DropIndex("dbo.FlujoBonistas", new[] { "ResultadoBonoId" });
            DropIndex("dbo.PGracias", new[] { "DatosBonoId" });
            DropIndex("dbo.DatosBonoes", new[] { "ResultadoBono_Id" });
            DropIndex("dbo.DatosBonoes", new[] { "UserId" });
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "correo", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "nombre", c => c.String(nullable: false));
            DropTable("dbo.FlujoEmisorEscs");
            DropTable("dbo.FlujoEmisors");
            DropTable("dbo.FlujoBonistas");
            DropTable("dbo.ResultadoBonoes");
            DropTable("dbo.PGracias");
            DropTable("dbo.DatosBonoes");
        }
    }
}
