using FluentAssertions;
using FluentAssertions.Execution;
using LeetcodePractice.Implementation.Interview150.Shared;

namespace LeetcodePractice.Tests;
public static class TestHelpers
{
    public static ListNode GenerateLinkedList(IEnumerable<int> elements)
    {
        ListNode preHead = new ListNode();
        ListNode current = preHead;
        foreach (int element in elements)
        {
            current.next = new ListNode(element);
            current = current.next;
        }
        return preHead.next!;
    }

    public static void LinkedListsShouldBeEquivalent(ListNode? a, ListNode? b)
    {
        var currentA = a;
        var currentB = b;

        using (new AssertionScope())
        {
            while (currentB != null)
            {
                currentA.Should().NotBeNull();
                currentA!.val.Should().Be(currentB.val);

                currentA = currentA.next;
                currentB = currentB.next;
            }
            currentA.Should().BeNull();
        }
    }
}
