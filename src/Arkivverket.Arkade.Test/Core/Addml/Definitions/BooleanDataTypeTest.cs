﻿using System;
using Arkivverket.Arkade.Core.Addml.Definitions;
using FluentAssertions;
using Xunit;

namespace Arkivverket.Arkade.Test.Core.Addml.Definitions
{
    public class BooleanDataTypeTest
    {
        [Fact]
        public void ShouldAcceptFieldFormatJN()
        {
            BooleanDataType dataType = new BooleanDataType("J/N");
            dataType.GetTrue().Should().Be("J");
            dataType.GetFalse().Should().Be("N");
        }

        [Fact]
        public void ShouldAcceptFieldFormatYN()
        {
            BooleanDataType dataType = new BooleanDataType("Y/N");
            dataType.GetTrue().Should().Be("Y");
            dataType.GetFalse().Should().Be("N");
        }

        [Fact]
        public void ShouldAcceptFieldFormatTF()
        {
            BooleanDataType dataType = new BooleanDataType("T/F");
            dataType.GetTrue().Should().Be("T");
            dataType.GetFalse().Should().Be("F");
        }

        [Fact]
        public void ShouldAcceptFieldFormatHeppHopp()
        {
            BooleanDataType dataType = new BooleanDataType("hepp/hopp");
            dataType.GetTrue().Should().Be("hepp");
            dataType.GetFalse().Should().Be("hopp");
        }

        [Fact]
        public void ShouldThrowExceptionIfFieldFormatDoesNotContainExactlyOneSlash()
        {
            Assert.Throws<ArgumentException>(() => new BooleanDataType(""));
            Assert.Throws<ArgumentException>(() => new BooleanDataType(" "));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("YN"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("A/B/C"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("//"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("///////"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("ABC/ABC/ABC"));
        }

        [Fact]
        public void ShouldThrowExceptionIfTrueOrFalseOrBothAreEmpty()
        {
            Assert.Throws<ArgumentException>(() => new BooleanDataType("J/"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("/N"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("/"));
        }

        [Fact]
        public void ShouldThrowExceptionIfTrueOrFalseOrBothAreOnlyWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new BooleanDataType(" /"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("/ "));
            Assert.Throws<ArgumentException>(() => new BooleanDataType(" / "));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("   /     "));
        }

        [Fact]
        public void ShouldThrowExceptionIfTrueAndFalseAreEqual()
        {
            Assert.Throws<ArgumentException>(() => new BooleanDataType("T/T"));
            Assert.Throws<ArgumentException>(() => new BooleanDataType("hepp/hepp"));
        }

    }
}
