using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GenericExtensions.Tests.tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void VerifyCaseInsensitiveContains()
        {
            const string targetString = "There are some StringS to test";
            targetString.CaseInsensitiveContains("strings").Should().BeTrue();
        }

        [Fact]
        public void VerifyConvertTo()
        {
            const string targetString = "4.56";
            var result = targetString.ConvertTo<double>();
            result.Should().BeOfType(typeof(double));
        }

        [Fact]
        public void VerifyIsNullOrEmpty()
        {
            const string targetNull = null;
            const string targetEmptyString = "";
            var result = targetNull.IsNullOrEmpty() || targetEmptyString.IsNullOrEmpty();
            result.Should().BeTrue();
        }

        [Fact]
        public void VerifyParseToList()
        {
            const string targetString = "234;43;23;432;43234;23";
            var actualList = targetString.ParseToList<int>(";");
            var expectedList = new List<int> {234, 43, 23, 432, 43234, 23};
            actualList.Should().BeEquivalentTo(expectedList);
        }

        [Fact]
        public void VerifyRemove()
        {
            const string targetString = "2342;343;23;432;343234;23";
            const string expectedString = "423434323434";
            var actualList = targetString.Remove("23", ";");
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyRemoveFormatting()
        {
            const string targetString = "234&nbsp; 2,343,23 32 343&nbsp; 234 23";
            const string expectedString = "2342343233234323423";
            var actualList = targetString.RemoveFormatting();
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyRemoveNotLetters()
        {
            const string targetString = "23s42;34u3;23;43p2;343e234;2r3";
            const string expectedString = "super";
            var actualList = targetString.RemoveNotLetters();
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyRemoveNotDigits()
        {
            const string targetString = "23s42;34u3;23;43p2;343e234;2r3";
            const string expectedString = "23423432343234323423";
            var actualList = targetString.RemoveNotDigits();
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyRemoveSpaceDuplications()
        {
            const string targetString = "s      u    p    e r  ";
            const string expectedString = "s u p e r ";
            var actualList = targetString.RemoveSpaceDuplications();
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyRemoveWhiteSpaces()
        {
            const string targetString = "s      u    p    e r  ";
            const string expectedString = "super";
            var actualList = targetString.RemoveWhiteSpaces();
            actualList.Should().BeEquivalentTo(expectedString);
        }

        [Fact]
        public void VerifyToDateTime()
        {
            const string targetString = "12/01/2015";
            DateTime.TryParseExact("12/01/2015", "MM/dd/yyyy", null, DateTimeStyles.None, out var expectedDate);
            var actualDate = targetString.ToDateTime("MM/dd/yyyy");
            actualDate.Should().Be(expectedDate);
        }
        
        [Fact]
        public void VerifyToDecimal()
        {
            const string targetString = "105";
            const decimal expected = 105;
            var actual = targetString.ToDecimal();
            actual.Should().Be(expected);
        }
        
        [Fact]
        public void VerifyToInt()
        {
            const string targetString = "105";
            const int expected = 105;
            var actual = targetString.ToInt();
            actual.Should().Be(expected);
        }
        
        [Fact]
        public void VerifyToNullIfEmpty()
        {
            const string targetString = "";
            var actual = targetString.ToNullIfEmpty();
            actual.Should().BeNull();
        }
    }
}