using Microsoft.EntityFrameworkCore.Migrations;

namespace SongBook.Repo.Migrations
{
    public partial class Filestream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                $@"ALTER DATABASE CURRENT
                  ADD FILEGROUP SongBookFileGroup CONTAINS FILESTREAM
                  GO
                  ALTER DATABASE CURRENT
                  ADD FILE
                  (
                      NAME = 'SongBookFileGroup',
                      FILENAME = 'c:\Database\songbook_file_group'
                  )
                  TO FILEGROUP SongBookFileGroup
                  GO",
                true
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
