using FluentAssertions;
using FluentAssertions.Execution;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class LRUCacheTests
{
    private LRUCache sut;

    [Fact]
    public void LRUCache_ShouldRetrieveCorrectItems()
    {
        sut = new LRUCache(2);
        using (new AssertionScope())
        {
            sut.Put(1, 1);
            sut.Put(2, 2);
            sut.Get(1).Should().Be(1);
            sut.Put(3, 3);
            sut.Get(2).Should().Be(-1);
            sut.Put(4, 4);
            sut.Get(1).Should().Be(-1);
            sut.Get(3).Should().Be(3);
            sut.Get(4).Should().Be(4);
        }
    }
}
