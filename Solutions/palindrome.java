// Definition for singly-linked list:
// class ListNode<T> {
//   ListNode(T x) {
//     value = x;
//   }
//   T value;
//   ListNode<T> next;
// }
//
//

ListNode<Integer> left;
ListNode<Integer> prev;

boolean isListPalindrome(ListNode<Integer> list) {
    left = list;
    boolean result = compareLeftRight(list);
    
    return result;
}


public boolean compareLeftRight(ListNode right){

    if (right == null) return true;
    
    if (!compareLeftRight(right.next)) return false;
    
    prev = left;
    left = left.next;

    return ((prev.value).equals((right.value)));
}