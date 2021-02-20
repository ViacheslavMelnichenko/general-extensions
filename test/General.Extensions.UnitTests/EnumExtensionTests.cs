using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GenericExtensions.Tests.tests
{
    public class EnumExtensionTests
    {
        private readonly List<string> _simpleList = new List<string>
        {
            "One",
            "Two",
            "3",
            "Four",
            "Five"
        };

        [Fact]
        public void VerifyAggregateBy()
        {
            var aggregationResult = _simpleList.AggregateBy(";");
            aggregationResult.Should().BeEquivalentTo("One;Two;3;Four;Five");
        }

        [Fact]
        public void VerifyAggregateByForEmptyList()
        {
            var aggregationResult = new List<string>().AggregateBy("");
            aggregationResult.Should().BeEquivalentTo(null);
        }

        [Fact]
        public void VerifyAggregateByForListWithOneElement()
        {
            const string testValue = "One";
            var aggregationResult = new List<string> {testValue};
            aggregationResult.AggregateBy(";").Should().BeEquivalentTo(testValue);
        }

        [Fact]
        public void VerifyForEach()
        {
            var lowerCaseValues = _simpleList.Select(e => e.ToLower()).ToList();
            var aimedList = new List<string>();
            _simpleList.ForEach(e => aimedList.Add(e.ToLower()));
            aimedList.Should().BeEquivalentTo(lowerCaseValues);
        }


        [Fact]
        public void VerifyGetEnumDescription()
        {
            const string expectedDescription = "One";
            var actualDescription = TestEnum.FirstOne.GetEnumDescription();
            actualDescription.Should().BeEquivalentTo(expectedDescription);
        }
    }

    public enum TestEnum
    {
        [Description("One")] 
        FirstOne,
        
        [Description("Two")] 
        SecondOne
    }
}