namespace InvoiceTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOnInvoiceToInvoiceItem : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OnInvoices", newName: "InvoiceItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.InvoiceItems", newName: "OnInvoices");
        }
    }
}
