﻿using PerfectMedia.UI.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PerfectMedia.Tests.UI.Converters
{
    public class IsEmptyToBooleanConverterTests
    {
        private readonly IsEmptyToBooleanConverter _converter;

        public IsEmptyToBooleanConverterTests()
        {
            _converter = new IsEmptyToBooleanConverter();
        }

        [Fact]
        public void Convert_EmptyCollection_ReturnsFalse()
        {
            // Arrange
            List<string> collection = new List<string>();

            // Act
            object result = _converter.Convert(collection, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.False((bool)result);
        }

        [Fact]
        public void Convert_Null_ReturnsFalse()
        {
            // Act
            object result = _converter.Convert(null, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.False((bool)result);
        }

        [Fact]
        public void Convert_CollectionWithElement_ReturnsTrue()
        {
            // Arrange
            List<string> collection = new List<string> { "Hello" };

            // Act
            object result = _converter.Convert(collection, null, null, null);

            // Assert
            Assert.IsType<bool>(result);
            Assert.True((bool)result);
        }
    }
}
