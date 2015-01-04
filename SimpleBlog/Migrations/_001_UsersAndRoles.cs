using System.Data;
using FluentMigrator;
using FluentMigrator.Expressions;

namespace SimpleBlog.Migrations
{
    // parameter = version number
    [Migration(1)]    
    public class _001_UsersAndRoles : Migration // Migration requires 2 abstract members (Down and Up)
    {
        // method invoked when FluentMigrator decides that the db needs to be migrated (modifications made)
        public override void Up()
        {
            // create some tables
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsCustom("VARCHAR(256)")
                .WithColumn("password_hash").AsString(128);

            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);

            // create pivot table that will relate roles to users
            Create.Table("role_users")
                // if a user is deleted, then delete the row in role_users
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(Rule.Cascade);


        }
        // method invoked when FluentMigrator needs the db to be rolled-back (deletes tables)
        public override void Down()
        {
            // role_users must be deleted before roles or users (role users table has a foreign key constraint)
            Delete.Table("role_users");
            Delete.Table("roles");
            Delete.Table("users");
        }
    }
}