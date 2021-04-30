using metricaManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricManagerTests
{
    public class HddControllerUnitTests
    {
        private HddMetricsController controller;

        public HddControllerUnitTests()
        {
            controller = new HddMetricsController();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var remainingMemory = 123;


            //Act
            var result = controller.GetMetricsFromAgent(remainingMemory);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
