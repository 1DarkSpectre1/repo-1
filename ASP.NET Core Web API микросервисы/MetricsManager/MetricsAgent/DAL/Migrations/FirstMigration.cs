using FluentMigrator;

namespace MetricsAgent.DAL.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Up()
        {
            Create.Table("cpuMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("dotNetMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("hddMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("networkMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            Create.Table("ramMetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("cpuMetrics");
            Delete.Table("dotNetMetrics");
            Delete.Table("hddMetrics");
            Delete.Table("networkMetrics");
            Delete.Table("ramMetrics");
        }
    }
}