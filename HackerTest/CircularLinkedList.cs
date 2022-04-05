public class CircularLinkedList
{
    private int currentdata;
    private CircularLinkedList nextdata;
    public CircularLinkedList()
    {
        currentdata = 0;
        nextdata = this;
    }
    public CircularLinkedList(int value)
    {
        currentdata = value;
        nextdata = this;
    }
    public CircularLinkedList Insdata(int value)
    {
        CircularLinkedList node = new CircularLinkedList(value);
        if (this.nextdata == this) 
        {
            node.nextdata = this;
            this.nextdata = node;
        }
        else
        {
            CircularLinkedList temp = this.nextdata;
            node.nextdata = temp;
            this.nextdata = node;
        }
        return node;
    }
    public int Deldata()
    {
        if (this.nextdata == this)
        {
            System.Console.WriteLine("\nOnly one node!!!!");
            return 0;
        }
        CircularLinkedList node = this.nextdata;
        this.nextdata = this.nextdata.nextdata;
        node = null;
        return 1;
    }
    public void Traverse()
    {
        Traverse(this);
    }
    public void Traverse(CircularLinkedList node)
    {
        if (node == null)
            node = this;
        System.Console.WriteLine("Forward Direction!!!!");
        CircularLinkedList snode = node;
        do
        {
            System.Console.WriteLine(node.currentdata);
            node = node.nextdata;
        }
        while (node != snode);
    }
    public int Gnodes()
    {
        return Gnodes(this);
    }
    public int Gnodes(CircularLinkedList node)
    {
        if (node == null)
            node = this;
        int count = 0;
        CircularLinkedList snode = node;
        do
        {
            count++;
            node = node.nextdata;
        }
        while (node != snode);
        System.Console.WriteLine("\nCurrent Node Value : " + node.currentdata.ToString());
        System.Console.WriteLine("\nTotal nodes :" + count.ToString());
        return count;
    }
}