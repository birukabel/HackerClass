public class DataStructureRelated
{
    //Method that returns index of an element to be searched in an Array using BinarySearch
    //Time complexity=O(logn)
    //Tested
    public static int BinarySearch(int[] Arr, int startIndex,int lastIndex, int element)
    {     
        Arr=HackerClassArray.SortArray(Arr,true);   
        int index=(startIndex+lastIndex)/2;
        if(Arr[index]==element)
        {
            return index;
        }
        else if(element>Arr[index])//search to the right of index
        {
            startIndex=index;
            lastIndex=Arr.Length;
            return BinarySearch(Arr,lastIndex,startIndex,element);
        }
        else if(element<Arr[index])//Search to the left of index
        {
             startIndex=0;
             lastIndex=index;
             return BinarySearch(Arr,lastIndex,startIndex,element);
        }
        return -1;
    }

    //method to check if a string is Palindrom using Stack and Queue
    //Tested
    public static string PalindromCheckUsingStackNQueue(string s)
    {
        string[] strStack=PushElmenetToStack(s);
        string[] strQueue=PushElementToQueue(s);
        for(int stackIndex=strQueue.Length-1,queueIndex=0;stackIndex>=0&&queueIndex<strQueue.Length;queueIndex++,stackIndex--)
        {
            if(strStack[stackIndex]!=strQueue[queueIndex])
            {
                return "String "+ s +" is not palindrom.";
            }            
        }
        return "String "+ s +" is palindrom.";
    }

    //method to push elements to stack using Array
    public static string[] PushElmenetToStack(string s)
    {
        if(s.Length>0)
        {
             string[] str=new string[s.Length];
             for(int i=0;i<s.Length;i++)
             {
                 str[i]=Convert.ToString(s[i]);
             }
             return str;
        }  
        return null;     
    }

    //Method to push elements to queue using Array
    public static string[] PushElementToQueue(string s)
    {
        if(s.Length>0)
        {
             string[] str=new string[s.Length];
             for(int i=0;i<s.Length;i++)
             {
                 str[i]=Convert.ToString(s[i]);
             }
             return str;
        }  
        return null;
    } 

    /*Binary Tree Maximum Path Sum
    A path in a binary tree is a sequence of nodes where each pair of adjacent nodes in the sequence has an edge connecting them. A node can only appear in the sequence at most once. Note that the path does not need to pass through the root.
    The path sum of a path is the sum of the node's values in the path.
    Given the root of a binary tree, return the maximum path sum of any non-empty path.
    Tested */
    public int MaxPathSum(TreeNode root) 
    {       
        return findMaxSum(root);
    }
    int findMaxUtil(TreeNode node, Res res)
    {
 
        // Base Case
        if (node == null)
            return 0;
 
        // l and r store maximum path
        // sum going through left and
        // right child of root respectively
        int l = findMaxUtil(node.left, res);
        int r = findMaxUtil(node.right, res);
 
        // Max path for parent call of root.
        // This path must include
        // at-most one child of root
        int max_single = Math.Max(Math.Max(l, r) + node.val, node.val);
 
 
        // Max Top represents the sum
        // when the Node under
        // consideration is the root
        // of the maxsum path and no
        // ancestors of root are there
        // in max sum path
        int max_top = Math.Max(max_single, l + r + node.val);
 
        // Store the Maximum Result.
        res.val = Math.Max(res.val, max_top);
 
        return max_single;
    }   
 
    // Returns maximum path
    // sum in tree with given root
     int findMaxSum(TreeNode node)
    {
 
        // Initialize result
        // int res2 = int.MinValue;
        Res res = new Res();
        res.val = int.MinValue;
 
        // Compute and return result
        findMaxUtil(node, res);
        return res.val;
    }  

    //Method to perform Redo and Undo using Queue and Stack respectively
    //Tested
    public static void UndoRedo(string s)
    {
        if(s.Length>0)
        {
            System.Console.WriteLine("The following is Redo function");
            for(int i=0;i<s.Length;i++)//FIFO use Queue for Redo
            {
                Console.WriteLine(s[i]);
            }
             System.Console.WriteLine("The following is Undo function");
            for(int j=s.Length-1;j>=0;j--)//LIFO use stack for Undo
            {
                Console.WriteLine(s[j]);
            }
        }
        else
        {
            System.Console.WriteLine("Input string is empty!");
        }
    } 

    internal Stack<string> stack = new Stack <string> ();
	internal bool contains_tag = false;
	public virtual bool isValidTagName(string s, bool ending)
	{
		if (s.Length < 1 || s.Length > 9)
		{
			return false;
		}
		for (int i = 0; i < s.Length; i++)
		{
			if (!char.IsUpper(s[i]))
			{
				return false;
			}
		}
		if (ending)
		{
			if (stack.Count > 0 && stack.Peek().Equals(s))
			{
				stack.Pop();
			}
			else
			{
				return false;
			}
		}
		else
		{
			contains_tag = true;
			stack.Push(s);
		}
		return true;
	}
	public virtual bool isValidCdata(string s)
	{
		return s.IndexOf("[CDATA[", StringComparison.Ordinal) == 0;
	}

    /*
        Given a string representing a code snippet, implement a tag validator to parse the code and return whether it is valid.

    A code snippet is valid if all the following rules hold:

        The code must be wrapped in a valid closed tag. Otherwise, the code is invalid.
        A closed tag (not necessarily valid) has exactly the following format : <TAG_NAME>TAG_CONTENT</TAG_NAME>. Among them, <TAG_NAME> is the start tag, and </TAG_NAME> is the end tag. The TAG_NAME in start and end tags should be the same. A closed tag is valid if and only if the TAG_NAME and TAG_CONTENT are valid.
        A valid TAG_NAME only contain upper-case letters, and has length in range [1,9]. Otherwise, the TAG_NAME is invalid.
        A valid TAG_CONTENT may contain other valid closed tags, cdata and any characters (see note1) EXCEPT unmatched <, unmatched start and end tag, and unmatched or closed tags with invalid TAG_NAME. Otherwise, the TAG_CONTENT is invalid.
        A start tag is unmatched if no end tag exists with the same TAG_NAME, and vice versa. However, you also need to consider the issue of unbalanced when tags are nested.
        A < is unmatched if you cannot find a subsequent >. And when you find a < or </, all the subsequent characters until the next > should be parsed as TAG_NAME (not necessarily valid).
        The cdata has the following format : <![CDATA[CDATA_CONTENT]]>. The range of CDATA_CONTENT is defined as the characters between <![CDATA[ and the first subsequent ]]>.
        CDATA_CONTENT may contain any characters. The function of cdata is to forbid the validator to parse CDATA_CONTENT, so even it has some characters that can be parsed as tag (no matter valid or invalid), you should treat it as regular characters.

    

    Example 1:

    Input: code = "<DIV>This is the first line <![CDATA[<div>]]></DIV>"
    Output: true
    Explanation: 
    The code is wrapped in a closed tag : <DIV> and </DIV>. 
    The TAG_NAME is valid, the TAG_CONTENT consists of some characters and cdata. 
    Although CDATA_CONTENT has an unmatched start tag with invalid TAG_NAME, it should be considered as plain text, not parsed as a tag.
    So TAG_CONTENT is valid, and then the code is valid. Thus return true.

    Example 2:

    Input: code = "<DIV>>>  ![cdata[]] <![CDATA[<div>]>]]>]]>>]</DIV>"
    Output: true
    Explanation:
    We first separate the code into : start_tag|tag_content|end_tag.
    start_tag -> "<DIV>"
    end_tag -> "</DIV>"
    tag_content could also be separated into : text1|cdata|text2.
    text1 -> ">>  ![cdata[]] "
    cdata -> "<![CDATA[<div>]>]]>", where the CDATA_CONTENT is "<div>]>"
    text2 -> "]]>>]"
    The reas

    on why start_tag is NOT "<DIV>>>" is because of the rule 6.
    The reason why cdata is NOT "<![CDATA[<div>]>]]>]]>" is because of the rule 7.

    Example 3:

    Input: code = "<A>  <B> </A>   </B>"
    Output: false
    Explanation: Unbalanced. If "<A>" is closed, then "<B>" must be unmatched, and vice versa.

    

    Constraints:

        1 <= code.length <= 500
        code consists of English letters, digits, '<', '>', '/', '!', '[', ']', '.', and ' '.

    Tested
    */
	public virtual bool isValid(string code)
	{
		if (code[0] != '<' || code[code.Length - 1] != '>')
		{
			return false;
		}
		for (int i = 0; i < code.Length; i++)
		{
			bool ending = false;
			int closeindex;
			if (stack.Count == 0 && contains_tag)
			{
				return false;
			}
			if (code[i] == '<')
			{
				if (stack.Count > 0 && code[i + 1] == '!')
				{
					closeindex = code.IndexOf("]]>", i + 1, StringComparison.Ordinal);
					if (closeindex < 0 || !isValidCdata(code.Substring(i + 2, closeindex - (i + 2))))
					{
						return false;
					}
				}
				else
				{
					if (code[i + 1] == '/')
					{
						i++;
						ending = true;
					}
					closeindex = code.IndexOf('>', i + 1);
					if (closeindex < 0 || !isValidTagName(code.Substring(i + 1, closeindex - (i + 1)), ending))
					{
						return false;
					}
				}
				i = closeindex;
			}
		}
		return stack.Count == 0 && contains_tag;
	}

    /*
    Given the head of a linked list, rotate the list to the right by k places.
    Input: head = [1,2,3,4,5], k = 2
    Output: [4,5,1,2,3]

    Input: head = [0,1,2], k = 4
    Output: [2,0,1]

    Tested
    */
    public ListNode RotateRight(ListNode head, int k) {
       if(head==null || head.next==null)
       {
           return head;
       }
        ListNode tmp=head;
        int cnt=0;
        while(tmp!=null)
        {
            tmp=tmp.next;
            cnt++;
        }
        tmp=head;
        k%=cnt;
        if(k==0)
        {
            return head;
        }
        while(k-->0)
        {
            tmp=tmp.next;
        }
        ListNode tmpHead=head;
        while(tmp.next!=null)
        {
            tmp=tmp.next;
            head=head.next;
        }
        ListNode newHead=head.next;
        tmp.next=tmpHead;
        head.next=null;
        return newHead;
    }

    /*
    Given the head of a linked list, remove the nth node from the end of the list and return its head.
 
    Example 1:
    Input: head = [1,2,3,4,5], n = 2
    Output: [1,2,3,5]

    Example 2:

    Input: head = [1], n = 1
    Output: []

    Example 3:

    Input: head = [1,2], n = 1
    Output: [1]

    Tested
    */
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode slow=head;
        ListNode fast=head;
        for(int i=0;i<n;i++)
        {
            if(fast.next==null)
            {
                if(i==n-1)
                {
                    head=head.next;
                }
                return head;
            }
            fast=fast.next;
        }
        while(fast.next!=null)
        {
            slow=slow.next;
            fast=fast.next;
        }
        if(slow.next!=null)
        {
            slow.next=slow.next.next;
        }
        return head;
    }

    /*Given a linked list, swap every two adjacent nodes and return its head. 
    You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
    Example 1:
    
    Input: head = [1,2,3,4]
    Output: [2,1,4,3]

    Example 2:

    Input: head = []
    Output: []

    Example 3:

    Input: head = [1]
    Output: [1]

    Tested 
    */
    public ListNode SwapPairs(ListNode head) {
        ListNode dummy=new ListNode(0);
        dummy.next=head;
        ListNode current=dummy;
        while(current.next!=null && current.next.next!=null)
        {
            ListNode first=current.next;
            ListNode second=current.next.next;
            first.next=second.next;
            current.next=second;
            current.next.next=first;
            current=current.next.next;
        }
        return dummy.next;
    }

    /*
    Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

    Integers in each row are sorted from left to right.
    The first integer of each row is greater than the last integer of the previous row.
    
    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    Output: true

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    Output: false

    The below is a linier method
    Tested
    */
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix==null||matrix.Length==0||matrix[0].Length==0)
        {
            return false;
        }
        int i=matrix.Length-1;
        int j=matrix[0].Length-1;
        if(target>matrix[i][j]|| target<matrix[0][0])
        {
            return false;
        }
        int x=0;
        int y=j;
        while(x<=i&&y>=0)
        {
            if(target==matrix[x][y])
            {
                return true;
            }
            else if(target<matrix[x][y])
            {
                y--;
            }
            else
            {
                x++;
            }
        }
        return false;
    }

    /*
    Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:

    Integers in each row are sorted from left to right.
    The first integer of each row is greater than the last integer of the previous row.
    
    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
    Output: true

    Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
    Output: false

    The below is a binary method
    Tested
    */
    public bool searchMatrix(int[][] matrix, int target)
    {
		int k = matrix[0].Length - 1;

		// find the row that matrix[r][k] > target && matrix[r-1][k] < target;

		int t = 0;
		int b = matrix.Length - 1;
		if (target < matrix[0][0] || target > matrix[matrix.Length - 1][matrix[0].Length - 1])
		{
			return false;
		}
		while (t <= b)
		{
			int mid = t + (b - t) / 2;
			if (matrix[mid][k] == target)
			{
				return true;
			}
			if (matrix[mid][k] > target)
			{
				b = mid - 1;
			}
			else
			{
				t = mid + 1;
			}
		}

		int l = t;

		t = 0;
		b = matrix[0].Length - 1;
		while (t <= b)
		{
			int mid = t + (b - t) / 2;
			if (matrix[l][mid] == target)
			{
				return true;
			}
			if (matrix[l][mid] > target)
			{
				b = mid - 1;
			}
			else
			{
				t = mid + 1;
			}
		}

		return false;
    }

    /*
    Given an integer array nums of unique elements, return all possible subsets (the power set).

    The solution set must not contain duplicate subsets. Return the solution in any order.    

    Example 1:

    Input: nums = [1,2,3]
    Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

    Example 2:

    Input: nums = [0]
    Output: [[],[0]]

    Tested

    */
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> res=new List<IList<int>>();
        bool[] used=new bool[nums.Length];
        rec(res,new List<int>(),nums,0,used);
        return res;
    }
    
    void rec(IList<IList<int>> res,IList<int> temp, int[] nums, int idx, bool[] used)
    {
        res.Add(new List<int>(temp));
        if(temp.Count==nums.Length)
        {
            return;
        }
        for(int i=idx;i<nums.Length;i++)
        {
            if(used[i])
            {
                continue;
            }
            temp.Add(nums[i]);
            used[i]=true;
            rec(res,temp,nums,i,used);
            used[i]=false;
            temp.RemoveAt(temp.Count-1);
        }
    }

    /*Add Two Numbers
    You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

    You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    Example 1:

    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [7,0,8]
    Explanation: 342 + 465 = 807.

    Example 2:

    Input: l1 = [0], l2 = [0]
    Output: [0]

    Example 3:

    Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
    Output: [8,9,9,9,0,0,0,1]

    Tested
    */
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode fake=new ListNode(0);
        ListNode p=fake;
        ListNode p1=l1;
        ListNode p2=l2;
        
        int carry=0;
        
        
        while(p1!=null || p2!= null)
        {
            int sum=carry;
            if(p1!= null)
            {
                sum+=p1.val;
                p1=p1.next;
            }
            if(p2!=null)
            {
                sum+=p2.val;
                p2=p2.next;
            }
            if(sum>9)
            {
                carry=1;
                sum=sum-10;
            }
            else
            {
               carry=0; 
            }
            
            ListNode l=new ListNode(sum);
            p.next=l;
            p=p.next;
        }
        if(carry>0)
        {
            ListNode l=new ListNode(carry);
            p.next=l;
        }
        return fake.next;
    }

    /*Group Anagrams
    Given an array of strings strs, group the anagrams together. You can return the answer in any order.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

    Example 1:

    Input: strs = ["eat","tea","tan","ate","nat","bat"]
    Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

    Example 2:

    Input: strs = [""]
    Output: [[""]]

    Example 3:

    Input: strs = ["a"]
    Output: [["a"]]

    */
    public IList<IList<string>> GroupAnagrams(string[] strs) {
       IList<IList<string>> result=new List<IList<string>>();
        IDictionary<string, IList<string>> groups=new Dictionary<string,IList<string>>();
        for(int i=0;i<strs.Length;i++)
        {
            string str=strs[i];
            string key=buildAnagramsKey(str);
            if(!groups.ContainsKey(key))
            {
                groups[key]=new List<string>();
                
            }
            groups[key].Add(str);
        }
        foreach(KeyValuePair<string,IList<string>> pair in groups)
        {
            result.Add(pair.Value);
        }
        return result;
    }
    
    
    string buildAnagramsKey(string str)
    {
        int[] map=new int[26];
        foreach(char c in str.ToCharArray())
        {
            map[c-'a']+=1;
        }
        System.Text. StringBuilder build=new System.Text.StringBuilder();
        for(int i=0;i<26;i++)
        {
            build.Append(map[i]);
            build.Append((char)(i+'a'));
        }
        return build.ToString();
    }

    /*
    Letter Combinations of a Phone Number

    Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

    A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

    Example 1:

    Input: digits = "23"
    Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

    Example 2:

    Input: digits = ""
    Output: []

    Example 3:

    Input: digits = "2"
    Output: ["a","b","c"]

    Tested

    */
    public IList<string> LetterCombinations(string digits) {
       Dictionary<char,string> map=new Dictionary<char,string>();
        map['2']="abc";
        map['3']="def";
        map['4']="ghi";
        map['5']="jkl";
        map['6']="mno";
        map['7']="pqrs";
        map['8']="tuv";
        map['9']="wxyz";
        IList<string> l=new List<string>();
        if(string.ReferenceEquals(digits,null)|| digits.Length==0)
        {
            return l;
        }
        l.Add("");
        
        for(int i=0;i<digits.Length;i++)
        {
            List<string> temp=new List<string>();
            string option=map[digits[i]];
            for(int j=0;j<l.Count;j++)
            {
                for(int p=0;p<option.Length;p++)
                {
                    temp.Add((new System.Text.StringBuilder(l[j])).Append(option[p]).ToString());
                }
            }
            l.Clear();
            ((List<string>)l).AddRange(temp);
        }
        return l;
    }

}

/**
 * Definition for a binary tree node.*/
  public class TreeNode {
      public int val;
     public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
  }

  public class ListNode {
     public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

public class Res
{
    public int val;
}
 