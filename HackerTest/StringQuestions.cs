public class StringQuestions
{
    //Method to find duplicte characters in a string and return duplicated ones
    //Tested
    public static string FindDuplicateCharacters(string s)
    {
        string strReturned="";
        char[] chArr = s.ToCharArray();
        for(int i=0;i<chArr.Length;i++)
        {
            for(int j=0;j<chArr.Length;j++)
            {
                if(i!=j && chArr[i].ToString().ToLower()==chArr[j].ToString().ToLower())
                {
                    if(!strReturned.Contains(chArr[i].ToString().ToLower()))
                    {
                        strReturned=strReturned+chArr[i].ToString().ToLower();
                    }                    
                }
            }
        }
        return strReturned;
    }

    //Method that returns all characters that are unique in the string
    //Tested
    public static string GetAllUniqueCharactersInAString(string s)
    {
        string strReturned="";
        char[] chrArr=s.ToCharArray();
        bool isDuplicate=false;

        for(int i=0;i<chrArr.Length;i++)
        {
            isDuplicate=false;
            for(int j=0;j<chrArr.Length;j++)
            {
                if(i!=j && chrArr[i].ToString().ToLower()==chrArr[j].ToString().ToLower())
                {
                    isDuplicate=true;
                    break;
                }
            }
            if(!isDuplicate)
            {
                if(!strReturned.Contains(chrArr[i].ToString().ToLower()))
                {
                    strReturned=strReturned+chrArr[i].ToString().ToLower();
                }
            }
        }
        return strReturned;
    }

    //Method that reverses each word in a string
    //Tested
    public static string ReverseEachWordOfASentence(string s)
    {
        string strReturned="";
        string[] strWords = s.Split(' ');
        for(int i=0;i<strWords.Length;i++)
        {
            string temp = HackerClassArray.ReverseString(strWords[i]);
            strReturned=strReturned+temp;
            if(i<strWords.Length-1)
            {
                strReturned=strReturned+" ";
            }
        }
        return strReturned;
    }

    //Method that returns number of occurences of a word in a string
    //Tested
    public static int GetTheWordCountInAString(string strSentence, string strWord)
    {
        string[] strWords=strSentence.Split(' ');
        int counter=0;
        for(int i=0;i<strWords.Length;i++)
        {
            if(strWords[i].ToLower().Equals(strWord.ToLower()))
            {
                counter++;
            }
        }
        return counter;
    }

    //Method that checks a string is Palidro or not  a plaindorm is a string whose reversed version is same as the orignal version.
    //Tested
    public static string CheckPalindrom(string str)
    {
        string strReversed=  HackerClassArray.ReverseString(str);
        if(strReversed.ToLower().Equals(str.ToLower()))
        {
            return "Palindrom";
        }
        return "Not Palindrom";
    }

    //Finds charcters with MX occurence and display them
    //Tested
    public static string FindCharacterWithMaxOccurence(string str)
    {
            if(str.Length>0)
            {
            Dictionary<string,int> dicMaxOccurence = new Dictionary<string, int>();
            char[] chrArray = str.ToCharArray();
            
            int charCounter=0;
            for(int i=0;i<chrArray.Length;i++)//place each chracter in string with thier occurent in dictionary
            {
                charCounter=0;
                for(int j=0;j<chrArray.Length;j++)
                {
                    if(chrArray[i].ToString().ToLower().Equals(chrArray[j].ToString().ToLower()))
                    {
                        charCounter++;
                    }
                }
                if(!dicMaxOccurence.ContainsKey(chrArray[i].ToString().ToLower()))
                {
                    dicMaxOccurence.Add(chrArray[i].ToString().ToLower(),charCounter);
                }
            }
            List<int> occurences = new List<int>();
            foreach(string st in dicMaxOccurence.Keys)
            {
                occurences.Add(dicMaxOccurence[st]);
            }
            int[] arr=HackerClassArray.SortArray(occurences.ToArray(),true);//Sort Array in Ascending

            
            int maxOccured = arr[arr.Length-1];
            foreach(string st in dicMaxOccurence.Keys)
            {
                if(dicMaxOccurence[st]==maxOccured)
                {
                    System.Console.WriteLine(st);
                }
            }
            }
        return "";
    }

    //Method that prints all possible substrings of a given note: substring can't be same as the string itself
    //Tested
    public static void FindAllPossibleSubStrings(string st)
    {
        for (int i = 1; i < st.Length; i++) 
        {
            for (int start = 0; start <= st.Length - i; start++) 
            {
                string substr = st.Substring(start, i);
                Console.WriteLine(substr);
            }
        }
    }

    

    //Method that prints the first character of each word in capital letter
    //Tested
    public static void GetTheFirstCharacterOfEachWord(string s)
    {
        if(s.Length>0)
        {
            string[] strWords=s.Split(' ');
            for(int i=0;i<strWords.Length;i++)
            {
                System.Console.WriteLine(strWords[i][0].ToString().ToUpper());
            }
        }
        System.Console.WriteLine("String is empity");
    }

    //method that sorts charcters in string via ascending/descnding order
    //Tested
    public static string SortStringCharacters(string s, bool IsAscending)
    {
        if(s.Length>0)
        {
            string strReturned = "";
            char[] charArray=s.ToCharArray();
            if(IsAscending==true)
            {
                for(int i=0;i<charArray.Length;i++)
                {
                    for(int j=0;j<charArray.Length;j++)
                    {
                        if(i!=j && Convert.ToInt32(charArray[i])<Convert.ToInt32(charArray[j]))//Equavalent to charArray[i]<charArray[j]
                        {
                            char c =charArray[i];
                            charArray[i]=charArray[j];
                            charArray[j]=c;
                        }
                    }
                }
            }
            else//Descending
            {
               for(int i=0;i<charArray.Length;i++)
                {
                    for(int j=0;j<charArray.Length;j++)
                    {
                        if(i!=j && Convert.ToInt32(charArray[i])>Convert.ToInt32(charArray[j]))//Equavalent to charArray[i]<charArray[j]
                        {
                            char c =charArray[i];
                            charArray[i]=charArray[j];
                            charArray[j]=c;
                        }
                    }
                }                 
            }
            foreach(char c in charArray)
            {
                strReturned=strReturned+c;
            }
            return strReturned;
        }
        return "";
    }

    //Method to sort words in a string in Ascending/decending
    //Tested
    public static string SortWordsInString(string str, bool IsAsending)
    {
        string strReturned="";
        if(str.Length>0)
        {
            string[] strSplitted=str.Split(' ');   
            if(IsAsending)
            {                     
                for(int i=0;i<strSplitted.Length;i++)
                {
                    for(int j=0;j<strSplitted.Length;j++)
                    {
                        //the logic is to cpmare the first character of each word
                        char chi = strSplitted[i].ToCharArray()[0];
                        char chj=strSplitted[j].ToCharArray()[0];
                        if(i!=j && Convert.ToInt32(chi)<Convert.ToInt32(chj))
                        {
                            string strTemp = strSplitted[i];
                            strSplitted[i]=strSplitted[j];
                            strSplitted[j]=strTemp;
                        }
                    }
                }                
            }
            else//Descending
            {
                 for(int i=0;i<strSplitted.Length;i++)
                {
                    for(int j=0;j<strSplitted.Length;j++)
                    {
                        //the logic is to cpmare the first character of each word
                        char chi = strSplitted[i].ToCharArray()[0];
                        char chj=strSplitted[j].ToCharArray()[0];
                        if(i!=j && Convert.ToInt32(chi)>Convert.ToInt32(chj))
                        {
                            string strTemp = strSplitted[i];
                            strSplitted[i]=strSplitted[j];
                            strSplitted[j]=strTemp;
                        }
                    }
                }           
            }
            for(int k=0;k<strSplitted.Length;k++)
            {
                strReturned=strReturned+strSplitted[k];
                if(k<strSplitted.Length-1)
                {
                    strReturned=strReturned+" ";
                }
            }
        }
        return strReturned;
    }

    /*
    Given a string containing just the characters '(' and ')', 
    find the length of the longest valid (well-formed) parentheses substring.
    Tested
    */
    public static int LongestValidParentheses(string s) 
    {
        int n = s.Length; 
    
        // Create a stack and push -1 as  
        // initial index to it.  
        Stack<int> stk = new Stack<int>(); 
        stk.Push(-1); 
    
        // Initialize result  
        int result = 0; 
    
        // Traverse all characters of 
        // given string  
        for (int i = 0; i < n; i++) 
        { 
            // If opening bracket, push  
            // index of it  
            if (s[i] == '(') 
            { 
                stk.Push(i); 
            } 
    
            else // If closing bracket,  
                // i.e.,str[i] = ')' 
            { 
                // Pop the previous opening  
                // bracket's index  
                stk.Pop(); 
    
                // Check if this length formed  
                // with base of current valid  
                // substring is more than max  
                // so far  
                if (stk.Count > 0) 
                { 
                    result = Math.Max(result, i - stk.Peek()); 
                } 
    
                // If stack is empty. push current 
                // index as base for next valid  
                // substring (if any)  
                else
                { 
                    stk.Push(i); 
                } 
            } 
        } 
    
        return result;
    }

    /*Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

    '.' Matches any single character.​​​​
    '*' Matches zero or more of the preceding element.

    The matching should cover the entire input string (not partial). 
    Tested */

   public bool IsMatch(string s, string p) {
        int rows = s.Length;
        int columns = p.Length;
        /// Base conditions
        if (rows == 0 && columns == 0) {
            return true;
        }
        if (columns == 0) {
            return false;
        }
        // DP array
        bool[,] dp = new bool[rows + 1,columns + 1];
        // Empty string and empty pattern are a match
        dp[0,0] = true;
        // Deals with patterns with *
        for (int i = 2; i < columns + 1; i++) 
        {
            if (p[i - 1] == '*') 
            {
                dp[0,i] = dp[0,i - 2];
            }
        }
        // For remaining characters
        for (int i = 1; i < rows + 1; i++) 
        {
            for (int j = 1; j < columns + 1; j++) 
            {
                if (s[i - 1] == p[j - 1] || p[j - 1] == '.') 
                {
                    dp[i,j] = dp[i - 1,j - 1];
                } 
                else if (j > 1 && p[j - 1] == '*') 
                {
                    dp[i,j] = dp[i,j - 2];
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1]) {
                        dp[i,j] = dp[i,j] | dp[i - 1,j];
                    }
                }
            }
        }
        return dp[rows,columns];
        
    }

    // Returns true if character1 and character2
    // are matching left and right brackets */
    static Boolean isMatchingPair(char character1, char character2)
    {
        if (character1 == '(' && character2 == ')')
            return true;
        else if (character1 == '{' && character2 == '}')
            return true;
        else if (character1 == '[' && character2 == ']')
            return true;
        else
            return false;
    }

    /*
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    An input string is valid if:
    Open brackets must be closed by the same type of brackets.
    Open brackets must be closed in the correct order.

    */
    static Boolean areBracketsBalanced(char[] exp)
    {
        // Declare an empty character stack */
        Stack<char> st = new Stack<char>();
 
        // Traverse the given expression to
        //   check matching brackets
        for (int i = 0; i < exp.Length; i++)
        {
            // If the exp[i] is a starting
            // bracket then push it
            if (exp[i] == '{' || exp[i] == '(' || exp[i] == '[')
                st.Push(exp[i]);
 
            //  If exp[i] is an ending bracket
            //  then pop from stack and check if the
            //   popped bracket is a matching pair
            if (exp[i] == '}' || exp[i] == ')' || exp[i] == ']') 
            { 
                // If we see an ending bracket without
                //   a pair then return false
                if (st.Count == 0)
                {
                    return false;
                }
 
                // Pop the top element from stack, if
                // it is not a pair brackets of
                // character then there is a mismatch. This
                // happens for expressions like {(})
                else if (!isMatchingPair(st.Pop(),exp[i])) 
                {
                    return false;
                }
            }
        }
 
        // If there is something left in expression
        // then there is a starting bracket without
        // a closing bracket
 
        if (st.Count == 0)
            return true; // balanced
        else
        {
            // not balanced
            return false;
        }
    }

    /*
    You are given a string s and an array of strings words of the same length. Return all starting indices of substring(s) in s that is a concatenation of each word in words exactly once, in any order, and without any intervening characters.

    You can return the answer in any order.
    Tested 
    */
     public IList<int> FindSubstring(string s, string[] words) {
       List<int> res = new List<int>();
            var len = words[0].Length;
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word]++;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            for (int i = 0; i < len; i++)
            {
                var start = i;
                var count = 0;
                var dictword = new Dictionary<string, int>();
                for (int j = i; j + len <= s.Length; j += len)                 
                {                     
                    var cur = s.Substring(j, len);                     
                    if (!dict.ContainsKey(cur))                     
                    {                         
                        dictword.Clear();                         
                        count = 0;                         
                        start = j + len;                         
                        continue;                     
                    }                     
                    if (dictword.ContainsKey(cur))                     
                    {                         
                        dictword[cur]++;                     
                    }                     
                    else                     
                    {                         
                        dictword.Add(cur, 1);                     
                    }                     
                    if (dictword[cur] > dict[cur])
                    {
                        while (start < j)
                        {
                            var pre = s.Substring(start, len);
                            if (dictword.ContainsKey(pre))
                            {
                                dictword[pre]--;
                                if (dictword[pre] < dict[pre])
                                {
                                    count--;
                                }
                            }
                            start += len;
                            if (pre == cur) break;
                        }
                    }
                    else
                    {
                        count++;
                    }

                    if (count == words.Length)
                    {
                        res.Add(start);
                        
                        // remove the left one
                        var left = s.Substring(start, len);
                        if (dictword.ContainsKey(left))
                        {
                            dictword[left]--;
                        }
                        count--;
                        start += len;
                    }
                }

            }

            return res;
    }

    /*
    We can scramble a string s to get a string t using the following algorithm:

    If the length of the string is 1, stop.
    If the length of the string is > 1, do the following:
        Split the string into two non-empty substrings at a random index, i.e., if the string is s, divide it to x and y where s = x + y.
        Randomly decide to swap the two substrings or to keep them in the same order. i.e., after this step, s may become s = x + y or s = y + x.
        Apply step 1 recursively on each of the two substrings x and y.

    Given two strings s1 and s2 of the same length, return true if s2 is a scrambled string of s1, otherwise, return false.
    */
    static bool isScramble(string S1, string S2)
    {
    // Strings of non-equal length
        // cant' be scramble strings
        if (S1.Length != S2.Length) 
        {
            return false;
        }
           
        int n = S1.Length;
       
        // Empty strings are scramble strings
        if (n == 0) 
        {
            return true;
        }
           
        // Equal strings are scramble strings
        if (S1.Equals(S2))
        {
            return true;
        }
           
        // Converting string to 
        // character array
        char[] tempArray1 = S1.ToCharArray();
        char[] tempArray2 = S2.ToCharArray();
           
        // Checking condition for Anagram
        Array.Sort(tempArray1);
        Array.Sort(tempArray2);
           
        string copy_S1 = new string(tempArray1);
        string copy_S2 = new string(tempArray2);
           
        if (!copy_S1.Equals(copy_S2)) 
        {
            return false;
        }
               
        for(int i = 1; i < n; i++)
        {
               
            // Check if S2[0...i] is a scrambled
            // string of S1[0...i] and if S2[i+1...n]
            // is a scrambled string of S1[i+1...n]
            if (isScramble(S1.Substring(0, i), 
                           S2.Substring(0, i)) && 
                isScramble(S1.Substring(i, n - i),
                           S2.Substring(i, n - i)))
            {
                return true;
            }
       
            // Check if S2[0...i] is a scrambled
            // string of S1[n-i...n] and S2[i+1...n]
            // is a scramble string of S1[0...n-i-1]
            if (isScramble(S1.Substring(0, i),
                           S2.Substring(n - i, i)) && 
                isScramble(S1.Substring(i, n - i),
                           S2.Substring(0, n - i))) 
            {
                return true;
            }
        }
           
        // If none of the above
        // conditions are satisfied
        return false;
    }

        /*
        Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

        '?' Matches any single character.
        '*' Matches any sequence of characters (including the empty sequence).

        The matching should cover the entire input string (not partial).
        Tested 
        */
        public bool IsMatchPattern(string s, string p)
        {
            return IsMatchRecursion(s, 0, p, 0);
        }

        private bool IsMatchRecursion(string s, int sindex, string p, int pindex)
        {
            while (sindex >= s.Length && pindex < p.Length && p[pindex] == '*')             
            {                 
                pindex++;             
            }             
            if (sindex >= s.Length && pindex >= p.Length)
            {
                return true;
            }

            if (sindex >= s.Length || pindex >= p.Length)
            {
                return false;
            }
            if (p[pindex] == '*')
            {
                return IsMatchRecursion(s, sindex + 1, p, pindex) || IsMatchRecursion(s, sindex, p, pindex + 1);
            }

            if (p[pindex] == '?' || p[pindex] == s[sindex])
            {
                return IsMatchRecursion(s, sindex + 1, p, pindex + 1);
            }

            return false;
        }

