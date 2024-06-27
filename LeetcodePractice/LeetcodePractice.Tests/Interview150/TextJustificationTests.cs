using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;

namespace LeetcodePractice.Tests.Interview150;
public class TextJustificationTests
{
    private readonly TextJustification sut = new TextJustification();

    [Theory]
    [MemberData(nameof(TextJustificationTestData))]
    public void Justify_ShouldCorrectlyJustifyText(List<string> words, int maxWidth, List<string> expected)
    {
        var result = sut.Justify(words, maxWidth);
        result.Should().BeEquivalentTo(expected);
    }

    public static IEnumerable<object[]> TextJustificationTestData()
    {
        yield return [new List<string> { "This", "is", "an", "example", "of", "text", "justification." }, 16, new List<string> { 
            "This    is    an", 
            "example  of text", 
            "justification.  " }];
        yield return [new List<string> { "What", "must", "be", "acknowledgment", "shall", "be" }, 16, new List<string> { 
            "What   must   be", 
            "acknowledgment  ", 
            "shall be        " }];
        yield return [new List<string> { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 20, new List<string> { 
            "Science  is  what we",
            "understand      well",
            "enough to explain to",
            "a  computer.  Art is",
            "everything  else  we",
            "do                  " }];
    }
}
