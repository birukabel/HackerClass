public class LinkedList
{
    Node head;
    int count;
    //Implements a null linked list
    public LinkedList()
    {
        head=null;
        count=0;
    }

    public LinkedList(Node newData)
    {
        head=newData;
        count=1;
    }

    //Add node to the tail of the LinkedList
    /*public void Add(int NewData)
    {
        Node temp=new Node(NewData);
        Node current=head;
        while(current.GetNext()!=null)
        {
            current=current.GetNext();
        }
        if(current.GetNext()==null)
        {
            current.SetNext(temp);
            count++;
        }
    }*/

    //Gets the element at specified index
    /*public int get(int index)
    {
        if(index<0)
        {
            return -1;
        }
        Node current=head;
        //The loop starts at 1 so that we can also get the head node
        for(int i=1;i<index;i++)
        {
            current=current.GetNext();
        }
        return current.GetData();
    }*/

    //returns size of the linkedlist
    public int size()
    {
        return count;
    }

    //Check if linked list is empty its enough to check if the head is null or not
    public bool IsEmpty()
    {
        return (head==null?true:false);
    }

    //Removes elemenet at the end of linked list will make the second element @ the tail
    //to point to null
    /*public void Remove()
    {
        Node current=head;
        while(current.GetNext().GetNext()!=null)
        {
            current=current.GetNext();
        }
        current.SetNext(null);
        count--;
    }*/
}