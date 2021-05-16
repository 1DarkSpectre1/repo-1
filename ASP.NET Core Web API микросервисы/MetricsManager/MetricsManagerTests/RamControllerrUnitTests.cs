using MetricsManager.Controllers;
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

            //Act
            var result = controller.GetMetricsFromAgent();

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}