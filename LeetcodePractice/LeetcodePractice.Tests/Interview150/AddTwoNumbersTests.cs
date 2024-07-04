using LeetcodePractice.Implementation.Interview150;
using LeetcodePractice.Implementation.Interview150.Shared;

namespace LeetcodePractice.Tests.Interview150;
public class AddTwoNumbersTests
{
    private readonly AddTwoNumbers sut = new AddTwoNumbers();

    [Theory]
    [MemberData(nameof(AddTestData))]
    public void Add_ShoulAddTwoNumbers(ListNode l1, ListNode l2, ListNode expected)
    {
        var result = sut.Add(l1, l2);

        TestHelpers.LinkedListsShouldBeEquivalent(expected, result);
    }

    public static IEnumerable<object[]> AddTestData()
    {
        yield return [TestHelpers.GenerateLinkedList([2, 4, 3]), TestHelpers.GenerateLinkedList([5, 6, 4]), TestHelpers.GenerateLinkedList([7, 0, 8])];
        yield return [TestHelpers.GenerateLinkedList([0]), TestHelpers.GenerateLinkedList([0]), TestHelpers.GenerateLinkedList([0])];
        yield return [TestHelpers.GenerateLinkedList([9, 9, 9, 9, 9, 9, 9]), TestHelpers.GenerateLinkedList([9, 9, 9, 9]), TestHelpers.GenerateLinkedList([8, 9, 9, 9, 0, 0, 0, 1])];
    }
}
