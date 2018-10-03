// Definition for singly-linked list:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
bool isListPalindrome(ListNode<int> list)
{
    // To solve in O(n) time and O(1) space (the tricky bit), we'll
    // try the following approach: Split the list at the middle,
    // reverse the latter half. Compare the two sub-lists.

    if (list == null || list.next == null) return true; 
    ListNode<int> head = list;    
    ListNode<int> end = new ListNode<int>();
    ListNode<int> middle = FindMiddle(list);

    //reverse the 2nd half of the list in place
    ReverseInPlace(ref middle); 
    return CompareLists(list, middle);
}

bool CompareLists(ListNode<int> first, ListNode<int> second)
{
    // Compare elements of first and second up to the length of the shorter
    // Return false if any elements are different
    while (first != null && second != null)
    {
        if (first.value != second.value) return false;
        first = first.next;
        second = second.next;
    }
    return true;
}

void ReverseInPlace(ref ListNode<int> list)
{
    // Reverse a linked list in place, with head at list
    // Return new head pointing to reversed list
    ListNode<int> head = list;
    ListNode<int> next = list.next;
    ListNode<int> tmp = null;

    head.next = null;

    while (next != null)     
    {
        tmp = next.next;
        next.next = head;
        head = next;
        next = tmp;
    }

    list = head;
}

ListNode<int> FindMiddle(ListNode<int> list)
{
    ListNode<int> slow = list;
    ListNode<int> fast = list;   

    while (fast.next != null)
    {
        slow = slow.next;
        fast = fast.next;
        if (fast.next == null) return slow; 
        fast = fast.next;  
    }
    return slow;
}
