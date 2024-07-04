using LeetcodePractice.Implementation.Interview150;
using LeetcodePractice.Implementation.Interview150.Shared;

namespace LeetcodePractice.Tests.Interview150;
public class ReverseNodesInKGroupTests
{
    private readonly ReverseNodesInKGroup sut = new ReverseNodesInKGroup();

    [Theory]
    [MemberData(nameof(ReverseNodesInKGroupTestData))]
    public void ReverseNodesInKGroup_ShouldReverseNodesKAtATime(ListNode head, int k, ListNode expected)
    {
        var result = sut.ReverseKGroup(head, k);

        TestHelpers.LinkedListsShouldBeEquivalent(result, expected);
    }

    public static IEnumerable<object[]> ReverseNodesInKGroupTestData()
    {
        yield return [TestHelpers.GenerateLinkedList([1, 2, 3, 4, 5]), 2, TestHelpers.GenerateLinkedList([2, 1, 4, 3, 5])];
        yield return [TestHelpers.GenerateLinkedList([1, 2, 3, 4, 5]), 3, TestHelpers.GenerateLinkedList([3, 2, 1, 4, 5])];
        yield return [TestHelpers.GenerateLinkedList([1, 2, 3, 4, 5]), 5, TestHelpers.GenerateLinkedList([5, 4, 3, 2, 1])];
    }
}
