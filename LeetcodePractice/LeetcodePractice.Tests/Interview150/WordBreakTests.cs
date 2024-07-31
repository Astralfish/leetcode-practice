using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class WordBreakTests
{
    private readonly WordBreak sut = new WordBreak();

    [Theory]
    [MemberData(nameof(CanBeBrokenTestData))]
    public void CanBeBroken_ShouldReturnWhetherWordCanBeBrokenIntoFragments(string word, List<string> fragments, bool expected)
    {
        var result = sut.CanBeBroken(word, fragments);
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> CanBeBrokenTestData()
    {
        yield return ["applepenapple", new List<string> { "apple", "pen" }, true];
        yield return ["catsandog", new List<string> { "cats","dog","sand","and","cat" }, false];
        yield return ["aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab", new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" }, false];
    }
}
