 public class HackerClass
 {
     //first test with Git that was staged
     public static string twoArrays2(int k, List<int> A, List<int> B)
     {
         int counter=0;
            int numPermut = Factorial(A.Count)/Factorial(A.Count-A.Count);
            int[] arr=A.ToArray();
            int[] arr2 = B.ToArray();
            List<List<int>> visitedPermutations = new List<List<int>>();
            for(int i=0;i<numPermut;i++)
            {      
                counter=0;         
                for(int j=0;j<arr.Length;j++)//perform permutations
                {
                    int index=0;
                    if(j<(A.Count-1))
                    {
                        index=j+1;
                    }                   
                    Swap(ref arr[j],ref arr[index]); 
                    
                    for(int l=0;l<arr.Length;l++)
                    {
                        if(arr[l]+arr2[l]>=k)
                        {
                            counter++;
                        }
                    }
                    if(counter>=arr.Length)
                    {
                        return "YES";
                    }
                }               
            } 

            for(int i=0;i<numPermut;i++)
            {      
                counter=0;         
                for(int j=0;j<arr2.Length;j++)//perform permutations
                {
                    int index=0;
                    if(j<(arr2.Length-1))
                    {
                        index=j+1;
                    }                   
                    Swap(ref arr2[j],ref arr2[index]); 
                    
                    for(int l=0;l<arr2.Length;l++)
                    {
                        if(arr2[l]+arr[l]>=k)
                        {
                            counter++;
                        }
                    }
                    if(counter>=arr2.Length)
                    {
                        return "YES";
                    }
                }               
            } 

        return "NO";
     }
 public static string twoArrays(int k, List<int> A, List<int> B)
    {
        int counter=0;
        if(A.Count!=B.Count || A.Count==0)
        {
            return "NO";
        }
        List<List<int>> permutedArray = PrintAllPermutaions(A.ToArray());
        foreach(List<int> item in permutedArray)
        {
            counter=0;
            for(int i=0;i<item.Count;i++)
            {
                if(item[i]+B[i]>=k)
                {
                    counter++;
                }
                if(counter>=A.Count)
                {
                    return "YES";
                }
            }
        }
        
        counter=0;
        permutedArray = PrintAllPermutaions(B.ToArray());
         foreach(List<int> item in permutedArray)
        {
            counter=0;
            for(int i=0;i<item.Count;i++)
            {
                if(item[i]+A[i]>=k)
                {
                    counter++;
                }
                if(counter>=A.Count)
                {
                    return "YES";
                }
            }
        }
        return "NO";
    }

    public static List<List<int>> PrintAllPermutaions(int[] arr)
    {        
        if(arr.Length>0)
        {
            for(int k=0;k<arr.Length;k++)//loop to check duplicate values
            {
                for(int l=0;l<arr.Length && l!=k;l++)
                {
                    if(arr[l]==arr[k])
                    {
                        System.Console.WriteLine("Array has duplicate items!");
                        return new List<List<int>>();
                    }
                }
            }
            //formula to find all possible permutations
            int numPermut = Factorial(arr.Length)/Factorial(arr.Length-arr.Length);
            Dictionary<List<int>,bool> dicVisited = new Dictionary<List<int>, bool>();
            List<List<int>> visitedPermutations = new List<List<int>>();
            for(int i=0;i<numPermut;i++)
            {               
                for(int k=0;k<arr.Length;k++)//perform permutations
                {
                    int index=0;
                    if(k<(arr.Length-1))
                    {
                        index=k+1;
                    }                   
                    Swap(ref arr[k],ref arr[index]); 

                    if(visitedPermutations.Count<numPermut)
                    {
                        if(!visitedPermutations.Contains(arr.ToList()))
                        {
                            visitedPermutations.Add(arr.ToList());
                        }
                    }
                }               
            }           

            foreach(List<int> itemArray in visitedPermutations)
            {
                for(int k=0;k<itemArray.Count;k++)
                {
                    if(k==(itemArray.Count-1))
                    {
                       System.Console.Write(itemArray[k]); 
                    }
                    else
                    {
                      System.Console.Write(itemArray[k]+ ",");  
                    }                    
                }
                System.Console.WriteLine();
            }

            return visitedPermutations;
        }
        return new List<List<int>>();
    }

    public static void Swap(ref int a,ref int b)
    {
        int temp=a;
        a=b;
        b=temp;
    }

    public static void Swap(char  a,char b)
    {
        char temp=a;
        a=b;
        b=temp;
    }

    //Method to calclulate Factorial of a number using loop
    public static int Factorial(int n)
    {
        if(n<0)
        {
            return -1;
        }
        int returnedValue=1;
        for(int i=n;i>1;i--)
        {
            returnedValue=returnedValue*i;
        }
        return returnedValue;
    } 

    //Method to calculate factorial of a number using recursion
    //Tested
    public static int FactorialRecurssive(int n)
    {   
        if(n>=1)
        {  
            return n*FactorialRecurssive(--n);
        }
        if(n==0)
        {            
            return 1;
        }
        return -1;
    }

    /*
    A virus is spreading rapidly, and your task is to quarantine the infected area by installing walls.

    The world is modeled as an m x n binary grid isInfected, where isInfected[i][j] == 0 represents uninfected cells, and isInfected[i][j] == 1 represents cells contaminated with the virus. A wall (and only one wall) can be installed between any two 4-directionally adjacent cells, on the shared boundary.

    Every night, the virus spreads to all neighboring cells in all four directions unless blocked by a wall. Resources are limited. Each day, you can install walls around only one region (i.e., the affected area (continuous block of infected cells) that threatens the most uninfected cells the following night). There will never be a tie.

    Return the number of walls used to quarantine all the infected regions. If the world will become fully infected, return the number of walls used.

    Tested with some test cases but faield on hidden test cases
    */
    public static int ContainVirus(int[][] isInfected)
    {
        int sum=0;
        for(int i=0;i<isInfected.Length;i++)
        {
            int counter=0;
            for(int j=0;j<isInfected[i].Length;j++)
            {
                int xIndex=0;
                int yIndex=0;
                //There are 4 combinations of index [x-1,y][x+1,y][x,y-1][x,y+1]
                //Combination 1 [x-1,y]
                xIndex=i-1;
                yIndex=j;
                if(xIndex>=0)
                {
                    if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)//If the neigbouring cell is not infected increment it by one
                    {
                        counter++;
                    }  
                    //Combination 2 [x+1,y]  
                    xIndex=i+1;
                    yIndex=j;
                    if(xIndex<isInfected.Length)
                    {
                        if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                        {
                            counter++;
                        } 
                        //Combination 3 [x,y-1]
                        xIndex=i;
                        yIndex=j-1;
                        if(yIndex>=0)
                        {
                            if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                            {
                                counter++;
                            }
                            //Combination 4 [x,y+1]
                            xIndex=i;
                            yIndex=j+1;
                            if(yIndex<isInfected[i].Length)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                            }
                        }
                        else
                        {
                            //Combination 4 [x,y+1]
                            xIndex=i;
                            yIndex=j+1;
                            if(yIndex<isInfected[i].Length)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                            }
                        }
                    }  
                    else
                    {
                        //Combination 3 [x,y-1]
                        xIndex=i;
                        yIndex=j-1;
                        if(yIndex>=0)
                        {
                            if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                            {
                                counter++;
                            }
                            //Combination 4 [x,y+1]
                            xIndex=i;
                            yIndex=j+1;
                            if(yIndex<isInfected[i].Length)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                            }
                        }
                        //Combination 4 [x,y+1]
                        xIndex=i;
                        yIndex=j+1;
                        if(yIndex<isInfected[i].Length)
                        {
                            if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                            {
                                counter++;
                            }
                        }
                    }                              
                }
                else//There is no element to the left
                {
                    //Combination 2 [x+1,y]
                    xIndex=i+1;
                    yIndex=j;
                    if(xIndex<isInfected.Length)
                    {
                        if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                        {
                            counter++;
                        }                       
                            //Combination 3 [x,y-1]
                            xIndex=i;
                            yIndex=j-1;
                            if(yIndex>=0)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                                //Combination 4 [x,y+1]
                                xIndex=i;
                                yIndex=j+1;
                                if(yIndex<isInfected[i].Length)
                                {
                                    if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                    {
                                        counter++;
                                    }
                                }
                            }
                            //Combination 4 [x,y+1]
                            xIndex=i;
                            yIndex=j+1;
                            if(yIndex<isInfected[i].Length)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                            } 
                    }
                    else
                    {
                        //Combination 3 [x,y-1]
                        xIndex=i;
                        yIndex=j-1;
                        if(yIndex>=0)
                        {
                            if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                            {
                                counter++;
                            }
                            //Combination 4 [x,y+1]
                            xIndex=i;
                            yIndex=j+1;
                            if(yIndex<isInfected[i].Length)
                            {
                                if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                                {
                                    counter++;
                                }
                            }
                        }
                        //Combination 4 [x,y+1]
                        xIndex=i;
                        yIndex=j+1;
                        if(yIndex<isInfected[i].Length)
                        {
                            if(isInfected[xIndex][yIndex]==0 && isInfected[i][j]==1)
                            {
                                counter++;
                            }
                        }
                    }
                }               
            }
            sum+=counter;
        }

        return sum;
    }

    /*
    Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given an integer, convert it to a roman numeral.

 

Example 1:

Input: num = 3
Output: "III"
Explanation: 3 is represented as 3 ones.

Example 2:

Input: num = 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.

Example 3:

Input: num = 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.


Constraints:

    1 <= num <= 3999

Tested

*/
    public string IntToRoman(int num) {
        string[] romans = new string[] {"I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM",           "M"};
		int[] value = new int[] {1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000};
		int seqSize = romans.Length;
		int idx = seqSize - 1;
		string ans = "";
		while (num > 0)
		{
			while (value[idx] <= num)
			{
				ans += romans[idx];
				num -= value[idx];
			}
			idx--;
		}
		return ans;

    }

