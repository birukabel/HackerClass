public class RandomQuestions{
    //Method to Determine if any two integers in array sum to given integer.
    //Before printing the method also checks elements have already been printed or not
    //Tested
    public static void ElementsInArraySum(int[] Arr, int num)
    {
        List<List<int>> visitedPaiers = new List<List<int>>();
        for(int i=0;i<Arr.Length;i++)
        {
            for(int j=0;j<Arr.Length;j++)
            {
                if(Arr[i]+Arr[j]==num && i!=j)
                {
                    if(!visitedPaiers.Contains(new List<int>{Arr[i],Arr[j]}) || !visitedPaiers.Contains(new List<int>{Arr[j],Arr[i]}))
                    {
                        visitedPaiers.Add(new List<int>{Arr[i],Arr[j]});
                        System.Console.WriteLine("First Element:"+ Arr[i]+", Second Element:"+Arr[j]);
                    }
                }
            }
        }
    }

    //A function which takes an array and prints the majority 
    //element (if it exists), otherwise prints “No Majority Element”. 
    //A majority element in an array A[] of size n is an element that appears 
    //more than n/2 times (and hence there is at most one such element)
    //Tested
    public static void PrintMajorityElementOfAnArray(int[] Arr)
    {
        Dictionary<int,int> dicElementFerequency = new Dictionary<int, int>();
        List<int> visitedElements = new List<int>();
        for(int i=0;i<Arr.Length;i++)
        {  
            if(!visitedElements.Contains(Arr[i]))
            {
                visitedElements.Add(Arr[i]);
            }
        }
        foreach(int el in visitedElements)
        {
            int counter=0;
            for(int k=0;k<Arr.Length;k++)
            {
                if(Arr[k]==el)
                {
                    counter++;
                }
            }
            if(dicElementFerequency.ContainsKey(el))
            {
                dicElementFerequency[el]=counter;
            }
            else
            {
                dicElementFerequency.Add(el,counter);                
            }
        }
        
        int halfArrLength = Arr.Length/2;
        if(halfArrLength>0)
        {
            bool elFound=false;
            foreach(int key in dicElementFerequency.Keys)
            {
                if(dicElementFerequency[key]>halfArrLength)
                {
                    elFound=true;
                    System.Console.WriteLine("Element:"+ key);
                }
            }
            if(!elFound)
            {
                System.Console.WriteLine("No Majority Element");
            }
        }
        else
        {
            System.Console.WriteLine("Array size is less than or equal to one!");
        }
    }

    //Method to Merge two arrays after sorting them
    //Tested
    public static int[] MergeTwoSortedArrays(int[] Arr1,int[] Arr2)
    {
        int[] mergedArray=new int[]{};
        List<int> lstMerg = new List<int>();
        HackerClassArray.SortArray(Arr1,true);//Sort Array in ascending
        HackerClassArray.SortArray(Arr2,true);//Sort Array in ascending
        for(int i=0;i<Arr2.Length;i++)
        {
            //mergedArray[i]=Arr2[i];
            lstMerg.Add(Arr2[i]);
        }
        for(int i=0;i<Arr1.Length;i++)
        {
            lstMerg.Add(Arr1[i]);
            //mergedArray[i]=Arr1[i];
        }

        return lstMerg.ToArray();
    }

    //Method to find missing elements in Arr (numbers to check are between 1 and 100)
    //Tested
    public static void FindMissingElementsInArr(int[] Arr)
    {
        for(int i=1;i<=100;i++)
        {
            bool isFound=false;
            for(int j=0;j<Arr.Length;j++)
            {
                if(i==Arr[j])
                {
                    isFound=true;
                    break;
                }
            }
            if(!isFound)
            {
               System.Console.WriteLine(i+" is not found!"); 
            }
        }
    }

    //Method to swap MAX and MIN elements in an Array
    //Tested
    public static int[] SwapMinMaxElementsInArray(int[] Arr)
    {
        if(Arr.Length>1)
        {
            HackerClassArray.SortArray(Arr,true);//Sort Array in Ascending
            HackerClass.Swap(ref Arr[0],ref Arr[Arr.Length-1]);
            return Arr;
        }
        return new int[]{};
    }

    //Move zeros to end of array
    //Tested
    public static int[] MoveZerosToEndOfArray(int[] Arr)
    {
        if(Arr.Length>1)
        {
            int[] copiedArray = Arr;
            int indexCopied=0;
            int zerosCount=0;
            for(int i=0;i<Arr.Length;i++)//Add non-zeros to array
            {
                if(Arr[i]!=0)
                {
                    copiedArray[indexCopied]=Arr[i];
                    indexCopied++;
                }
                else
                {
                    zerosCount++;
                }
            }
            for(int j=0;j<zerosCount&& indexCopied<Arr.Length;j++,indexCopied++)//Add zeros to array
            {
                copiedArray[indexCopied]=0;
            }
            return copiedArray;
        }
        return Arr;
    }

    //Check Array contains duplicate elements
    //True
    public static bool CheckDuplicateElmentInArray(int[] Arr)
    {
        for(int i=0;i<Arr.Length;i++)
        {
            int counter=0;
            for(int j=0;j<Arr.Length;j++)
            {
                if(Arr[i]==Arr[j]&& i!=j)
                {
                    counter++;
                    if(counter>=1)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public int FindTheSmallestPositiveNumber(int[] nums)
    {
        int min=1;
        int max=1;

        for(int i=0;i<nums.Length;i++)//find min
        {
            if(min>nums[i] && nums[i]>0)
            {
                min=nums[i];
            } 
            if(nums[i]>max && nums[i]>0)
            {
                max=nums[i];
            }           
        }
        if(min-1>0)
        {
            return --min;
        }
        if(min<1)
        {
            min=1;
        }
        if(max<1)
        {
            max=1;
        }
        bool isFound=false;
        int temp=1;
        for(int i=min,index=0;i<=max&& index<nums.Length;i++,index++)
        {
            isFound=false;
            if(nums[index]==i)
            {
                isFound=true;
                continue;
            }
            else
            {
                temp=i;
            }
        }
        return temp;
        /*else//min-1<=0
        {
            int temp=min+1;
            for(int j=0;j<nums.Length;j++)
            {
                if(temp==nums[j])
                {
                    temp++;
                }
            }
            if(temp>0)
            {
                return temp;
            }
        }*/
        //return -1;
    }
}