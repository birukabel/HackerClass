public class JaggedArray
{
     public static void Rotate(int[][] matrix) 
     {
         for(int i=0;i<matrix.GetLength(0);i++)//Loop through number of arrays
         {
             HackerClassArray.RotateArray(matrix[i],true,3);
         }
     }

    /*
    You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).

    You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
    Tested
    */
    public void RotateLetCode(int[][] matrix) 
    {
         int n = matrix[0].Length;
   
        for (int layer = 0; layer < n/2; layer ++) 
        {
            for (int i=layer; i<n-layer-1; i++) 
            {
                //take back before swap
                int temp = matrix[layer][i];

                matrix[layer][i] = matrix[n-i-1][layer];
                matrix[n-i-1][layer] = matrix[n-1-layer][n-i-1];
                matrix[n-1-layer][n-i-1] = matrix[i][n-1-layer];
                matrix[i][n-1-layer] = temp;
            }
        }
    }

    //method to sort rows of a matrix by sum of its elements in Asending/Descending
    //Tested
     public static void Sort2DArrayBySumOfRowsOfElements(int[,] matrix, bool IsAsending)
     {
         if(matrix.GetLength(0)>0 && matrix.GetLength(1)>0) 
         { 
             int[,] sortedMatrix = new int[matrix.GetLength(0),matrix.GetLength(1)];
             for(int i=0;i<matrix.GetLength(0);i++)//perform ascending sort
             {                 
                 int j=0;
                 while(j<matrix.GetLength(0))
                 { 
                     if(i!=j)
                     {                    
                        //j=i+1;                 
                        for(;j<matrix.GetLength(0);j++)
                        {
                            if(i!=j)
                            {
                                int sumi=0,sumj=0;
                                for(int k=0;k<matrix.GetLength(1);k++)
                                {
                                    sumi=sumi+matrix[i,k];
                                    sumj=sumj+matrix[j,k];
                                }
                                if(IsAsending)
                                {
                                    if(sumi>sumj)//Swap Elements
                                    {
                                        for(int l=0;l<matrix.GetLength(1);l++)
                                        {
                                            int temp=matrix[i,l];
                                            int temp2=matrix[j,l];
                                            matrix[i,l]=matrix[j,l];
                                            matrix[j,l]=temp;
                                            //sortedMatrix[i,l]=matrix[j,l];
                                            //sortedMatrix[j,l]=temp;
                                        }
                                    }
                                }
                                else//Descending
                                {
                                    if(sumi<sumj)//Swap Elements
                                    {
                                        for(int l=0;l<matrix.GetLength(1);l++)
                                        {
                                            int temp=matrix[i,l];
                                            int temp2=matrix[j,l];
                                            matrix[i,l]=matrix[j,l];
                                            matrix[j,l]=temp;
                                            //sortedMatrix[i,l]=matrix[j,l];
                                            //sortedMatrix[j,l]=temp;
                                        }
                                    } 
                                }                            
                            }
                        }
                     }
                   j++;
                 }
            }             
         }
     }

    //method to sort array elements of a jagged array by sum of elements in its rows ascending/descnding
    //Tested
     public static void SortJaggedArrayBySumOfRowElements(int[][] arr, bool IsAsending)
     {
         if(arr.Length>0 && arr[0].Length>0)
         {
             for(int i=0;i<arr.Length;i++)//Loop through rows
             {
                 int j=0;
                 while(j<arr.Length)
                 {
                    if(i!=j)//i<arr.Length-1)
                    {                        
                        //j=i+1;
                        int sumi=0,sumj=0;
                        for(int k=0;k<arr[i].Length;k++)
                        {
                            sumi=sumi+arr[i][k];
                        }
                        for(int k=0;k<arr[j].Length;k++)//loop through each elements in each rows
                        {
                            sumj=sumj+arr[j][k];
                        }
                        if(IsAsending)
                        {
                            if(sumi<sumj)//Swap Elements
                            {
                                int len=arr[j].Length;
                                if(arr[i].Length>arr[j].Length)
                                {
                                    len=arr[i].Length;
                                }
                                for(int m=0;m<len;m++)
                                {
                                    int temp=arr[i][m];
                                    arr[i][m]=arr[j][m];
                                    arr[j][m]=temp;
                                }
                            }
                        }
                        else//descending
                        {
                            if(sumi>sumj)
                            {
                                int len=arr[j].Length;
                                if(arr[i].Length>arr[j].Length)
                                {
                                    len=arr[i].Length;
                                }
                                for(int m=0;m<len;m++)
                                {
                                    int temp=arr[i][m];
                                    arr[i][m]=arr[j][m];
                                    arr[j][m]=temp;
                                }
                            }
                        }
                    }
                    //else
                    //{
                        j++;
                    //}
             }
             }
         }
     }

     //Convert a single dimentsional Array to 2D
     //Tested
     public static void SingleArrayTo2D(int[] arr)
     {
         if(arr.Length>1)
         {
              int x,y;
              x=y=0;
            
             if(arr.Length%2==0)//Even length array
             {
                  x=y=arr.Length/2;
             }
             else//Odd length array
             {
                 decimal len = arr.Length;
                 decimal ratio=Math.Round(len/2,2);
                 x=Convert.ToInt32(Math.Ceiling(ratio));
                 y=arr.Length-x;
             }
            
             int[,] matrix=new int[x,y];
             int index=0;
             for(int i=0;i<x;i++)
             {
                 for(int j=0;j<y;j++)
                 {
                     if(index<arr.Length)
                     {
                        matrix[i,j]=arr[index];
                        index++;
                     }
                     else
                     {
                         break;
                     }
                 }
             }
         }
     }

    //Change string to char matrix
    //tested
     public static void ChangeStringToCharMatrix(string str)
     {
         string[] strSplitted = str.Split(' ');
        int x= strSplitted.Length;
        int y=0;
        foreach(string s in strSplitted)//Assigen The Max length to y
        {
            if(y<s.Length)
            {
                y=s.Length;
            }
        }
        char[,] matrix = new char[x,y];
    
        int i=0,j=0;
        foreach(string s in strSplitted)//Assigen chars to matrix
        {
            foreach(char c in s)
            {
                if(i<x && j<y)
                {
                    matrix[i,j]=c;
                    j++;
                }
            }
            i++;
            j=0;
        }
     }

    //Method to assigen string to Jagged Array
    //Tested
     public static void ChangeStringToCharJagged(string str)
     {
         string[] strSplitted = str.Split(' ');
        int x= strSplitted.Length;
        int y=0;

        foreach(string s in strSplitted)//Assigen The Max length to y
        {
            if(y<s.Length)
            {
                y=s.Length;
            }
        }
        char[][] matrix = new char[x][];
        int counter=0;
        while(counter<x)
        {
            matrix[counter]=new char[y];
            counter++;
        }
        int i=0,j=0;
        foreach(string s in strSplitted)//Assigen chars to matrix
        {
            foreach(char c in s)
            {
                if(i<x && j<y)
                {
                    matrix[i][j]=c;
                    j++;
                }
            }
            i++;
            j=0;
        }
     }

    //method that searchs each elements of an array in a range given by avoiding duplicates
    //tested
     public static void PrintOccurenceInArray(decimal[] arr, decimal[][] searchedJagged)
     {
         string str= nameof(searchedJagged);
         if(arr.Length>0 && searchedJagged.Length>0)
         {
            List<decimal> occurence=new List<decimal>();
            int counter=0;
            for(int k=0;k<arr.Length;k++)
            {
            for(int i=0;i<searchedJagged.Length;i++)
            {               
                
                   if(arr[k]>=searchedJagged[i][0] && arr[k]<=searchedJagged[i][1])
                   {
                       if(!occurence.Contains(arr[k]))
                       {
                           counter++;
                           occurence.Add(arr[k]);
                       }
                   }
                }
            }
         }        
        
     }

    /*
    Given an m x n matrix, return all elements of the matrix in spiral order.
    Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
    Output: [1,2,3,6,9,8,7,4,5]

    Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
    Output: [1,2,3,4,8,12,11,10,9,5,6,7]

    Tested
    */
      public IList<int> SpiralOrder(int[][] matrix) {
        List<int> returnedValue = new List<int>();
        if(matrix==null||matrix.Length==0)
        {
            return returnedValue;
        }
        int top=0,bottom=matrix.Length-1;
        int left=0,right=matrix[0].Length-1;
        while(true)
        {
            if(left>right)
            {
                break;
            }
            for(int i=left;i<=right;i++)
            {
             returnedValue.Add(matrix[top][i]);   
            }
            top++;
            if(top>bottom)
            {
                break;
            }
            for(int i=top;i<=bottom;i++)
            {
                returnedValue.Add(matrix[i][right]);
            }
            right--;
            if(left>right)
            {
                break;
            }
            for(int i=right;i>=left;i--)
            {
                returnedValue.Add(matrix[bottom][i]);
            }
            bottom--;
            if(top>bottom)
            {
                break;
            }
            for(int i=bottom;i>=top;i--)
            {
                returnedValue.Add(matrix[i][left]);
            }
            left++;
        }
        return returnedValue;
    }

    /*
    Given a positive integer n, generate an n x n matrix filled with elements from 1 to n2 in spiral order.
    Input: n = 3
    Output: [[1,2,3],[8,9,4],[7,6,5]]    

    Input: n = 1
    Output: [[1]]

    Tested
    */
     public int[][] GenerateMatrix(int n) {
        int total=n*n;
        int[][] result=RectangularIntArray(n,n);
        int x=0;
        int y=0;
        int step=0;
        for(int i=0;i<total;)
        {
            while(y+step<n)
            {
                i++;
                result[x][y]=i;
                y++;
            }
            y--;
            x++;
            while(x+step<n)
            {
                i++;
                result[x][y]=i;
                x++;
            }
            x--;
            y--;
            while(y>=0+step)
            {
                i++;
                result[x][y]=i;
                y--;
            }
            y++;
            x--;
            step++;
            while(x>=0+step)
            {
                i++;
                result[x][y]=i;
                x--;
            }
            x++;
            y++;
        }
        return result;
    }
    
    int[][] RectangularIntArray(int size1, int size2)
    {
        int[][] newArray=new int[size1][];
        for(int array1=0;array1<size1;array1++)
        {
            newArray[array1]=new int[size2];
        }
        return newArray;
    }
}