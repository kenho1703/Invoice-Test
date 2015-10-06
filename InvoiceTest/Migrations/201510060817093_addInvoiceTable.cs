namespace InvoiceTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInvoiceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        VAT = c.Single(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        Total = c.Single(nullable: false),
                        Shipping = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OnInvoices", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.OnInvoices", "InvoiceId");
            AddForeignKey("dbo.OnInvoices", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnInvoices", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.OnInvoices", new[] { "InvoiceId" });
            DropColumn("dbo.OnInvoices", "InvoiceId");
            DropTable("dbo.Invoices");
        }
    }
}
