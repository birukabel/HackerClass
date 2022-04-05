public class stack {
        public int top = -1;
        public char[] items = new char[100];
 
        public void push(char x)
        {
            if (top == 99)
            {
                Console.WriteLine("Stack full");
            }
            else {
                items[++top] = x;
            }
        }
 
        char pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Underflow error");
                return '\0';
            }
            else
            {
                char element = items[top];
                top--;
                return element;
            }
        }
 
        Boolean isEmpty()
        {
            return (top == -1) ? true : false;
        }
    }