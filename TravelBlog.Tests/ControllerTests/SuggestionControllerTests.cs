using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Controllers;
using TravelBlog.Models;
using Xunit;
using System.Linq;
using Moq;

namespace TravelBlog.Tests
{
    public class SuggestionControllerTests
    {
        Mock<ISuggestionRepository> mock = new Mock<ISuggestionRepository>();
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


    }
}
