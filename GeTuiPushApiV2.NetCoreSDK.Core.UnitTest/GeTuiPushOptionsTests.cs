using Xunit;
using GeTuiPushApiV2.NetCoreSDK.Storage;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// GeTuiPushOptions 单元测试
    /// </summary>
    public class GeTuiPushOptionsTests
    {
        [Fact]
        public void GeTuiPushOptions_ShouldHaveDefaultValues()
        {
            // Arrange & Act
            var options = new GeTuiPushOptions();

            // Assert
            Assert.Empty(options.AppID);
            Assert.Empty(options.AppKey);
            Assert.Empty(options.MasterSecret);
        }

        [Fact]
        public void GeTuiPushOptions_ShouldSetProperties()
        {
            // Arrange
            var options = new GeTuiPushOptions();
            string appId = "test_app_id";
            string appKey = "test_app_key";
            string masterSecret = "test_master_secret";

            // Act
            options.AppID = appId;
            options.AppKey = appKey;
            options.MasterSecret = masterSecret;

            // Assert
            Assert.Equal(appId, options.AppID);
            Assert.Equal(appKey, options.AppKey);
            Assert.Equal(masterSecret, options.MasterSecret);
        }

        [Fact]
        public void GeTuiPushOptions_ObjectInitializer_ShouldWork()
        {
            // Arrange
            string appId = "app123";
            string appKey = "key456";
            string masterSecret = "secret789";

            // Act
            var options = new GeTuiPushOptions
            {
                AppID = appId,
                AppKey = appKey,
                MasterSecret = masterSecret
            };

            // Assert
            Assert.Equal(appId, options.AppID);
            Assert.Equal(appKey, options.AppKey);
            Assert.Equal(masterSecret, options.MasterSecret);
        }
    }
}
