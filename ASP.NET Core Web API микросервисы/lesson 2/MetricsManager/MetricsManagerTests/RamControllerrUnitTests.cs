using metricaManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricManagerTests
{
    public class RamControllerrUnitTests
    {
        private RamMetricsControllerr controller;

        public RamControllerrUnitTests()
        {
            controller = new RamMetricsControllerr();
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            //Arrange
            var freeMemory = 123;
            

            //Act
            var result = controller.GetMetricsFromAgent(freeMemory);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}
