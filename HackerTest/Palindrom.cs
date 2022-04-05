public class Palindrom
{
    string stack="",queue="";
    int stackIndex=0,queueIndex=0;

    void resetVariableValues()
    {
        stack="";
        queue="";
        stackIndex=0;
        queueIndex=0;
    }

    //Method to push cahracter onto a stack
    void pushCharacter(char ch) 
    {
        stack=stack+ch;
        stackIndex++;
    }

    //Method that enqueues a character in the Queue
    void enqueueCharacter(char ch)
    {
        queue = queue+ ch;
        queueIndex++;
    }

    //method that pops and returns the character at the top of the stack
    char popCharacter() 
    {
        if(stackIndex==stack.Length)
        {
            stackIndex=stack.Length-1;
        }
        else
        {
            --stackIndex;
        }

        if(stackIndex>=0)
        {
            return stack[stackIndex];
        }
        return 'A';//Indicates no element exists in stack
    }

    //method that dequeues and returns the first character in the queue
    char dequeueCharacter()
    {
        if(queueIndex==queue.Length)
        {
            queueIndex=0;
        }
        else
        {
            queueIndex++;
        }
      
        if(queueIndex<queue.Length)
        {
            return queue[queueIndex];
        }
        return 'A';//Indicates no element exists in queue
    }

    //Check a string is palidrom or not using stack and queue implementaion
    //Tested
    public string CheckStringIsPalindrom(string s)
    {
        resetVariableValues();
        foreach(char c in s)//push and enque charachters to stack and queue
        {
            enqueueCharacter(c);
            pushCharacter(c);
        }
        foreach(char c in s)
        {
            if(popCharacter()!=dequeueCharacter())
            {
                return "The word," + s + ", is not a palindrome.";
            }
        }
        return "The word," + s + ", is a palindrome.";;
    }
}