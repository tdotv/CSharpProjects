using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace CSharpTest
{
    public class Program
    {
        //-----------------------------------------------------ListNode-----------------------------------------------------
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

        //  2
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

        //  21
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2)    // Input: list1 = [1,2,4], list2 = [1,3,4]  Output: [1,1,2,3,4,4]
        {
            if (list1 == null && list2 == null) return list2;
            ListNode current = new(0);
            ListNode head = current;
            while (list1 != null && list2 != null)                              // Input: list1 = [], list2 = []            Output: []
            {
                if (list1.val < list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }
            if (list1 != null)
            {
                current.next = list1;
            }
            if (list2 != null)
            {
                current.next = list2;
            }
            return head.next;
        }

        //-----------------------------------------------------TreeNode-----------------------------------------------------
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //  124
        public static int MaxPathSum(TreeNode root) // Time: O(n)   Space: O(n)
        {
            int answer = int.MinValue;  //  ! [-3] !
            helper(root);               //  [-10,9,20,null,null,15,7]
            int helper(TreeNode root)
            {
                if (root == null) return 0;
                int maxLeftSum = Math.Max(helper(root.left), 0);
                int maxRightSum = Math.Max(helper(root.right), 0);
                answer = Math.Max(answer, maxLeftSum + maxRightSum + root.val);
                return Math.Max(maxLeftSum, maxRightSum) + root.val;
            }
            return answer;
        }

        //-----------------------------------------------------Math-----------------------------------------------------
        //  7
        public static int Reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                int tmp = x % 10;
                res = res * 10 + tmp;
                x = (x - tmp) / 10;

                if (res % 10 != tmp) // !exceed int range!  1534236469
                {
                    return 0;
                }
            }
            return res;
        }

        //  9
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

        //-----------------------------------------------------Arrays-----------------------------------------------------
        //  35
        public static int SearchInsert(int[] nums, int target)      //  Input: nums = [1,3,5,6], target = 2
        {                                                           //  Output: 1
            var low = 0;
            var high = nums.Length - 1;

            int n = nums.Length;
            if (n == 0)
                return 0;

            while (low <= high)
            {
                var mid = (low + high) / 2;
                var guess = nums[mid];
                if (target == guess)
                {
                    return mid;
                }
                if (guess > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (low <= high && nums[high] < target)                 // Test: target = 0 x_x
                return high + 1;
            return low;
        }

        //  14
        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0 || Array.IndexOf(strs, "") != -1)
                return "";
            string result = strs[0];
            int i = result.Length;
            foreach (string word in strs)
            {
                int j = 0;
                foreach (char c in word)
                {
                    if (j >= i || result[j] != c)
                        break;
                    j += 1;
                }
                i = Math.Min(i, j);
            }
            return result.Substring(0, i);
        }

        //  62  Dynamic programming
        public static int UniquePaths(int m, int n)
        {
            if (m == 0 && n == 0)
            {
                return 0;
            }
            int[][] arr = new int[m][];     //  two-dimensional array init
            for (int i = 0; i < m; i++)
            {
                arr[i] = new int[n];
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i == 0 && j == 0) || (i != 0 && j == 0) || (i == 0 && j != 0))
                    {
                        arr[i][j] = 1;
                    }
                    else
                    {
                        arr[i][j] = arr[i - 1][j] + arr[i][j - 1];
                    }
                }
            }
            return arr[m - 1][n - 1];
        }

        //  240 matrix with sorted columns and strings
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }
            int m = matrix.Length; int n = matrix[0].Length;
            int i = 0; int j = n - 1;
            while (i < m && j >= 0)
            {
                if (matrix[i][j] == target)
                {
                    return true;
                }
                if (matrix[i][j] > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }
            return false;
        }

        //-----------------------------------------------------String-----------------------------------------------------
        //  3
        public static int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> set = new Dictionary<char, int>();
            int maxSub = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!set.ContainsKey(c))
                {
                    set.Add(c, i);
                    maxSub = Math.Max(set.Count, maxSub);
                }
                else
                {
                    i = set[c];
                    set.Clear();
                }
            }
            return maxSub;
        }

        //-----------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {

        }
    }
}