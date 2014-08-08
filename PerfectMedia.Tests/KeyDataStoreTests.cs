using System;
using System.Collections.Generic;
using NSubstitute;
using Xunit;
using Xunit.Extensions;

namespace PerfectMedia
{
    public class KeyDataStoreTests
    {
        private readonly KeyDataStore _keyDataStore;
        private readonly IFileBackedRepository _fileBackedRepository;

        public KeyDataStoreTests()
        {
            _fileBackedRepository = Substitute.For<IFileBackedRepository>();
            _fileBackedRepository.Load()
                .Returns(new Dictionary<string, string>());
            _keyDataStore = new KeyDataStore(_fileBackedRepository);
        }

        [Fact]
        public void Constructor_Always_LoadsDataInMemory()
        {
            // Assert
            _fileBackedRepository.Received()
                .Load();
        }

        [Fact]
        public void Dispose_WithoutData_DoesNothing()
        {
            // Act
            _keyDataStore.Dispose();

            // Assert
            _fileBackedRepository.DidNotReceive()
                .Save(Arg.Any<IDictionary<string, string>>());
        }

        [Fact]
        public void Dispose_WithData_PersistsIt()
        {
            // Arrange
            _keyDataStore.SetValue("Key1", "I'm a dinosaur!");
            _keyDataStore.SetValue("Key2", "Rawr!");

            // Act
            _keyDataStore.Dispose();

            // Assert
            _fileBackedRepository.Received()
                .Save(Arg.Is<IDictionary<string, string>>(dictionary => dictionary.Count == 2
                    && dictionary["Key1"] == "I'm a dinosaur!"
                    && dictionary["Key2"] == "Rawr!"));
        }

        [Fact]
        public void GetValue_AfterSetValue_ReturnsIt()
        {
            // Arrange
            _keyDataStore.SetValue("A long key", "rawr");

            // Act
            string value = _keyDataStore.GetValue("A long key");

            // Assert
            Assert.Equal("rawr", value);
        }

        [Fact]
        public void GetValue_WhichIsUndefined_ReturnsEmptyString()
        {
            // Act
            string value = _keyDataStore.GetValue("Undefined key");

            // Arrange
            Assert.Empty(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GetValue_WithNullOrEmptyKey_ThrowsException(string str)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _keyDataStore.GetValue(str);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void SetValue_WithNullOrEmptyKey_ThrowsException(string str)
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => _keyDataStore.SetValue(str, "whatever"));
        }
    }
}
