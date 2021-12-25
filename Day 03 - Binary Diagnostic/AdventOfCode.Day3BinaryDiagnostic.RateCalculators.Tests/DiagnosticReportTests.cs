using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.IO;
using System.Collections;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class DiagnosticReportTests
    {
        [Fact]
        public void ReadsFileCorrectly()
        {
            var sut = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\InputForUnitTests.txt");

            sut.Content.Count.Should().Be(3);
            sut.Content[0].RawContent.Should().Be("101011");
            sut.Content[1].RawContent.Should().Be("100100");
            sut.Content[2].RawContent.Should().Be("101010");
        }
    }
}
