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

ListNode left;


boolean isListPalindrome(ListNode<Integer> l) {
    left = l;
    boolean result = compareLeftRight(l);
    
    return result;
}


public boolean compareLeftRight(ListNode right){

    if (right == null){
        return true;
    }
    
    if (!compareLeftRight(right.next)) return false;
    
    if((left.value).equals((right.value)) left = left.next;

    return (left.value).equals((right.value);

    // boolean y = ((left.value).equals((right.value)));

    // left = left.next;

    //return y;
}