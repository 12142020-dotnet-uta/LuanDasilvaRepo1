using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Project0;
using Models;

namespace Project0.Tests
{
    public class DataAccessTests
    
    {
        

  [Fact]
        public void CreateBaseFloorSavesANewUserToTheDb()
        {
            // arrange
            //creating the in-memory Db
            var options = new DbContextOptionsBuilder<DataAccessLayer.Project0DbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            // act
            BaseFloor bf = new BaseFloor();
            // add to the In-Memory Db
            
            using (var context = new DataAccessLayer.Project0DbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                DataAccessLayer.Project0RepoLayer repo = new DataAccessLayer.Project0RepoLayer(context);
                bf  = repo.DBCreateBaseFloor("TestExhibit", 1, 1);
                //context.SaveChanges();
            }

            //assert
            // verify the the result was as expected
            using (var context1 = new DataAccessLayer.Project0DbContext(options))
            {
                //context.Database.EnsureCreated();
                DataAccessLayer.Project0RepoLayer repo = new DataAccessLayer.Project0RepoLayer(context1);
                BaseFloor bfverify  = repo.DBCreateBaseFloor("TestExhibit", 1, 1);

                Assert.Equal(bfverify.LocationCodeName, bf.LocationCodeName);
                



            }
        }



    }
}
 