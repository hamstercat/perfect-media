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
                .Returns(dictionary);
            _keyDataStore = new KeyDataStore(_fileBackedRepository);
        }

        [Fact]
        public void Initialize_Always_LoadsDataInMemory()
        {
            // Act
            InitializeKeyDataStore();

            // Assert
            _fileBackedRepository.Received()
                .Load();
        }

        [Fact]
        public void Dispose_WithoutData_DoesNothing()
        {
            // Arrange
            InitializeKeyDataStore();

            // Act
            ((ILifecycleService)_keyDataStore).Uninitialize();

            // Assert
            _fileBackedRepository.DidNotReceive()
                .Save(Arg.Any<IDictionary<string, string>>());
        }

        [Fact]
        public void Dispose_WithData_PersistsIt()
        {
            // Arrange
            InitializeKeyDataStore();
            _keyDataStore.SetValue("Key1", "I'm a dinosaur!");
            _keyDataStore.SetValue("Key2", "Rawr!");

            // Act
            ((ILifecycleService)_keyDataStore).Uninitialize();

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
            InitializeKeyDataStore();
            _keyDataStore.SetValue("A long key", "rawr");

            // Act
            string value = _keyDataStore.GetValue("A long key");

            // Assert
            Assert.Equal("rawr", value);
        }

        [Fact]
        public void GetValue_WhichIsUndefined_ReturnsEmptyString()
        {
            // Arrange
            InitializeKeyDataStore();

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
            // Arrange
            InitializeKeyDataStore();

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
            // Arrange
            InitializeKeyDataStore();

            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => _keyDataStore.SetValue(str, "whatever"));
        }

        private void InitializeKeyDataStore()
        {
            ((ILifecycleService)_keyDataStore).Initialize();
        }
    }
}
