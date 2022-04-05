public class HackerClassArray
{
    public bool IsValid(string s)
    {
        string strAllowed="{}[]";
        if(s.Length<=104 && s.Length>=1)
        {
            for(int i=0;i<s.Length;i++)
            {
                if(s[i]!='{' || s[i]!='}' || s[i]!=']' || s[i]!='[')
                {
                    return false;
                }
                else
                {
                    int index=0;
                    if(s[i]=='{')
                        {
                            if(i<s.Length-1)
                            {
                                
                            }
                        }
                }
            }
        }
        return false;
    }

    /*
    You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).

    Find two lines that together with the x-axis form a container, such that the container contains the most water.

    Return the maximum amount of water a container can store.

    Notice that you may not slant the container.

    Tested
    */
     public int MaxArea(int[] height) 
    {
        // Maximum area will be stored in this variable
        int maximumArea = 0;
        // Left and right pointers
        int left = 0;
        int right = height.Length - 1;
        // Loop until left and right meet
        while (left < right) {
            // Shorter pole/vertical line
            int shorterLine = Math.Min(height[left], height[right]);
            // Update maximum area if required
            maximumArea = Math.Max(maximumArea, shorterLine * (right - left));
            // If there is a longer vertical line present
            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }
        return maximumArea;
    }

     public static int flippingMatrix(List<List<int>> matrix)
    {
        //matrix.Clear();
        //matrix.Add(new List<int>(){112, 42, 83, 119});
        //matrix.Add(new List<int>(){56, 125, 56, 49});
        //matrix.Add(new List<int>(){15, 78, 101, 43});
        //matrix.Add(new List<int>(){62, 98, 114, 108});
        int sum=0;
        if(matrix.Count%2!=0 || matrix.Count==0)
        {
            return -1;
        }
        else
        {
             int x=matrix.Count/2;
             int y=matrix[0].Count/2;//array to sum up its elements

            //setp1: Reverse matrix.Count-2 column
            int columnIndexToReverse = y;
            List<int> columntoReverse = new List<int>();
            for(int i=0;i<matrix.Count;i++)//Rows
            {
                columntoReverse.Add(matrix[i][y]);
                //System.Console.WriteLine(matrix[i][y]);
            }
            columntoReverse.Reverse();

            for(int j=0;j<matrix.Count;j++)//reversed array is place in matrix
            {
                matrix[j][y]=columntoReverse[j];
            }
            //step2 : Reverse row zero
            columntoReverse.Clear();

            for(int k=0;k<matrix[0].Count;k++)
            {
                columntoReverse.Add(matrix[0][k]);
                //System.Console.WriteLine(matrix[0][k]);
            } 
            columntoReverse.Reverse();
            for(int i=0;i<matrix[0].Count;i++)//reversed array is place in matrix
            {
                matrix[0][i]=columntoReverse[i];
            }

            for(int row=0;row<x;row++)
            {
                for(int col=0;col<y;col++)
                {
                    sum=sum+matrix[row][col];
                }
            }
        }
        //System.Console.WriteLine(sum);
        return sum;
    }
public static int birthday(List<int> s, int d, int m)
    {
        if((d<1 || d>31) ||(m<1 || m>12))
        {
            return -1;
        }
        int counter=0;
        int sum=0;
        List<int> returnValue = new List<int>();
        bool firstTime=false;
        for(int i=0;i<s.Count;i++)
        {
            int index=0;
            sum=0;
            counter=0;
            firstTime=true;
            while(counter<m && sum<d)
            {
                if(i<(s.Count-1) && index==0)
                {
                    index=i+1;
                }
                if(firstTime)
                {
                    sum=sum+s[i]+s[index];
                    counter=counter+2;
                }
                else
                {                    
                    sum=sum+s[index];
                    counter=counter+1;
                }
                firstTime=false;
               
                if(sum==d)
                {
                    returnValue.Add(1);
                } 
                index++;
            }                     
        }
        return returnValue.Count();
    }

    //Function that reverses array elements
    //Tested
    public static int[] ReverseArray(int[] arr)
    {
        int index=0;
        int swapCounter=0;
        for(int i=(arr.Length-1);i>=0 && index<arr.Length && swapCounter<arr.Length-1;i--)
        {
            if(i!=index)
            {
                HackerClass.Swap(ref arr[i],ref arr[index]);
                swapCounter+=2;
                index++;
            }            
        }

        for(int j=0;j<arr.Length;j++)
        {
            System.Console.WriteLine(arr[j]);
        }

        return arr;
    }

    //Method to reverse string array
    //Tested
    public static string ReverseString(string s)
    {
        int index=0;
        char[] ch=s.ToCharArray();
        
         int swapCounter=0; 
       
        for(int i=(ch.Length-1);i>=0 && index<ch.Length && swapCounter<ch.Length-1;i--)
        {
            if(i!=index)
            {
                char temp=ch[i];
                ch[i]=ch[index];
                ch[index]=temp;
                swapCounter+=2;
                index++;
            }            
        }   
        string str="";
        foreach(char c in ch)
        {
            str=str+c;
        }     
        
        return str;        
    }

    //Method to sort array in Ascending/Descending based on user's choice.
    //tested
    public static int[] SortArray(int[] Arr, bool IsAsending)
    {
        if(IsAsending)
        {
            for(int i=0;i<Arr.Length;i++)
            {
                for(int j=0;j<Arr.Length;j++)
                {
                    if(Arr[j]>Arr[i] && i!=j)
                    {
                        HackerClass.Swap(ref Arr[i],ref Arr[j]);
                    }
                }
            }
        }
        else//Descending
        {
             for(int i=0;i<Arr.Length;i++)
            {
                for(int j=0;j<Arr.Length;j++)
                {
                    if(Arr[j]<Arr[i] && i!=j)
                    {
                        HackerClass.Swap(ref Arr[i],ref Arr[j]);
                    }
                }
            }     
        }
        foreach(int i in Arr)
        {
            System.Console.WriteLine(i);
        }
        return Arr;
    }

    //Method to rotate array with number of positions given to the right/left
    //Tested
    public static int[] RotateArray(int[] Arr, bool IsRightToLeft,int positions)
    {
        int temp=0;
        if(Arr.Length>1)
        {
            if(IsRightToLeft)//Rotate right to left, i.e., counter-clockwise
            {
                int i=0;
                int index=Arr.Length-1;
                while(i<positions)//perform shifting elements to the right followed by placing the last element at the head of the array
                {
                    temp=Arr[Arr.Length-1];
                    index=Arr.Length-1;
                    for(int j=Arr.Length-1;j>=0;j--)//Perform shift to the left
                    {
                        if(j>0)
                        {
                            index--;
                            Arr[j]=Arr[index];
                        }
                    }
                    i++;
                    Arr[0]=temp;
                }
            }
            else//Rotate left to right, i.e., clockwise
            {
                int i=0;
                int index=0;
                while(i<positions)//perform shifting elements to the left followed by placing the first element at the tail of the array
                {
                    temp=Arr[0];
                    index=0;
                    for(int j=0;j<Arr.Length;j++)//Perform shift to the left
                    {
                        if(j<Arr.Length-1)
                        {
                            index++;
                            Arr[j]=Arr[index];
                        }
                    }
                    i++;
                    Arr[Arr.Length-1]=temp;
                }
            }
        }
        return Arr;
    }

    /*
    You are given an array prices where prices[i] is the price of a given stock on the ith day.

    Find the maximum profit you can achieve. You may complete at most two transactions.

    Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).
    */
    public int MaxProfit(int[] prices) 
    {
        if(prices == null || prices.Length < 2) 
            return 0;
        
        int minLR = prices[0];
        int maxRL = prices[prices.Length - 1];
        int[] dpLR = new int[prices.Length];
        int[] dpRL = new int[prices.Length];
        int max = 0;
        
        for(int i = 1; i < prices.Length; i++)
        {
            if(prices[i] < minLR) minLR = prices[i];
            dpLR[i] = Math.Max(dpLR[i - 1], prices[i] - minLR);
        }
        
        for(int i = prices.Length - 2; i > -1; i--)
        {
            if(prices[i] > maxRL) maxRL = prices[i];
            dpRL[i] = Math.Max(dpRL[i + 1], maxRL - prices[i]);
        }
        
        for(int i = 0; i < prices.Length; i++)
        {
            max = Math.Max(max, dpLR[i] + dpRL[i]);
        }        
        return max;
    }

    /*
    Write a program to solve a Sudoku puzzle by filling the empty cells.

    A sudoku solution must satisfy all of the following rules:

        Each of the digits 1-9 must occur exactly once in each row.
        Each of the digits 1-9 must occur exactly once in each column.
        Each of the digits 1-9 must occur exactly once in each of the 9 3x3 sub-boxes of the grid.

    The '.' character indicates empty cells.
    Tested
    */
     public void SolveSudoku(char[][] board) {
        backtrack(board);
    }
    
    public bool checkValidGrid(char[][] board, char num, int row, int col)
    {   
        // There are 3 conditions needed to be checked
        // In order to gaurantee the validity of sudoku game
        for(int i = 0; i < 9; i++)
        {
            // Checking each individual row for 9 columns
            if(board[row][i] == num)
                return false;
            
            // Checking each individual column for 9 rows
            if(board[i][col] == num)
                return false;
            
            // Checking the repetitive values in 3 * 3 grid
            if(board[3 * (row/3) + i/3][3 * (col/3) + i%3] == num)
                return false;
        }
        return true;
    }
    
   
    
    public bool backtrack(char[][] board)
    {
        // To check whether 3 x 3 grid 
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[0].Length; j++)
            {   
                // Determining what numbers fit into "." character
                if(board[i][j] == '.')
                {
                    for(char num = '1'; num <= '9' ; num++)
                    {
                        if(checkValidGrid(board, num, i, j))
                        {
                            board[i][j] = num;
                            if(backtrack(board))
                            {
                                return true;
                            }
                            else
                            {
                                board[i][j] = '.';
                            }
                        }
                    }
                    return false;
                }
            }
        }
        return true;
    }

    /*
    Given n non-negative integers representing an 
    elevation map where the width of each bar is 1, compute how much water it can trap after raining.
    Tested
    */
    public int Trap(int[] height) {
        int n = height.Length;
        
        // base case
        if (n <= 2) {
            return 0;
        }
 
        int water = 0;
 
        // `left[i]` stores the maximum height of a height to the left
        // of the current height
        int[] left = new int[n-1];
        left[0] = 0;
 
        // process height from left to right
        for (int i = 1; i < n - 1; i++) {
            left[i] = Math.Max(left[i - 1], height[i - 1]);
        }
 
       
 
        // `right` stores the maximum height of a height to the right
        // of the current height
        int right = 0;
 
        // process height from right to left
        for (int i = n - 2; i >= 1; i--)
        {
            right = Math.Max(right, height[i + 1]);
 
            // check if it is possible to store water in the current bar
            if (Math.Min(left[i], right) > height[i]) {
                water += Math.Min(left[i], right) - height[i];
            }
        }
 
        return water;
    }

    /*
    The set [1, 2, 3, ..., n] contains a total of n! unique permutations.

    By listing and labeling all of the permutations in order, we get the following sequence for n = 3:

        "123"
        "132"
        "213"
        "231"
        "312"
        "321"

    Given n and k, return the kth permutation sequence.
    Tested
    */
    public string GetPermutation(int n, int k) {
        if (n <= 0) return string.Empty;

        var dp = new int[n];
        FillDP(dp);

        var res = new System.Text.StringBuilder();
        var candi = Enumerable.Range(1, n).ToList();
        for (int i = 1; i <= n; i++)
        {
            var index = (k - 1)/dp[n - i];
            k -= index * dp[n - i];
            res.Append(candi[index]);
            candi.RemoveAt(index);
        }

        return res.ToString();
    }
    
    private void FillDP(int[] dp)
    {
        dp[0] = 1;
        for (int i = 1; i < dp.Length; i++)
        {
            dp[i] = i*dp[i - 1];
        }
    }

    /*
    Search in Rotated Sorted Array Medium

There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.

 

Example 1:

Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:

Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1

Example 3:

Input: nums = [1], target = 0
Output: -1
Tested
    */
    private static int search(int[] nums, int target) {
        int start = 0;
        int end = nums.Length - 1;

        while(start <= end) {
            int mid = (start + end)/2;

            if(target == nums[mid]) {
                return mid;
            }

            if(nums[start] <= nums[mid]) { // left array is sorted
                if(target >= nums[start] && target < nums[mid]) { // target lies between start and mid index
                    end = mid-1;
                } else {
                    start = mid+1;
                }
            } else { // right array is sorted
                if(target > nums[mid] && target <= nums[end]) { // target lies between mid and end index
                    start = mid+1;
                } else {
                    end = mid-1;
                }
            }
        }

        return -1;
    }

    /*Permutaion I
    Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

    Example 1:

    Input: nums = [1,2,3]
    Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

    Example 2:

    Input: nums = [0,1]
    Output: [[0,1],[1,0]]

    Example 3:

    Input: nums = [1]
    Output: [[1]]

    Tested

    */
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> ans=new List<IList<int>>();
        IList<int> ds = new List<int>();
        bool[] freq=new bool[nums.Length];
        fun(nums,ds,ans,freq);
        return ans;
    }

    /*
    Median of Two Sorted Arrays

    Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

    The overall run time complexity should be O(log (m+n)).    

    Example 1:

    Input: nums1 = [1,3], nums2 = [2]
    Output: 2.00000
    Explanation: merged array = [1,2,3] and median is 2.

    Example 2:

    Input: nums1 = [1,2], nums2 = [3,4]
    Output: 2.50000
    Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

    Tested

    */
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if(nums1.Length>nums2.Length)
        {
            return FindMedianSortedArrays(nums2,nums1);
        }
        int m=nums1.Length;
        int n=nums2.Length;
        int start=0;
        int end=m;
        while(start<=end)
        {
            int partitionNums1=(start+end)/2;
            int partitionNums2=(m+n+1)/2-partitionNums1;
            int maxLeftNums1=partitionNums1==0?int.MinValue:nums1[partitionNums1-1];
            int minRightNums1=partitionNums1==m?int.MaxValue:nums1[partitionNums1];
           int maxLeftNums2=partitionNums2==0?int.MinValue:nums2[partitionNums2-1];
            int minRightNums2=partitionNums2==n?int.MaxValue:nums2[partitionNums2];
            if(maxLeftNums1<=minRightNums2 && maxLeftNums2<=minRightNums1)
            {
                if((m+n)%2==0)
                {
                    return (Math.Max(maxLeftNums1,maxLeftNums2)+Math.Min(minRightNums1,minRightNums2))/2.0;
                }
                else
                {
                    return Math.Max(maxLeftNums1,maxLeftNums2);
                }
            }
            else if(maxLeftNums1>minRightNums2)
            {
                end=partitionNums1-1;
            }
            else
            {
                start=partitionNums1+1;
            }
        }
        
        throw new System.ArgumentException();
    }
    
    void fun(int[] nums, IList<int> ds,IList<IList<int>> ans, bool[] freq)
    {
        if(ds.Count==nums.Length)
        {
            ans.Add(new List<int>(ds));
            return;
        }
        for(int i=0;i<nums.Length;i++)
        {
            if(!freq[i])
            {
                freq[i]=true;
                ds.Add(nums[i]);
                fun(nums,ds,ans,freq);
                ds.RemoveAt(ds.Count-1);
                freq[i]=false;
            }
        }
    }


    public IList<IList<int>> PermuteUnique(int[] nums) {
       IList<IList<int>> result=new List<IList<int>>();
        if(nums==null||nums.Length<=0)
        {
            return result;
        }
        Array.Sort(nums);
        List<int> res=new List<int>();
        bool[] used=new bool[nums.Length];
        for(int i=0;i<used.Length;i++)
        {
            used[i]=false;
        }
        dfs(result,res,nums,used,nums.Length);
            return result;
    }
    
    /* Permutaion II
    Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.

    Example 1:

    Input: nums = [1,1,2]
    Output:
    [[1,1,2],
    [1,2,1],
    [2,1,1]]

    Example 2:

    Input: nums = [1,2,3]
    Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

    Tested 
    */
    void dfs(IList<IList<int>> result, List<int> res, int[] num,bool[] used,int n)
    {
        if(n==0)
        {
            List<int> cur=new List<int>();
            for(int i=0;i<res.Count;i++)
            {
                cur.Add(res[i]);
            }
            result.Add(cur);
            return;
        }
        for(int i=0;i<used.Length;i++)
        {
            if(used[i]==true || (i!=0 && num[i]==num[i-1]&& used[i-1]==true))
            {
                continue;
            }
           
                used[i]=true;
                res.Add(num[i]);
                dfs(result,res,num,used,n-1);
                res.RemoveAt(res.Count-1);
                used[i]=false;
           
        }
    }

    /*
    Find the Duplicate Number
    

    Given an array of integers nums containing n + 1 integers where each integer is in the range [1, n] inclusive.

    There is only one repeated number in nums, return this repeated number.

    You must solve the problem without modifying the array nums and uses only constant extra space.
    

    Example 1:

    Input: nums = [1,3,4,2,2]
    Output: 2

    Example 2:

    Input: nums = [3,1,3,4,2]
    Output: 3

    Tested
    */
    public int FindDuplicate(int[] nums) {
        if(nums==null|| nums.Length<2)
        {
            return 0;
        }
        int i=1,j=nums.Length-1;
        while(i<j)
        {
            int mid=(i+j)/2,count=0;
            foreach(int num in nums)
            {
                if(num<=mid)
                {
                    count++;
                }
            }
            if(count<=mid)
            {
                i=mid+1;
            }
            else
            {
                j=mid;
            }
        }
        return i;
    }

    /*
    Jump Game

    You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

    Return true if you can reach the last index, or false otherwise.
  

    Example 1:

    Input: nums = [2,3,1,1,4]
    Output: true
    Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.

    Example 2:

    Input: nums = [3,2,1,0,4]
    Output: false
    Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

    */
    public bool CanJump(int[] nums) {
        if(nums.Length<=1)
        {
            return true;
        }
        int max=nums[0];
        for(int i=0;i<nums.Length;i++)
        {
            if(max<=i && nums[i]==0)
            {
                return false;
            }
            if(i+nums[i]>max)
            {
                max=i+nums[i];
            }
            if(max>=nums.Length-1)
            {
                return true;
            }
        }
        return false;
    }

    private static bool overlap(int[] a, int[] b)
	{
		return (a[0] <= b[0] && b[0] <= a[1]) || (b[0] <= a[0] && a[0] <= b[1]);
	}

    /*
    Insert Interval

    You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

    Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

    Return intervals after the insertion.    

    Example 1:

    Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
    Output: [[1,5],[6,9]]

    Example 2:

    Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
    Output: [[1,2],[3,10],[12,16]]
    Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

    Tested

    */
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        
        int i;
		List<int[]> newIntervals = new List<int[]>();
		for (i = 0;i < intervals.Length;i++)
		{
			if (overlap(intervals[i], newInterval))
			{
				break;
			}
			else
			{
				newIntervals.Add(new int[]{intervals[i][0], intervals[i][1]});
			}
		}
		if (i < intervals.Length)
		{
			intervals[i][0] = Math.Min(intervals[i][0], newInterval[0]);
			intervals[i][1] = Math.Max(intervals[i][1], newInterval[1]);
			newIntervals.Add(new int[]{intervals[i][0], intervals[i][1]});
			int j = i;
			i++;
			for (;i < intervals.Length;i++)
			{
				if (overlap(intervals[j], intervals[i]))
				{
					int a = Math.Min(intervals[j][0], intervals[i][0]);
					int b = Math.Max(intervals[j][1], intervals[i][1]);
					newIntervals[j] = new int[]{a, b};
				}
				else
				{
					newIntervals.Add(new int[]{intervals[i][0], intervals[i][1]});
				}
			}
			int[][] to_return = new int[newIntervals.Count][];
			for (i = 0;i < to_return.Length;i++)
			{
                to_return[i]=new int[2];
				to_return[i][0] = newIntervals[i][0];
				to_return[i][1] = newIntervals[i][1];
			}
			return to_return;
		}
		for (i = 0;i < intervals.Length;i++)
		{
			if (newIntervals[i][0] > newInterval[0])
			{
				break;
			}
		}

		newIntervals.Insert(i, new int[]{newInterval[0], newInterval[1]});

		int[][] to_return2 =new int[newIntervals.Count][];
			for (i = 0;i < to_return2.Length;i++)
			{
                to_return2[i]=new int[2];
				to_return2[i][0] = newIntervals[i][0];
				to_return2[i][1] = newIntervals[i][1];
			}
		return to_return2;

    }

    /*
    3Sum
    Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

    Notice that the solution set must not contain duplicate triplets.

    

    Example 1:

    Input: nums = [-1,0,1,2,-1,-4]
    Output: [[-1,-1,2],[-1,0,1]]

    Example 2:

    Input: nums = []
    Output: []

    Example 3:

    Input: nums = [0]
    Output: []

    Tested
    */
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        int n=nums.Length;
        IList<IList<int>> triplets=new List<IList<int>>();
        for(int i=0;i<n;i++)
        {
            if(i>0 && nums[i] == nums[i-1])
            {
                continue;
            }
            int j=i+1;
            int k=n-1;
            while(j<k)
            {
                if(nums[i]+nums[j]+nums[k]==0)
                {
                    triplets.Add(new List<int> {nums[i],nums[j],nums[k]});
                    j++;
                    while(j<k && nums[j]==nums[j-1])
                    {
                        j++;
                    }
                }
                else if(nums[i]+nums[j]+nums[k]<0)
                {
                    j++;
                }
                else
                {
                   k--; 
                }
            }
        }
        return triplets;
    }
}