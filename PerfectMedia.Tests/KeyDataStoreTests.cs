using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            _fileBackedRepository.Load()
                .Returns(Task.FromResult(dictionary));
            _keyDataStore = new KeyDataStore(_fileBackedRepository);
        }

        [Fact]
        public async Task Initialize_Always_LoadsDataInMemory()
        {
            // Act
            await InitializeKeyDataStore();

            // Assert
            _fileBackedRepository.Received()
                .Load().Async();
        }

        [Fact]
        public async Task Dispose_WithoutData_DoesNothing()
        {
            // Arrange
            await InitializeKeyDataStore();

            // Act
            _keyDataStore.Dispose();

            // Assert
            _fileBackedRepository.DidNotReceive()
                .Save(Arg.Any<IDictionary<string, string>>());
        }

        [Fact]
        public async Task Dispose_WithData_PersistsIt()
        {
            // Arrange
            await InitializeKeyDataStore();
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
        public async Task GetValue_AfterSetValue_ReturnsIt()
        {
            // Arrange
            await InitializeKeyDataStore();
            _keyDataStore.SetValue("A long key", "rawr");

            // Act
            string value = _keyDataStore.GetValue("A long key");

            // Assert
            Assert.Equal("rawr", value);
        }

        [Fact]
        public async Task GetValue_WhichIsUndefined_ReturnsEmptyString()
        {
            // Arrange
            await InitializeKeyDataStore();

            // Act
            string value = _keyDataStore.GetValue("Undefined key");

            // Arrange
            Assert.Empty(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task GetValue_WithNullOrEmptyKey_ThrowsException(string str)
        {
            // Arrange
            await InitializeKeyDataStore();

            Assert.Throws<ArgumentNullException>(() =>
            {
                // Act
                _keyDataStore.GetValue(str);
            });
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task SetValue_WithNullOrEmptyKey_ThrowsException(string str)
        {
            // Arrange
            await InitializeKeyDataStore();

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => _keyDataStore.SetValue(str, "whatever"));
        }

        private async Task InitializeKeyDataStore()
        {
            await ((IStartupInitialization)_keyDataStore).Initialize();
        }
    }
}
