namespace uuregistration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departement",
                c => new
                    {
                        DepartementId = c.Int(nullable: false, identity: true),
                        departementCode = c.String(),
                        departementOmschrijving = c.String(),
                    })
                .PrimaryKey(t => t.DepartementId);
            
            CreateTable(
                "dbo.Gebruiker",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Login = c.String(),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        DepartementId = c.Int(),
                        GebruikerRol = c.Int(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departement", t => t.DepartementId)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Gebruiker_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gebruiker", t => t.Gebruiker_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.Gebruiker_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Klant",
                c => new
                    {
                        KlantId = c.Int(nullable: false, identity: true),
                        Ondernemingsnummer = c.String(),
                        Bedrijfsnaam = c.String(),
                        Adres = c.String(),
                        Postcode = c.String(),
                        Plaats = c.String(),
                        GebruikerId = c.Int(),
                        Gebruiker_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.KlantId)
                .ForeignKey("dbo.Gebruiker", t => t.Gebruiker_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.Gebruiker_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Update",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UpdateTijd = c.DateTime(nullable: false),
                        UpdateType = c.Int(nullable: false),
                        UpdateOmschrijving = c.String(),
                        Author_Id = c.String(maxLength: 128),
                        Klant_KlantId = c.Int(),
                        Departement_DepartementId = c.Int(),
                        FactuurDetails_Id = c.Int(),
                        UurRegistratieDetails_UurRegistratieDetailsId = c.Int(),
                        UurRegistratie_UurRegistratieId = c.Int(),
                        Factuur_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gebruiker", t => t.Author_Id)
                .ForeignKey("dbo.Klant", t => t.Klant_KlantId)
                .ForeignKey("dbo.Departement", t => t.Departement_DepartementId)
                .ForeignKey("dbo.FactuurDetails", t => t.FactuurDetails_Id)
                .ForeignKey("dbo.UurRegistratieDetails", t => t.UurRegistratieDetails_UurRegistratieDetailsId)
                .ForeignKey("dbo.UurRegistratie", t => t.UurRegistratie_UurRegistratieId)
                .ForeignKey("dbo.Factuur", t => t.Factuur_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Klant_KlantId)
                .Index(t => t.Departement_DepartementId)
                .Index(t => t.FactuurDetails_Id)
                .Index(t => t.UurRegistratieDetails_UurRegistratieDetailsId)
                .Index(t => t.UurRegistratie_UurRegistratieId)
                .Index(t => t.Factuur_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Gebruiker_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Gebruiker", t => t.Gebruiker_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.Gebruiker_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Gebruiker_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Gebruiker", t => t.Gebruiker_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.Gebruiker_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Factuur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FactuurJaar = c.Int(nullable: false),
                        FactuurNummer = c.Int(nullable: false),
                        FactuurDatum = c.DateTime(nullable: false),
                        BeginPeriode = c.DateTime(nullable: false),
                        EndPeriode = c.DateTime(nullable: false),
                        Totaal = c.Single(nullable: false),
                        Klant_KlantId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Klant", t => t.Klant_KlantId)
                .Index(t => t.Klant_KlantId);
            
            CreateTable(
                "dbo.FactuurDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoofdlijnId = c.Int(nullable: false),
                        Omschrijving = c.String(),
                        UurRegistratieId = c.Int(nullable: false),
                        FactuurId = c.Int(nullable: false),
                        LijnNetto = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factuur", t => t.FactuurId, cascadeDelete: true)
                .ForeignKey("dbo.UurRegistratie", t => t.UurRegistratieId, cascadeDelete: true)
                .Index(t => t.UurRegistratieId)
                .Index(t => t.FactuurId);
            
            CreateTable(
                "dbo.UurRegistratie",
                c => new
                    {
                        UurRegistratieId = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Omschrijving = c.String(),
                        KlantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UurRegistratieId)
                .ForeignKey("dbo.Klant", t => t.KlantId, cascadeDelete: true)
                .Index(t => t.KlantId);
            
            CreateTable(
                "dbo.UurRegistratieDetails",
                c => new
                    {
                        UurRegistratieDetailsId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EindDate = c.DateTime(nullable: false),
                        TypeWerk = c.String(),
                        TeFactureren = c.Boolean(nullable: false),
                        UurRegistratieId = c.Int(),
                        StartTijd = c.DateTime(nullable: false),
                        EindTijd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UurRegistratieDetailsId)
                .ForeignKey("dbo.UurRegistratie", t => t.UurRegistratieId)
                .Index(t => t.UurRegistratieId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Login = c.String(),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        DepartementId = c.Int(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departement", t => t.DepartementId)
                .Index(t => t.DepartementId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Update", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Klant", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUser", "DepartementId", "dbo.Departement");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Update", "Factuur_Id", "dbo.Factuur");
            DropForeignKey("dbo.Factuur", "Klant_KlantId", "dbo.Klant");
            DropForeignKey("dbo.Update", "UurRegistratie_UurRegistratieId", "dbo.UurRegistratie");
            DropForeignKey("dbo.UurRegistratie", "KlantId", "dbo.Klant");
            DropForeignKey("dbo.FactuurDetails", "UurRegistratieId", "dbo.UurRegistratie");
            DropForeignKey("dbo.UurRegistratieDetails", "UurRegistratieId", "dbo.UurRegistratie");
            DropForeignKey("dbo.Update", "UurRegistratieDetails_UurRegistratieDetailsId", "dbo.UurRegistratieDetails");
            DropForeignKey("dbo.Update", "FactuurDetails_Id", "dbo.FactuurDetails");
            DropForeignKey("dbo.FactuurDetails", "FactuurId", "dbo.Factuur");
            DropForeignKey("dbo.Update", "Departement_DepartementId", "dbo.Departement");
            DropForeignKey("dbo.IdentityUserRole", "Gebruiker_Id", "dbo.Gebruiker");
            DropForeignKey("dbo.IdentityUserLogin", "Gebruiker_Id", "dbo.Gebruiker");
            DropForeignKey("dbo.Update", "Klant_KlantId", "dbo.Klant");
            DropForeignKey("dbo.Update", "Author_Id", "dbo.Gebruiker");
            DropForeignKey("dbo.Klant", "Gebruiker_Id", "dbo.Gebruiker");
            DropForeignKey("dbo.Gebruiker", "DepartementId", "dbo.Departement");
            DropForeignKey("dbo.IdentityUserClaim", "Gebruiker_Id", "dbo.Gebruiker");
            DropIndex("dbo.ApplicationUser", new[] { "DepartementId" });
            DropIndex("dbo.UurRegistratieDetails", new[] { "UurRegistratieId" });
            DropIndex("dbo.UurRegistratie", new[] { "KlantId" });
            DropIndex("dbo.FactuurDetails", new[] { "FactuurId" });
            DropIndex("dbo.FactuurDetails", new[] { "UurRegistratieId" });
            DropIndex("dbo.Factuur", new[] { "Klant_KlantId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "Gebruiker_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "Gebruiker_Id" });
            DropIndex("dbo.Update", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Update", new[] { "Factuur_Id" });
            DropIndex("dbo.Update", new[] { "UurRegistratie_UurRegistratieId" });
            DropIndex("dbo.Update", new[] { "UurRegistratieDetails_UurRegistratieDetailsId" });
            DropIndex("dbo.Update", new[] { "FactuurDetails_Id" });
            DropIndex("dbo.Update", new[] { "Departement_DepartementId" });
            DropIndex("dbo.Update", new[] { "Klant_KlantId" });
            DropIndex("dbo.Update", new[] { "Author_Id" });
            DropIndex("dbo.Klant", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Klant", new[] { "Gebruiker_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Gebruiker_Id" });
            DropIndex("dbo.Gebruiker", new[] { "DepartementId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UurRegistratieDetails");
            DropTable("dbo.UurRegistratie");
            DropTable("dbo.FactuurDetails");
            DropTable("dbo.Factuur");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.Update");
            DropTable("dbo.Klant");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.Gebruiker");
            DropTable("dbo.Departement");
        }
    }
}
