using System;
using System.Linq;
using System.Reflection.Emit;
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

        //  1302
        public static int DeepestLeavesSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxDepth = 0;
            int sum = 0;
            SumDeepestLeaves(root, 0, ref maxDepth, ref sum);
            return sum;
        }
        private static void SumDeepestLeaves(TreeNode root, int depth, ref int maxDepth, ref int sum)
        {
            if (root == null)
            {
                return;
            }
            else if (maxDepth < depth)
            {
                maxDepth = depth;
                sum = root.val;
            }
            else if (depth == maxDepth)
            {
                sum += root.val;
            }

            SumDeepestLeaves(root.left, depth + 1, ref maxDepth, ref sum);
            SumDeepestLeaves(root.right, depth + 1, ref maxDepth, ref sum);
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

        // ***

        // 26
        public static int RemoveDuplicates(int[] nums)  // [0,0,0,1,1,1,2,2] -> k=3
        {
            if (nums.Length == 0)   // [0,1,1] -> k=2
                return 0;

            int y = 0; // Pointer to the last non-duplicate element

            for (int x = 0; x < nums.Length; x++)
            {
                System.Console.WriteLine("Nums x = " + nums[x] + "| X = " + x);
                System.Console.WriteLine("Nums y = " + nums[y] + "| Y = " + y);
                if (nums[x] != nums[y])
                {
                    y++;
                    nums[y] = nums[x];
                }
            }

            return y + 1; // The length of the new array
        }

        public static int RemoveDuplicatesHash(int[] nums)
        {
            HashSet<int> secondary = new HashSet<int>();
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
                if (secondary.Add(nums[i]))
                    nums[counter++] = nums[i];
            return counter;
        }

        // 1
        public static int[] TwoSum(int[] nums, int target)     // [2,7,11,15], target = 9 -> [0,1]
        {
            int[] sum = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                System.Console.WriteLine("Start of [i]" + i);
                for (int j = 0; j < nums.Length; j++)
                {
                    System.Console.WriteLine("Start of [j]" + j);
                    if (nums[i] + nums[j] == target && i != j)
                    {
                        sum[0] = i;
                        sum[1] = j;
                        return sum;
                    }
                }
            }
            throw new ArgumentException("No two sum solution");
        }

        // 27
        public static int RemoveElement(int[] nums, int val)    // nums = [3,2,2,3], val = 3 | 2, nums = [2,2,_,_]
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[count] = nums[i];
                    count++;
                }
            }
            return count;
        }

        // 11
        public static int MaxArea(int[] height) // { 1, 8, 6, 2, 5, 4, 8, 3, 7 } -> 49  NOT WORKING
        {
            int maxWater = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > height[i + 1])
                {
                    for (int j = height.Length - 1; j > 0; j--)
                    {
                        if (height[j] > height[j - 1])
                        {
                            if (height[i] > height[j])
                            {
                                height[i] = height[j];
                            }
                            else
                            {
                                height[j] = height[i];
                            }
                            System.Console.WriteLine("i on calc = " + i);
                            System.Console.WriteLine("j on calc = " + j);
                            maxWater = height[i] * (j-i);
                            return maxWater;
                        }
                    }
                }
                else
                {
                    i = 0;
                }
            }
            return maxWater;
        }

        public static int MaxArea2(int[] height) // { 1, 8, 6, 2, 5, 4, 8, 3, 7 } -> 49
        {
            int maxArea = 0;
            
            for (int left = 0, right = height.Length - 1; left < right;)
            {
                var n = right - left;

                if (height[left] > height[right])
                {
                    maxArea = Math.Max(maxArea, height[right] * n);
                    right--;
                }
                else
                {
                    maxArea = Math.Max(maxArea, height[left] * n);
                    left++;
                }
            }

            return maxArea;
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

        //  28
        public static int StrStr(string haystack, string needle)    //  Explanation: "sad" occurs at index 0 and 6.
        {
            if (haystack.Contains(needle))                          // haystack = "sadbutsad"   needle = "sad"
            {
                var index = haystack.IndexOf(needle);
                return index;
            }
            else return -1;
        }

        //  Knuth Morris Pratt search algorithm
        public static void KMPSearch(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            // create lps[] that will hold the longest
            // prefix suffix values for pattern
            int[] lps = new int[M];
            int j = 0; // index for pat[]

            // Preprocess the pattern (calculate lps[] array)
            computeLPSArray(pat, M, lps);

            int i = 0; // index for txt[]
            while (i < N)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {
                    Console.Write("Found pattern " + "at index " + (i - j) + '\n');
                    j = lps[j - 1];
                }

                // mismatch after j matches
                else if (i < N && pat[j] != txt[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, they will match anyway
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }
        }

        public static void computeLPSArray(string pat, int M, int[] lps)
        {
            // length of the previous longest prefix suffix
            int len = 0;
            int i = 1;
            lps[0] = 0; // lps[0] is always 0

            // the loop calculates lps[i] for i = 1 to M-1
            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    // This is tricky. Consider the example.
                    // AAACAAAA and i = 7. The idea is similar to search step.
                    if (len != 0)
                    {
                        len = lps[len - 1];
                        // Also, note that we do not increment i here
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }

        //  20
        private static readonly Dictionary<char, char> _pairs = new()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };
        public bool IsValid(string s)
        {
            // If input is empty string then return true
            if (s.Length == 0) { return true; }

            Stack<char> brackets = new Stack<char>();

            // Loop through each character
            foreach (char i in s)
            {
                // If it is an opening bracket, push it to the stack
                if (_pairs.ContainsKey(i))
                {
                    brackets.Push(i);
                }
                // If it is an closing bracket, pop it
                else if (_pairs.Values.Contains(i))
                {
                    if (brackets.Count == 0) return false;

                    var openingBracket = brackets.Pop();
                    // If it isn't pair of the last opening bracket return false
                    if (_pairs[openingBracket] != i)
                    {
                        return false;
                    }
                }
            }
            // The stack should be empty in case all brackets are closed
            return brackets.Count == 0;
        }

        //-----------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 2 };
            System.Console.WriteLine(MaxArea2(nums));
        }
    }
}