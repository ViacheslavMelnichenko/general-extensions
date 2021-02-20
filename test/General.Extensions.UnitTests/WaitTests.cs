using System;
using System.Diagnostics;
using FluentAssertions;
using GenericExtensions.src;
using Xunit;

namespace GenericExtensions.Tests.tests
{
    public class WaitTests
    {
        [Fact]
        public void ShouldNotThrowExceptionIfRespectTimeout()
        {
            //Arrange
            var stopwatch = Stopwatch.StartNew();

            //Act
            Action result = () => Wait.For(() => stopwatch.ElapsedMilliseconds > 50, timeout: 150);

            //Assert
            result.Should().NotThrow<TimeoutException>();
        }

        [Fact]
        public void ShouldThrowExceptionIfPassTimeout()
        {
            //Arrange
            //Act
            Action result = () => Wait.For(() => false, timeout: 1);
            //Assert
            result.Should().Throw<TimeoutException>();
        }
    }
}
