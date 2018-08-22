namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable("Test1", builder => new
            {
                Id = builder.Int(identity: true, nullable: false),
                Name = builder.String(nullable: true)
            });
        }

        public override void Down()
        {
            DropTable("Test1");
        }
    }
}