/*
Roman to Int 
Tested
*/
public int romanToInt(String s) {
    // Map to store romans numerals
		IDictionary<char, int> romanMap = new Dictionary<char, int>();
		// Fill the map
		romanMap['I'] = 1;
		romanMap['V'] = 5;
		romanMap['X'] = 10;
		romanMap['L'] = 50;
		romanMap['C'] = 100;
		romanMap['D'] = 500;
		romanMap['M'] = 1000;
		// Length of the given string
		int n = s.Length;
		// Variable to store result
		int num = romanMap[s[n - 1]];
		// Loop for each character from right to left
		for (int i = n - 2; i >= 0; i--)
		{
			// Check if the character at right of current character is
			// bigger or smaller
			if (romanMap[s[i]] >= romanMap[s[i + 1]])
			{
				num += romanMap[s[i]];
			}
			else
			{
				num -= romanMap[s[i]];
			}
		}
		return num;
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> results = new List<IList<int>>();
        if(candidates ==null || candidates.Length==0)
        {
            return results;
        }
        Array.Sort(candidates);
        IList<int> combination = new List<int>();
        toFindCombinationsToTarget(candidates,results,combination,0,target);
        return results;
    }
    
    /*
    Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.
 

Example 1:

Input: candidates = [10,1,2,7,6,1,5], target = 8
Output: 
[
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]

Example 2:

Input: candidates = [2,5,2,1,2], target = 5
Output: 
[
[1,2,2],
[5]
] 

Constraints:

    1 <= candidates.length <= 100
    1 <= candidates[i] <= 50
    1 <= target <= 30

    Tested

    */
    public void toFindCombinationsToTarget(int[] candidates, IList<IList<int>> results, IList<int> combination, int startIndex, int target)
    {
        if(target==0)
        {
            results.Add(new List<int>(combination));
            return;
        }
        for(int i=startIndex;i<candidates.Length;i++)
        {
            if(i!=startIndex&& candidates[i]==candidates[i-1])
            {
                continue;
            }
            if(candidates[i]>target)
            {
                break;
            }
            combination.Add(candidates[i]);
            toFindCombinationsToTarget(candidates,results, combination,i+1,target-candidates[i]);
            combination.RemoveAt(combination.Count-1);
        }
    }

    /*
    Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

    Each row must contain the digits 1-9 without repetition.
    Each column must contain the digits 1-9 without repetition.
    Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

    Note:

    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.

    Input: board = 
[["5","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: true

Example 2:

Input: board = 
[["8","3",".",".","7",".",".",".","."]
,["6",".",".","1","9","5",".",".","."]
,[".","9","8",".",".",".",".","6","."]
,["8",".",".",".","6",".",".",".","3"]
,["4",".",".","8",".","3",".",".","1"]
,["7",".",".",".","2",".",".",".","6"]
,[".","6",".",".",".",".","2","8","."]
,[".",".",".","4","1","9",".",".","5"]
,[".",".",".",".","8",".",".","7","9"]]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.

Tested
    */
    public bool IsValidSudoku(char[][] board) {
        for(int i=0;i<board[0].Length;i++)
        {
            bool[] checkRow = new bool[9];
            bool[] checkCol= new bool[9];
            for(int j=0;j<board.Length;j++)
            {
                if(board[i][j]!='.')
                {
                    if(checkRow[board[i][j]-'1'])
                    {
                    return false;
                    }
                    else
                {
                    checkRow[board[i][j]-'1']=true;
                }
                }
                if(board[j][i]!='.')
                {
                    if(checkCol[board[j][i]-'1'])
                    {
                        return false;
                    }
                    else
                    {
                        checkCol[board[j][i]-'1']=true;
                    }
                }
                
            }
        }
        for(int i=0;i<board[0].Length;i+=3)
        {
            for(int j=0;j<board.Length;j+=3)
            {
                bool[] check3x3=new bool[9];
                for(int k=i;k<i+3;k++)
                {
                    for(int l=j;l<j+3;l++)
                    {
                        if(board[k][l]=='.')
                        {
                            continue;
                        }
                        if(check3x3[board[k][l]-'1'])
                        {
                            return false;
                        }
                        else
                        {
                            check3x3[board[k][l]-'1']=true;
                        }
                    }
                }
            }
        }
        return true;
    }

    /*
    3Sum Closest
    Medium

    Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.

    Return the sum of the three integers.

    You may assume that each input would have exactly one solution.

    

    Example 1:

    Input: nums = [-1,2,1,-4], target = 1
    Output: 2
    Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).

    Example 2:

    Input: nums = [0,0,0], target = 1
    Output: 0

    Tested
    */
    public int ThreeSumClosest(int[] nums, int target) {
        int min=int.MaxValue;
        int result=0;
        Array.Sort(nums);
        for(int i=0;i<nums.Length;i++)
        {
            int j=i+1;
            int k=nums.Length-1;
            while(j<k)
            {
                int sum=nums[i]+nums[j]+nums[k];
                int diff=Math.Abs(sum-target);
                if(diff==0)
                {
                    return sum;
                }
                if(diff<min)
                {
                    min=diff;
                    result=sum;
                }
                if(sum<=target)
                {
                    j++;
                }
                else
                {
                    k--;
                }
            }
        }
        return result;
    }

    /*
    Next Permutation
    A permutation of an array of integers is an arrangement of its members into a sequence or linear order.

        For example, for arr = [1,2,3], the following are considered permutations of arr: [1,2,3], [1,3,2], [3,1,2], [2,3,1].

    The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, if all the permutations of the array are sorted in one container according to their lexicographical order, then the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).

        For example, the next permutation of arr = [1,2,3] is [1,3,2].
        Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
        While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.

    Given an array of integers nums, find the next permutation of nums.

    The replacement must be in place and use only constant extra memory.

    

    Example 1:

    Input: nums = [1,2,3]
    Output: [1,3,2]

    Example 2:

    Input: nums = [3,2,1]
    Output: [1,2,3]

    Example 3:

    Input: nums = [1,1,5]
    Output: [1,5,1]

    Tested

    */
    public void NextPermutation(int[] nums) 
    {
        int mark = -1;
	for (int i = nums.Length - 1; i > 0; i--)
	{
		if (nums[i] > nums[i - 1])
		{
			mark = i - 1;
			break;
		}
	}

	if (mark == -1)
	{
		reverse(nums, 0, nums.Length - 1);
		return;
	}

	int idx = nums.Length - 1;
	for (int i = nums.Length - 1; i >= mark + 1; i--)
	{
		if (nums[i] > nums[mark])
		{
			idx = i;
			break;
		}
	}

	swap(nums, mark, idx);

	reverse(nums, mark + 1, nums.Length - 1);

    }
    
   void swap(int[] nums, int i, int j)
    {
        int t = nums[i];
        nums[i] = nums[j];
        nums[j] = t;
    }

    void reverse(int[] nums, int i, int j)
    {
        while (i < j)
        {
            swap(nums, i, j);
            i++;
            j--;
        }
    }

    /*
    Pow(x, n)
    Implement pow(x, n), which calculates x raised to the power n (i.e., xn).

    Example 1:

    Input: x = 2.00000, n = 10
    Output: 1024.00000

    Example 2:

    Input: x = 2.10000, n = 3
    Output: 9.26100

    Example 3:

    Input: x = 2.00000, n = -2
    Output: 0.25000
    Explanation: 2-2 = 1/22 = 1/4 = 0.25

    Tested

    */
     public double MyPow(double x, int n) {
       if(n==int.MaxValue)
       {
           return x;
       }
        else if (n==int.MinValue)
        {
            return (x==1||x==-1)?1:0;
        }
        if(n<0)
        {
            x=1/x;
            n*=-1;
        }
        double ans=1;
        for(int i=0;i<n;i++)
        {
            ans=ans*x;
        }
        return ans;
    }

    /*
    Divide Two Integers


    Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.

    The integer division should truncate toward zero, which means losing its fractional part. For example, 8.345 would be truncated to 8, and -2.7335 would be truncated to -2.

    Return the quotient after dividing dividend by divisor.

    Note: Assume we are dealing with an environment that could only store integers within the 32-bit signed integer range: [−231, 231 − 1]. For this problem, if the quotient is strictly greater than 231 - 1, then return 231 - 1, and if the quotient is strictly less than -231, then return -231.

    Example 1:

    Input: dividend = 10, divisor = 3
    Output: 3
    Explanation: 10/3 = 3.33333.. which is truncated to 3.

    Example 2:

    Input: dividend = 7, divisor = -3
    Output: -2
    Explanation: 7/-3 = -2.33333.. which is truncated to -2.

    Tested
    */
    public int Divide(int dividend, int divisor) {
       if(divisor==0 || (dividend == int.MinValue && divisor ==-1))
       {
           return int.MaxValue;
       }
        int sign=(dividend>0 && divisor <0) || (dividend<0 && divisor >0)?-1:1;
        
        int quotient =0;
        long absoluteDividend=Math.Abs((long)dividend);
        long absoluteDivisor=Math.Abs((long)divisor);
        while(absoluteDividend>=absoluteDivisor)
        {
            int shift=0;
            while(absoluteDividend>=(absoluteDivisor<<shift))
            {
                shift++;
            }
            quotient+=(1<<(shift-1));
            absoluteDividend-=absoluteDivisor<<(shift-1);
            
        }
        return sign==-1?-quotient:quotient;
    }

    /*
    Unique Paths

    There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

    Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

    The test cases are generated so that the answer will be less than or equal to 2 * 109.

    Example 1:
    Input: m = 3, n = 7
    Output: 28

    Example 2:

    Input: m = 3, n = 2
    Output: 3
    Explanation: From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
    1. Right -> Down -> Down
    2. Down -> Down -> Right
    3. Down -> Right -> Down

    Tested 
    */
    public int UniquePaths(int m, int n) {
      int[][] dp=RectangularArrays.RectangularIntArray(m+1,n+1);
        return uniquePathUtil(m,n,dp);
    }
    int uniquePathUtil(int m,int n, int[][] dp)
    {
        if(m==1 || n==1)
        {
            return 1;
        }
        if(dp[m][n]!=0)
        {
            return dp[m][n];
        }
        return dp[m][n]=uniquePathUtil(m-1,n,dp)+uniquePathUtil(m,n-1,dp);
    }

    /*
    Reverse Integer
    Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

    Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

    Example 1:

    Input: x = 123
    Output: 321

    Example 2:

    Input: x = -123
    Output: -321

    Example 3:

    Input: x = 120
    Output: 21

    Tested
    */
    public int Reverse(int x)
    {
       bool isNegative=false;
        if(x<0)
        {
            isNegative=true;
            x=-x;
        }
        long reverse=0;
        while(x>0)
        {
            reverse=reverse*10+x%10;
            x/=10;
        }
        if(reverse>int.MaxValue)
        {
            return 0;
        }
        return (int)(isNegative?-reverse:reverse);
    }
    
 }

 public class RectangularArrays
{
    public static int[][] RectangularIntArray(int size1, int size2)
    {
        int[][] newArray=new int[size1][];
        for(int array1=0;array1<size1;array1++)
        {
            newArray[array1]=new int[size2];
        }
        return newArray;
    }
}