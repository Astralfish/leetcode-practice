using FluentAssertions;
using LeetcodePractice.Implementation.Interview150;
using static LeetcodePractice.Implementation.Interview150.ReverseNodesInKGroup;

namespace LeetcodePractice.Tests.Interview150;
public class ReverseNodesInKGroupTests
{
    private readonly ReverseNodesInKGroup sut = new ReverseNodesInKGroup();

    [Theory]
    [MemberData(nameof(ReverseNodesInKGroupTestData))]
    public void ReverseNodesInKGroup_ShouldReverseNodesKAtATime(ListNode head, int k, ListNode expected)
    {
        var result = sut.ReverseKGroup(head, k);

        var currentResultNode = result;
        var currentExpectedNode = expected;

        while (currentExpectedNode != null)
        {
            currentResultNode.Should().NotBeNull();
            currentResultNode!.val.Should().Be(currentExpectedNode.val);

            currentResultNode = currentResultNode.next;
            currentExpectedNode = currentExpectedNode.next;
        }
        currentResultNode.Should().BeNull();
    }

    public static IEnumerable<object[]> ReverseNodesInKGroupTestData()
    {
        yield return [ArrayToLinkedList([1, 2, 3, 4, 5]), 2, ArrayToLinkedList([2, 1, 4, 3, 5])];
        yield return [ArrayToLinkedList([1, 2, 3, 4, 5]), 3, ArrayToLinkedList([3, 2, 1, 4, 5])];
        yield return [ArrayToLinkedList([1, 2, 3, 4, 5]), 5, ArrayToLinkedList([5, 4, 3, 2, 1])];
    }

    private static ListNode ArrayToLinkedList(int[] array)
    {
        ListNode preHead = new ListNode();
        ListNode current = preHead;
        foreach (int i in array)
        {
            current.next = new ListNode(i);
            current = current.next;
        }
        return preHead.next!;
    }
}
