using LeetcodePractice.Implementation.Interview150.Shared;

namespace LeetcodePractice.Implementation.Interview150;
public class AddTwoNumbers
{
    public ListNode? Add(ListNode l1, ListNode l2)
    {
        var currentL1 = l1;
        var currentL2 = l2;
        var resultPreHead = new ListNode();
        var currentResult = resultPreHead;

        int carry = 0;
        while (currentL1 != null || currentL2 != null || carry > 0)
        {
            var l1Digit = currentL1?.val ?? 0;
            var l2Digit = currentL2?.val ?? 0;
            var resultDigit = (l1Digit + l2Digit + carry) % 10;
            carry = (l1Digit + l2Digit + carry) / 10;

            currentResult.next = new ListNode(resultDigit);
            currentResult = currentResult.next;
            currentL1 = currentL1?.next;
            currentL2 = currentL2?.next;
        }

        return resultPreHead.next;
    }
}
