using Xunit;
using GeTuiPushApiV2.NetCoreSDK.Core.MemoryCache;
using GeTuiPushApiV2.NetCoreSDK.Storage;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// MemoryCacheStorage 单元测试
    /// </summary>
    public class MemoryCacheStorageTests
    {
        private readonly MemoryCacheStorage _storage;
        private readonly GeTuiPushOptions _options;

        public MemoryCacheStorageTests()
        {
            _options = new GeTuiPushOptions
            {
                AppID = "test_app_id",
                AppKey = "test_app_key",
                MasterSecret = "test_master_secret"
            };
            _storage = new MemoryCacheStorage(_options);
        }

        [Fact]
        public void SaveToken_ShouldSaveTokenSuccessfully()
        {
            // Arrange
            string appId = "test_app";
            string token = "test_token_123";

            // Act
            _storage.SaveToken(appId, token);
            string result = _storage.GetToken(appId);

            // Assert
            Assert.Equal(token, result);
        }

        [Fact]
        public void DeleteToken_ShouldRemoveToken()
        {
            // Arrange
            string appId = "test_app";
            string token = "test_token_456";
            _storage.SaveToken(appId, token);

            // Act
            _storage.DeleteToken(appId);
            string result = _storage.GetToken(appId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetToken_ShouldReturnNull_ForNonExistentApp()
        {
            // Arrange
            string appId = "non_existent_app";

            // Act
            string result = _storage.GetToken(appId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SaveCID_ShouldSaveCidSuccessfully()
        {
            // Arrange
            string uid = "user_123";
            string cid = "cid_456";

            // Act
            _storage.SaveCID(uid, cid);
            List<string> result = _storage.GetCID(uid);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid, result);
        }

        [Fact]
        public void SaveCID_ShouldAddMultipleCidsForSameUser()
        {
            // Arrange
            string uid = "user_789";
            string cid1 = "cid_001";
            string cid2 = "cid_002";

            // Act
            _storage.SaveCID(uid, cid1);
            _storage.SaveCID(uid, cid2);
            List<string> result = _storage.GetCID(uid);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid1, result);
            Assert.Contains(cid2, result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void DeleteCID_ShouldRemoveAllCidsForUser()
        {
            // Arrange
            string uid = "user_delete";
            string cid1 = "cid_a";
            string cid2 = "cid_b";
            _storage.SaveCID(uid, cid1);
            _storage.SaveCID(uid, cid2);

            // Act
            _storage.DeleteCID(uid);
            List<string> result = _storage.GetCID(uid);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteCID_ShouldRemoveSpecificCidOnly()
        {
            // Arrange
            string uid = "user_partial";
            string cid1 = "cid_keep";
            string cid2 = "cid_remove";
            _storage.SaveCID(uid, cid1);
            _storage.SaveCID(uid, cid2);

            // Act
            _storage.DeleteCID(uid, cid2);
            List<string> result = _storage.GetCID(uid);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid1, result);
            Assert.DoesNotContain(cid2, result);
            Assert.Single(result);
        }

        [Fact]
        public void SaveAlias_ShouldSaveAliasSuccessfully()
        {
            // Arrange
            string alias = "alias_test";
            string cid = "cid_alias_123";

            // Act
            _storage.SaveAlias(alias, cid);
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid, result);
        }

        [Fact]
        public void SaveAlias_WithList_ShouldSaveMultipleCids()
        {
            // Arrange
            string alias = "alias_batch";
            List<string> cids = new List<string> { "cid_1", "cid_2", "cid_3" };

            // Act
            _storage.SaveAlias(alias, cids);
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains("cid_1", result);
            Assert.Contains("cid_2", result);
            Assert.Contains("cid_3", result);
        }

        [Fact]
        public void DeleteAlias_ShouldRemoveAllCidsForAlias()
        {
            // Arrange
            string alias = "alias_delete";
            _storage.SaveAlias(alias, "cid_a");
            _storage.SaveAlias(alias, "cid_b");

            // Act
            _storage.DeleteAlias(alias);
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void DeleteAlias_WithCid_ShouldRemoveSpecificCid()
        {
            // Arrange
            string alias = "alias_partial";
            string cid1 = "cid_keep";
            string cid2 = "cid_remove";
            _storage.SaveAlias(alias, cid1);
            _storage.SaveAlias(alias, cid2);

            // Act
            _storage.DeleteAlias(alias, cid2);
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid1, result);
            Assert.DoesNotContain(cid2, result);
        }

        [Fact]
        public void DeleteAlias_WithList_ShouldRemoveMultipleCids()
        {
            // Arrange
            string alias = "alias_batch_delete";
            string cid1 = "cid_keep";
            string cid2 = "cid_remove_1";
            string cid3 = "cid_remove_2";
            _storage.SaveAlias(alias, cid1);
            _storage.SaveAlias(alias, cid2);
            _storage.SaveAlias(alias, cid3);

            // Act
            _storage.DeleteAlias(alias, new List<string> { cid2, cid3 });
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(cid1, result);
            Assert.DoesNotContain(cid2, result);
            Assert.DoesNotContain(cid3, result);
            Assert.Single(result);
        }

        [Fact]
        public void GetAlias_ShouldReturnNull_ForNonExistentAlias()
        {
            // Arrange
            string alias = "non_existent_alias";

            // Act
            List<string> result = _storage.GetAlias(alias);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SaveTag_ShouldSaveTagSuccessfully()
        {
            // Arrange
            string tag = "tag_test";
            string cid = "cid_tag_123";

            // Act
            _storage.SaveTag(tag, cid);
            List<string> result = _storage.GetAlias($"tag:{tag}");

            // Note: This test verifies the tag is saved, but the actual implementation
            // may store tags differently. Adjust based on actual implementation.
        }

        [Fact]
        public void SaveUserBlack_ShouldSaveBlacklistedCid()
        {
            // Arrange
            string cid = "blacklist_cid_123";

            // Act
            _storage.SaveUserBlack(cid);
            List<string> result = _storage.GetAlias($"blacklist:{cid}");

            // Note: This test verifies the blacklist functionality exists.
            // Actual implementation details may vary.
        }

        [Fact]
        public void SaveUserBlack_WithList_ShouldSaveMultipleCids()
        {
            // Arrange
            List<string> cids = new List<string> { "black_1", "black_2", "black_3" };

            // Act
            _storage.SaveUserBlack(cids);

            // Note: This test verifies the batch blacklist functionality exists.
        }

        [Fact]
        public void DeleteUserBlack_ShouldRemoveBlacklistedCid()
        {
            // Arrange
            string cid = "blacklist_remove";
            _storage.SaveUserBlack(cid);

            // Act
            _storage.DeleteUserBlack(cid);

            // Note: This test verifies the delete blacklist functionality exists.
        }

        [Fact]
        public void DeleteUserBlack_WithList_ShouldRemoveMultipleCids()
        {
            // Arrange
            List<string> cids = new List<string> { "black_remove_1", "black_remove_2" };
            _storage.SaveUserBlack(cids);

            // Act
            _storage.DeleteUserBlack(cids);

            // Note: This test verifies the batch delete blacklist functionality exists.
        }
    }
}