static int shortestChainLen(string beginWord, string endWord, IList<string> wordList)
{
 
     if(beginWord == endWord)
       return 0;
    // If the target String is not
    // present in the dictionary
    if (!wordList.Contains(endWord))
        return 0;
 
    // To store the current chain length
    // and the length of the words
    int level = 0, wordlength = beginWord.Length;
 
    // Push the starting word into the queue
    List<String> Q = new List<String>();
    Q.Add(beginWord);
 
    // While the queue is non-empty
    while (Q.Count != 0)
    {
 
        // Increment the chain length
        ++level;
 
        // Current size of the queue
        int sizeofQ = Q.Count;
 
        // Since the queue is being updated while
        // it is being traversed so only the
        // elements which were already present
        // in the queue before the start of this
        // loop will be traversed for now
        for (int i = 0; i < sizeofQ; ++i)
        {
 
            // Remove the first word from the queue
            char []word = Q[0].ToCharArray();
            Q.RemoveAt(0);
 
            // For every character of the word
            for (int pos = 0; pos < wordlength; ++pos)
            {
 
                // Retain the original character
                // at the current position
                char orig_char = word[pos];
 
                // Replace the current character with
                // every possible lowercase alphabet
                for (char c = 'a'; c <= 'z'; ++c)
                {
                    word[pos] = c;
 
                    // If the new word is equal
                    // to the endWord word
                    if (String.Join("", word).Equals(endWord))
                        return level + 1;
 
                    // Remove the word from the set
                    // if it is found in it
                    if (!wordList.Contains(String.Join("", word)))
                        continue;
                    wordList.Remove(String.Join("", word));
 
                    // And push the newly generated word
                    // which will be a part of the chain
                    Q.Add(String.Join("", word));
                }
 
                // Restore the original character
                // at the current position
                word[pos] = orig_char;
            }
        }
    }
    return 0;
}

