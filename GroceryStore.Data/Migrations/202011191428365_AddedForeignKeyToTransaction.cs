namespace GroceryStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeyToTransaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Transaction", new[] { "IngredientId" });
            DropTable("dbo.Transaction");
        }
    }
}
