using Xunit;
using GeTuiPushApiV2.NetCoreSDK.Core.Utility;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// Extends 扩展方法单元测试
    /// </summary>
    public class ExtendsTests
    {
        [Fact]
        public void ToStr_ShouldReturnString_ForNonNullObject()
        {
            // Arrange
            object obj = 123;
            string expected = "123";

            // Act
            string result = obj.ToStr();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToStr_ShouldReturnEmptyString_ForNullObject()
        {
            // Arrange
            object? obj = null;

            // Act
            string result = obj!.ToStr();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ToStr_ShouldReturnString_ForStringObject()
        {
            // Arrange
            object obj = "hello";
            string expected = "hello";

            // Act
            string result = obj.ToStr();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToStr_ShouldReturnString_ForDateTimeObject()
        {
            // Arrange
            DateTime dt = new DateTime(2023, 1, 1, 12, 0, 0);
            string expected = "2023/1/1 12:00:00";

            // Act
            string result = dt.ToStr();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