/*
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.


Example 1:

Input: n = 3
Output: ["((()))","(()())","(())()","()(())","()()()"]

Example 2:

Input: n = 1
Output: ["()"]

Tested 

*/
 public IList<string> GenerateParenthesis(int n) {
        IList<string> result=new List<string>();
       generatePartenthisis(result,"",0,0,n);
        return result;
    }
    
    
    void generatePartenthisis(IList<string> result, string s, int open, int close, int n)
    {
        if(open==n && close==n)
        {
            result.Add(s);
            return;
        }
        if(open<n)
        {
            generatePartenthisis(result,s+"(",open+1,close,n);
        }
        if(close<open)
        {
            generatePartenthisis(result,s+")",open,close+1,n);
        }
    }

    /* String to Integer atoi
        Implement the myAtoi(string s) function, which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).

    The algorithm for myAtoi(string s) is as follows:

        Read in and ignore any leading whitespace.
        Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
        Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
        Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
        If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
        Return the integer as the final result.

    Note:

        Only the space character ' ' is considered a whitespace character.
        Do not ignore any characters other than the leading whitespace or the rest of the string after the digits.

    

    Example 1:

    Input: s = "42"
    Output: 42
    Explanation: The underlined characters are what is read in, the caret is the current reader position.
    Step 1: "42" (no characters read because there is no leading whitespace)
            ^
    Step 2: "42" (no characters read because there is neither a '-' nor '+')
            ^
    Step 3: "42" ("42" is read in)
            ^
    The parsed integer is 42.
    Since 42 is in the range [-231, 231 - 1], the final result is 42.

    Example 2:

    Input: s = "   -42"
    Output: -42
    Explanation:
    Step 1: "   -42" (leading whitespace is read and ignored)
                ^
    Step 2: "   -42" ('-' is read, so the result should be negative)
                ^
    Step 3: "   -42" ("42" is read in)
                ^
    The parsed integer is -42.
    Since -42 is in the range [-231, 231 - 1], the final result is -42.

    Example 3:

    Input: s = "4193 with words"
    Output: 4193
    Explanation:
    Step 1: "4193 with words" (no characters read because there is no leading whitespace)
            ^
    Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
            ^
    Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
                ^
    The parsed integer is 4193.
    Since 4193 is in the range [-231, 231 - 1], the final result is 4193.

    Tested 
    */
     public int MyAtoi(string s) {
        if(String.IsNullOrWhiteSpace(s))
        {
            return 0;
        }
        if(string.ReferenceEquals(s,null)||s.Length<1)
        {
            return 0;
        }
        s=s.Trim();
        char flag='+';
        int i=0;
        if(s[0]=='-')
        {
            flag='-';
            i++;
        }
        else if(s[0]=='+')
        {
            i++;
        }
        double result=0;
        while(s.Length>i&&s[i]>='0' && s[i]<= '9')
        {
            result=result*10+(s[i]-'0');
            i++;
        }
        if(flag=='-')
        {
            result= -result;
        }
        if(result>int.MaxValue)
        {
            return int.MaxValue;
        }
        if(result<int.MinValue)
        {
            return int.MinValue;
        }
        return (int)result;      
        
    }

    /* Zig Zag Conversion
    The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

    P   A   H   N
    A P L S I I G
    Y   I   R

    And then read line by line: "PAHNAPLSIIGYIR"

    Write the code that will take a string and make this conversion given a number of rows:

    string convert(string s, int numRows);

    

    Example 1:

    Input: s = "PAYPALISHIRING", numRows = 3
    Output: "PAHNAPLSIIGYIR"

    Example 2:

    Input: s = "PAYPALISHIRING", numRows = 4
    Output: "PINALSIGYAHRPI"
    Explanation:
    P     I    N
    A   L S  I G
    Y A   H R
    P     I

    Example 3:

    Input: s = "A", numRows = 1
    Output: "A"

    Tested
    */
