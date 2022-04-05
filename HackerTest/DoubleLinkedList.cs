public class DoubleLinkedList 
{  
    DNode head;  
    internal void InsertFront(DoubleLinkedList doubleLinkedList, int data) 
    {  
        DNode newNode = new DNode(data);  
        newNode.next = doubleLinkedList.head;  
        newNode.prev = null;  
        if (doubleLinkedList.head != null) {  
            doubleLinkedList.head.prev = newNode;  
        }  
        doubleLinkedList.head = newNode;  
    }

    public void InsertLast(DoubleLinkedList doubleLinkedList, int data) 
    {  
        DNode newNode = new DNode(data);  
        if (doubleLinkedList.head == null)
        {  
            newNode.prev = null;  
            doubleLinkedList.head = newNode;  
            return;  
        }  
        DNode lastNode = GetLastNode(doubleLinkedList);  
        lastNode.next = newNode;  
        newNode.prev = lastNode;  
    } 

    DNode GetLastNode(DoubleLinkedList doubleList) 
    {  
        DNode temp = doubleList.head;  
        while (temp.next != null) {  
            temp = temp.next;  
        }  
        return temp;  
    } 

    public void InsertAfter(DNode prev_node, int data)  
    {  
        if (prev_node == null) 
        {  
            Console.WriteLine("The given prevoius node cannot be null");  
            return;  
        }  
        DNode newNode = new DNode(data);  
        newNode.next = prev_node.next;  
        prev_node.next = newNode;  
        newNode.prev = prev_node;  
        if (newNode.next != null) 
        {  
            newNode.next.prev = newNode;  
        }  
    }

    public void DeleteNodebyKey(DoubleLinkedList doubleLinkedList, int key)  
    {  
        DNode temp = doubleLinkedList.head;  
        if (temp != null && temp.data == key) 
        {  
            doubleLinkedList.head = temp.next;  
            doubleLinkedList.head.prev = null;  
            return;  
        }  
        while (temp != null && temp.data != key) 
        {  
            temp = temp.next;  
        }  
        if (temp == null) 
        {  
            return;  
        }  
        if (temp.next != null) 
        {  
            temp.next.prev = temp.prev;  
        }  
        if (temp.prev != null) 
        {  
            temp.prev.next = temp.next;  
        }  
    } 

} 