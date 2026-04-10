using Xunit;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// PushMessageInDto 单元测试
    /// </summary>
    public class PushMessageInDtoTests
    {
        [Fact]
        public void PushMessageInDto_ShouldHaveDefaultValues()
        {
            // Arrange & Act
            var inDto = new PushMessageInDto();

            // Assert
            Assert.Empty(inDto.title);
            Assert.Empty(inDto.body);
            Assert.Empty(inDto.payload);
            Assert.False(inDto.istransmsg);
            Assert.Equal(TargetUserFilter.cid, inDto.filter);
            Assert.Empty(inDto.filterCondition);
            Assert.False(inDto.is_async);
        }

        [Fact]
        public void PushMessageInDto_ObjectInitializer_ShouldWork()
        {
            // Arrange
            string title = "Test Title";
            string body = "Test Body";
            string payload = "{\"key\":\"value\"}";
            bool istransmsg = true;
            TargetUserFilter filter = TargetUserFilter.uid;
            string[] filterCondition = new[] { "user1", "user2" };
            bool isAsync = true;

            // Act
            var inDto = new PushMessageInDto
            {
                title = title,
                body = body,
                payload = payload,
                istransmsg = istransmsg,
                filter = filter,
                filterCondition = filterCondition,
                is_async = isAsync
            };

            // Assert
            Assert.Equal(title, inDto.title);
            Assert.Equal(body, inDto.body);
            Assert.Equal(payload, inDto.payload);
            Assert.True(inDto.istransmsg);
            Assert.Equal(filter, inDto.filter);
            Assert.Equal(filterCondition, inDto.filterCondition);
            Assert.True(inDto.is_async);
        }

        [Fact]
        public void PushMessageInDto_Filter_All_ShouldWork()
        {
            // Arrange & Act
            var inDto = new PushMessageInDto
            {
                filter = TargetUserFilter.all
            };

            // Assert
            Assert.Equal(TargetUserFilter.all, inDto.filter);
        }

        [Fact]
        public void PushMessageInDto_Filter_Cid_ShouldWork()
        {
            // Arrange & Act
            var inDto = new PushMessageInDto
            {
                filter = TargetUserFilter.cid,
                filterCondition = new[] { "cid123" }
            };

            // Assert
            Assert.Equal(TargetUserFilter.cid, inDto.filter);
            Assert.Single(inDto.filterCondition);
        }

        [Fact]
        public void PushMessageInDto_WithEmptyFilterCondition_ShouldHaveEmptyArray()
        {
            // Arrange & Act
            var inDto = new PushMessageInDto();

            // Assert
            Assert.NotNull(inDto.filterCondition);
            Assert.Empty(inDto.filterCondition);
        }
    }
}