public virtual string convert(string s, int numRows)
{
		// Base conditions
		if (string.ReferenceEquals(s, null) || s.Length == 0 || numRows <= 0)
		{
			return "";
		}
		if (numRows == 1)
		{
			return s;
		}
		// Resultant string
		System.Text.StringBuilder result = new System.Text.StringBuilder();
		// Step size
		int step = 2 * numRows - 2;
		// Loop for each row
		for (int i = 0; i < numRows; i++)
		{
			// Loop for each character in the row
			for (int j = i; j < s.Length; j += step)
			{
				result.Append(s[j]);
				if (i != 0 && i != numRows - 1 && (j + step - 2 * i) < s.Length)
				{
					result.Append(s[j + step - 2 * i]);
				}
			}
		}
		return result.ToString();
    }

    /*
    Count and Say
        The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

            countAndSay(1) = "1"
            countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1), which is then converted into a different digit string.

        To determine how you "say" a digit string, split it into the minimal number of groups so that each group is a contiguous section all of the same character. Then for each group, say the number of characters, then say the character. To convert the saying into a digit string, replace the counts with a number and concatenate every saying.

        For example, the saying and conversion for digit string "3322251":

        Given a positive integer n, return the nth term of the count-and-say sequence.

        

        Example 1:

        Input: n = 1
        Output: "1"
        Explanation: This is the base case.

        Example 2:

        Input: n = 4
        Output: "1211"
        Explanation:
        countAndSay(1) = "1"
        countAndSay(2) = say "1" = one 1 = "11"
        countAndSay(3) = say "11" = two 1's = "21"
        countAndSay(4) = say "21" = one 2 + one 1 = "12" + "11" = "1211"

        Tested
    */
    public string CountAndSay(int n) {
        if(n == 1 || n == 0) 
            return "1";
         
        String previous = CountAndSay(n - 1);
         
        int count = 0;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        char[] preArray = previous.ToCharArray();
        char preChar = preArray[0];
        foreach(char c in preArray)
        {
            if(c == preChar)
            {
                count++;
            }
            else 
            {
                sb.Append(count.ToString() + preChar);
                count = 1;
                preChar = c;
            }
        }
        sb.Append(count.ToString() + preChar);
        return sb.ToString();
    }

    /*
    Multiply Strings
    Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

    Note: You must not use any built-in BigInteger library or convert the inputs to integer directly.
    
    Example 1:

    Input: num1 = "2", num2 = "3"
    Output: "6"

    Example 2:

    Input: num1 = "123", num2 = "456"
    Output: "56088"
    Tsted
    */
    public string Multiply(string num1, string num2) {
        if(num1.Equals("0")||num2.Equals("0"))
        {
            return "0";
        }
        char[] ch1=num1.ToCharArray();
        char[] ch2=num2.ToCharArray();
        int l1=num1.Length,l2=num2.Length;
        int[] res=new int[l1+l2];
        for(int i=l2-1;i>=0;i--)
        {
            for(int j=l1-1;j>=0;j--)
            {
                int product=(ch1[j]-'0')*(ch2[i]-'0');
                int current=product+res[i+j+1];
                res[i+j+1]=current%10;
                res[i+j]+=current/10;
            }
        }
        int index=0;
        while(index<res.Length && res[index]==0)
        {
            ++index;
        }
        string result="";
        for(;index<res.Length;index++)
        {
            result+=res[index].ToString();
        }
        return result;
    }

}