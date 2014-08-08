﻿using System;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia.UI.Converters
{
    public class PathFolderNameConverterTests
    {
        private readonly PathFolderNameConverter _converter;

        public PathFolderNameConverterTests()
        {
            _converter = new PathFolderNameConverter();
        }

        [Theory]
        [InlineData(@"C:\Program Files\Cool Programs\Music", "Music")]
        [InlineData(@"C:\Users\ChuckNorris\Videos\TV Shows", "TV Shows")]
        [InlineData(@"C:\", @"C:\")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void Convert_FullPath_ReturnsLastFolderName(string fullPath, string folderName)
        {
            // Act
            object result = _converter.Convert(fullPath, null, null, null);

            // Assert
            Assert.IsType<string>(result);
            Assert.Equal(folderName, (string)result);
        }

        [Fact]
        public void ConvertBack_Always_ThrowsNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                _converter.ConvertBack(null, null, null, null);
            });
        }
    }
}
