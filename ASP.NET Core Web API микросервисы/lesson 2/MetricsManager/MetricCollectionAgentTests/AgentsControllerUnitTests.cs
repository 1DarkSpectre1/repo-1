using metrica_collection_agent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricCollectionAgentTests
{
    public class AgentsControllerUnitTests
    {
        
        private AgentsController controller;

        public AgentsControllerUnitTests()
        {
            controller = new AgentsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange

            //Act
            var result = controller.GetListAuthObjects();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
