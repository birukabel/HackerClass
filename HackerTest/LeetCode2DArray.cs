public class LeetCodeSDArray
{
    

    //Method that transposes a matrix
    //tested
    public static int[,] TransposeMatrix(int [,] matrix)
    {
        int width=matrix.GetLength(0);
        int height=matrix.GetLength(1);
        int[,] transposedMatrix= new int[height,width];//Dynamic array declaration
        for(int i=0;i<width;i++)
        {
            for(int j=0;j<height;j++)
            {
                transposedMatrix[j,i]=matrix[i,j];
            }
        }
        return transposedMatrix;
    }

     

    //The concept of rotating matrix is transpose it first then reverse the columns
    public static int[,] RorateMatrixIn90Degree(int [,] matrix)
    {
        int[,] transposedMatrix=TransposeMatrix(matrix);
        int x=transposedMatrix.GetLength(0);
        int y=transposedMatrix.GetLength(1);
        for(int i=y-1, j=0;i>=0 && j<y;i--,j++)//start with the last column
        {
              if(i==j)//Reverseing has been done
                {
                    return transposedMatrix;
                }
                if(x==y && i==0 && j==(y-1)&& x%2==0)//for odd number dimension
                {
                    return transposedMatrix;
                }
                else//Reverse the columns 
                {
                    int[] temp=new int[x];//Holds columns to the right
                    for(int k=0;k<x;k++)//Swap each elements
                    {
                        temp[k]=transposedMatrix[k,i];
                        transposedMatrix[k,i]=transposedMatrix[k,j];
                        transposedMatrix[k,j]=temp[k];
                    }
                }                
        }

        return new int[,]{};
    }
}