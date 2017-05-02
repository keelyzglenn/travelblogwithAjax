using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Controllers;
using TravelBlog.Models;
using Xunit;
using System.Linq;
using Moq;
using System;

namespace TravelBlog.Tests
{
    public class SuggestionControllerTests : IDisposable
    {
        Mock<ISuggestionRepository> mock = new Mock<ISuggestionRepository>();
        EFSuggestionRepository db = new EFSuggestionRepository(new TestDbContext());
        public void Dispose()
        {
            db.DeleteAll();
        }
        private void DbSetup()
        {
            mock.Setup(m => m.Suggestions).Returns(new Suggestion[]
            {
                new Suggestion { Destination = "Hawaii", Description = "Sunny", Upvote = 4, SuggestionId = 1 },
                new Suggestion { Destination = "Costa Rica", Description = "Beach", Upvote = 2, SuggestionId = 2 },
                new Suggestion { Destination = "London", Description="Foggy", Upvote = 3, SuggestionId = 3 }
            }.AsQueryable());
        }

        [Fact]
        public void Mock_GetViewResultIndex_Test()
        {
            //Arrange
            DbSetup();
            SuggestionController controller = new SuggestionController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfItems_Test()
        {
            //arrange
            DbSetup();
            ViewResult indexView = new SuggestionController(mock.Object).Index() as ViewResult;
            //act
            var result = indexView.ViewData.Model;
            //assert
            Assert.IsType<List<Suggestion>>(result);
        }
        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            SuggestionController controller = new SuggestionController(mock.Object);
            Suggestion testSuggestion = new Suggestion("Hawaii", "Sunny", 4, 1);

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Suggestion>;

            Assert.Contains(testSuggestion, collection);

      
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            SuggestionController controller = new SuggestionController(db);
            controller.Create("Mexico", "Good Food");
            var dbSuggestion = db.Suggestions.FirstOrDefault();

            Assert.Equal("Mexico", dbSuggestion.Destination);
        }

    }
}
