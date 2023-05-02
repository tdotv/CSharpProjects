﻿using System.Text;

namespace Strings
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("countVowels: \t\t" +    CountVowels("Hello World"));
            Console.WriteLine("reverseString: \t\t" +  ReverseString("Hello World"));
            Console.WriteLine("reverseWords: \t\t" +   ReverseWords("Hello World"));
            Console.WriteLine("isRotation: \t\t" +     IsRotation("Hello World", "rldHello Wo"));
            Console.WriteLine("isRotation: \t\t" +     IsRotation("Hello World", "Hello Wogfufg"));
            Console.WriteLine("removeDuplicates: \t" + RemoveDuplicates("Hello World"));
            Console.WriteLine("removeDuplicates: \t" + GetMaxOccurringChar("Hello World"));
            Console.WriteLine("capitalize: \t\t" +     Capitalize("hELLO       wORLD"));
            Console.WriteLine("isAnagram: \t\t" +      IsAnagram("Hello World", "Worlo Helld"));
            Console.WriteLine("isAnagram2: \t\t" +     IsAnagram2("Hello World", "Worlo Helld"));
            Console.WriteLine("isPalindrom: \t\t" +    IsPalindrome("Hello World dlroW olleH"));
            Console.WriteLine("isPalindrom2: \t\t" +   IsPalindrome2("Hello World dlroW olleH"));
        }

        public static int CountVowels(String str)
        {
            if (str == null) return 0;
            int count = 0;
            String vowels = "aeiou";
            foreach (var ch in str.ToLower().ToCharArray())
                if (vowels.IndexOf(ch) != -1) count++;
            return count;
        }
        
        public static String ReverseString(String str)
        {
            if (str == null) return "";
            StringBuilder reversed = new StringBuilder();
            foreach (var ch in str.ToCharArray()) reversed.Insert(0, ch);
            return reversed.ToString();
        }
        public static String ReverseWords(String sentence)
        {
            if (sentence == null) return "";
            String[] words = sentence.Trim().Split(" ");
            Array.Reverse(words);
            return String.Join(" ", words);
        }
        public static bool IsRotation(String str1, String str2)
        {
            if (str1 == null || str2 == null) return false;
            else if (str1.Length != str2.Length) return false;
            String newString = str1 + str1;
            if (newString.Contains(str2)) return true;
            return false;
        }

        public static String RemoveDuplicates(String str)
        {
            if (str == null) return "";
            StringBuilder output = new StringBuilder();
            HashSet<char> seen = new HashSet<char>();
            foreach (var ch in str.ToCharArray())
            {
                if (!seen.Contains(ch))
                {
                    seen.Add(ch);
                    output.Append(ch);
                }
            }
            return output.ToString();
        }

        public static char GetMaxOccurringChar(String str)
        {
            //		Map<Character, Integer> frequencies = new HashMap<>();	//hashtable
            //		for(var ch : str.toLowerCase().toCharArray()) {
            //			if(frequencies.containsKey(ch)) 
            //				frequencies.replace(ch, frequencies.get(ch) + 1);
            //			else frequencies.put(ch, 1);
            //		}
            //Ascii
            if (str.Length == 0 || str == null) throw new Exception();
            const int ASCII_SIZE = 256;
            int[] array = new int[ASCII_SIZE];
            foreach (var ch in str.ToLower().ToCharArray()) array[ch]++;
            char result = ' ';
            int max = 0;
            for (var i = 0; i < array.Length; ++i)
                if (array[i] > max)
                {
                    max = array[i];
                    result = (char)i;
                }
            return result;
        }

        public static String Capitalize(String sentence)
        {
            if (sentence == null || sentence.Trim().Length == 0) return "";
            String[] words = sentence.Split(" ");
            for (var i = 0; i < words.Length; i++) {
                if (words[i] == "") continue;
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
            }
            return String.Join(" ", words);
        }

        //O(nlogn)
        public static bool IsAnagram(String first, String second)
        {// O(nlogn)
         // ABCD - CBD
         //1 ['A', 'B', 'C', 'D'] - ['C', 'B', 'D','A']A =SORT=> ['A', 'B', 'C', 'D'] - ['A', 'B', 'C', 'D']
            if (first == null || second == null) return false;
            else if (second.Length != second.Length) return false;
            var array1 = first.ToLower().ToCharArray();
            var array2 = second.ToLower().ToCharArray();    // O(n)
            Array.Sort(array1);     // O(nlogn)
            Array.Sort(array2);
            return Array.Equals(array1, array2);
        }
        // O(n)
        public static bool IsAnagram2(String first, String second)
        {// O(n)
         // ABCD - CBD
         //1 ['A', 'B', 'C', 'D'] - ['C', 'B', 'D','A']A =SORT=> ['A', 'B', 'C', 'D'] - ['A', 'B', 'C', 'D']
         // not works without replaceAll(" ", "") !!
            if (first == null || second == null) return false;
            if (first.Length != second.Length) return false;
            const int ENGLISH_ALPHABET = 26; // 256 
            int[] array = new int[ENGLISH_ALPHABET];
            first = first.Replace(" ", "").ToLower();
            for (var i = 0; i < first.Length; i++) array[first[i] - 'a']++;
            second = second.Replace(" ", "").ToLower();
            for (var i = 0; i < second.Length; ++i)
            { // O(n)
                int index = second[i] - 'a';
                if (array[index] == 0) return false;
                array[index]--;
            }
            return true;
        }

        public static bool IsPalindrome(String word)
        {
            var reversed = word.ToCharArray();
            Array.Reverse(reversed);
            return (new String(reversed)).Equals(word);
        }

        public static bool IsPalindrome2(String word)
        {
            int left = 0;
            int right = word.Length - 1;
            while (left < right)
                if (word[left++] != word[right--]) return false;
            return true;
        }

    }
}