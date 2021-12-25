using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.IO;
using System.Collections;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class DiagnosticReportTests
    {
        [Fact]
        public void ReadsFileCorrectly()
        {
            var sut = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");

            sut.Content.Count.Should().Be(12);
            sut.Content[0].ContentAsString.Should().Be("00100");
            sut.Content[1].ContentAsString.Should().Be("11110");
            sut.Content[5].ContentAsString.Should().Be("01111");
            sut.Content[10].ContentAsString.Should().Be("00010");
        }

        
        [Fact]
        public void Throws_WhenInputFile_ContainsNumbers_OfUnevenLengths()
        {
            DiagnosticReport sut;
            Action act = () => sut = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\InputFileWithUnevenLengths.txt");

            act.Should().Throw<InvalidDataException>();    
        }
    }
}
