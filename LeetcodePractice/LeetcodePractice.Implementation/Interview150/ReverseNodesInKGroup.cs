namespace LeetcodePractice.Implementation.Interview150;
public class ReverseNodesInKGroup
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var preHead = new ListNode(0, head);
        var kGroupPreHead = preHead;

        var current = head;
        var stack = new Stack<ListNode>(k);
        while (current != null)
        {
            stack.Push(current);
            if (stack.Count == k)
            {
                var currentKGroup = kGroupPreHead;
                var next = current.next;
                while (stack.Count > 0)
                {
                    currentKGroup.next = stack.Pop();
                    currentKGroup = currentKGroup.next;
                }
                currentKGroup.next = next;
                kGroupPreHead = currentKGroup;
                current = kGroupPreHead;
            }
            current = current.next;
        }
        return preHead.next;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
