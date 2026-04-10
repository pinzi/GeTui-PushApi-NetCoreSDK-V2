using Xunit;

namespace GeTuiPushApiV2.NetCoreSDK.Core.UnitTest
{
    /// <summary>
    /// TargetUserFilter 枚举单元测试
    /// </summary>
    public class TargetUserFilterTests
    {
        [Fact]
        public void TargetUserFilter_All_ShouldBeZero()
        {
            // Assert
            Assert.Equal(0, (int)TargetUserFilter.all);
        }

        [Fact]
        public void TargetUserFilter_Cid_ShouldBeOne()
        {
            // Assert
            Assert.Equal(1, (int)TargetUserFilter.cid);
        }

        [Fact]
        public void TargetUserFilter_Uid_ShouldBeTwo()
        {
            // Assert
            Assert.Equal(2, (int)TargetUserFilter.uid);
        }

        [Fact]
        public void TargetUserFilter_Alias_ShouldBeThree()
        {
            // Assert
            Assert.Equal(3, (int)TargetUserFilter.alias);
        }

        [Fact]
        public void TargetUserFilter_Tag_ShouldBeFour()
        {
            // Assert
            Assert.Equal(4, (int)TargetUserFilter.tag);
        }

        [Fact]
        public void TargetUserFilter_Values_ShouldContainAllFilters()
        {
            // Act
            var values = Enum.GetValues(typeof(TargetUserFilter));

            // Assert
            Assert.Equal(5, values.Length);
        }
    }
}
