using System.Linq;

namespace CSharpTest
{
    public class Program
    {
        //  1
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
       
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)  //  Input: l1 = [2,4,3], l2 = [5,6,4]
        {
            ListNode dummyHead = new ListNode(0);                       // head of newly generated list
            ListNode curr = dummyHead;
            int sum = 0;                                                //  Output: [7,0,8]
            int carry = 0;                                              //  Explanation: 342 + 465 = 807.

            while (l1 != null || l2 != null || carry != 0)              //  carry != 0 for the last node
            {
                sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + carry;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                carry = sum / 10;

                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }

            return dummyHead.next;
        }

        //  2

        public static bool IsPalindrome(int x)
        {
            int r = 0, c = x;   // r = 0, c = x = 121
            while (c > 0)
            {
                r = r * 10 + c % 10;    //  r = 0 + 1 -> r = 12 -> r = 121
                c /= 10;                //  c = 12    -> c = 1  -> c = 0
            }
            return r == x;
        }

        static void Main(string[] args)
        {
            int x = 121;
            Console.WriteLine(IsPalindrome(x));
        }
    }
}