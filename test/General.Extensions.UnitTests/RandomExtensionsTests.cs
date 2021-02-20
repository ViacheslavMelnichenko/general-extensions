using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GenericExtensions.Tests.tests
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void VerifyGetNumber()
        {
            var number = RandomExtensions.GetNumber();
            number.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void VerifyMaxGetNumber()
        {
            var maxValue = 100;
            var number = RandomExtensions.GetNumber(maxValue);
            number.Should().BeOfType(typeof(int));
            number.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public void VerifyMinMaxGetNumber()
        {
            var minValue = -5;
            var maxValue = 10;
            var number = RandomExtensions.GetNumber(minValue, maxValue);
            number.Should().BeOfType(typeof(int));
            number.Should().BeGreaterOrEqualTo(minValue);
            number.Should().BeLessOrEqualTo(maxValue);
        }

        [Fact]
        public void VerifyGetDouble()
        {
            var number = RandomExtensions.GetDouble();
            number.Should().BeOfType(typeof(double));
        }

        [Fact]
        public void VerifyMaxGetDouble()
        {
            var maxValue = 55.5;
            var number = RandomExtensions.GetDouble(maxValue);
            number.Should().BeOfType(typeof(double));
            number.Should().BeLessThan(maxValue);
        }

        [Fact]
        public void VerifyMinMaxGetDouble()
        {
            var minValue = 1.25;
            var maxValue = 111.75;
            var number = RandomExtensions.GetDouble(minValue, maxValue);
            number.Should().BeOfType(typeof(double));
            number.Should().BeGreaterThan(minValue);
            number.Should().BeLessThan(maxValue);
        }

        [Fact]
        public void VerifyGetString()
        {
            var _string = RandomExtensions.GetString();
            _string.Should().BeOfType(typeof(string));
            _string.Should().NotBeNull();
        }

        [Fact]
        public void VerifyMaxGetString()
        {
            var length = 10;
            var _string = RandomExtensions.GetString(length);
            _string.Should().BeOfType(typeof(string));
            var charArray = _string.ToCharArray();
            charArray.Length.Should().BeLessOrEqualTo(length);
        }

        [Fact]
        public void VerifyMinMaxGetString()
        {
            var minLength = 5;
            var maxLength = 125;
            var _string = RandomExtensions.GetString(minLength, maxLength);
            _string.Should().BeOfType(typeof(string));
            var charArray = _string.ToCharArray();
            charArray.Length.Should().BeGreaterOrEqualTo(minLength);
            charArray.Length.Should().BeLessOrEqualTo(maxLength);
        }
    }
}
