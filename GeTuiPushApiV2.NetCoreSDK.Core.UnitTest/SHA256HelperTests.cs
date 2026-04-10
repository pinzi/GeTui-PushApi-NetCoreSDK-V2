using Xunit;
using GeTuiPushApiV2.NetCoreSDK.Core.Utility;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// SHA256Helper 单元测试
    /// </summary>
    public class SHA256HelperTests
    {
        [Fact]
        public void SHA256Encrypt_ShouldReturnCorrectHash()
        {
            // Arrange
            string input = "hello";
            string expected = "2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824";

            // Act
            string result = SHA256Helper.SHA256Encrypt(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SHA256Encrypt_ShouldReturnEmptyString_ForNullOrEmptyInput()
        {
            // Arrange
            string? input = null;

            // Act
            string result = SHA256Helper.SHA256Encrypt(input!);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SHA256Encrypt_ShouldReturnEmptyString_ForEmptyStringInput()
        {
            // Arrange
            string input = string.Empty;

            // Act
            string result = SHA256Helper.SHA256Encrypt(input);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SHA256Encrypt_ShouldBeConsistent()
        {
            // Arrange
            string input = "test123";

            // Act
            string result1 = SHA256Helper.SHA256Encrypt(input);
            string result2 = SHA256Helper.SHA256Encrypt(input);

            // Assert
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void SHA512Encrypt_ShouldReturnCorrectHash()
        {
            // Arrange
            string input = "hello";
            string expected = "9b71d224bd62f3785d96d46ad3ea3d73319bfbc2890caadae2dff72519673ca72323c3d99ba5c11d7c7acc6e14b8c5da0c4663475c2e5c3adef46f73bcdec043";

            // Act
            string result = SHA256Helper.SHA512Encrypt(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
