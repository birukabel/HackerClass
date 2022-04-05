public class SinglyLinkedList
{
    Node head;
    public void InsertFront(SinglyLinkedList singlyList, int new_data) 
    {    
        Node new_node = new Node(new_data);    
        new_node.next = singlyList.head;    
        singlyList.head = new_node;    
    } 

    public void InsertLast(SinglyLinkedList singlyList, int new_data)    
    {    
        Node new_node = new Node(new_data);    
        if (singlyList.head == null) {    
            singlyList.head = new_node;    
            return;    
        }    
        Node lastNode = GetLastNode(singlyList);    
        lastNode.next = new_node;    
    } 

    public Node GetLastNode(SinglyLinkedList singlyList) 
    {  
        Node temp = singlyList.head;  
        while (temp.next != null) {  
            temp = temp.next;  
        }  
        return temp;  
    }  

    public void InsertAfter(Node prev_node, int new_data)  
    {  
        if (prev_node == null) {  
            Console.WriteLine("The given previous node Cannot be null");  
            return;  
        }  
        Node new_node = new Node(new_data);  
        new_node.next = prev_node.next;  
        prev_node.next = new_node;  
    }  

    public void DeleteNodebyKey(SinglyLinkedList singlyList, int key)  
    {  
        Node temp = singlyList.head;  
        Node prev = null;  
        if (temp != null && temp.data == key) {  
            singlyList.head = temp.next;  
            return;  
        }  
        while (temp != null && temp.data != key) 
        {  
            prev = temp;  
            temp = temp.next;  
        }  
        if (temp == null) {  
            return;  
        }  
        prev.next = temp.next;  
    }  

    public void ReverseLinkedList(SinglyLinkedList singlyList)  
    {  
        Node prev = null;  
        Node current = singlyList.head;  
        Node temp = null;  
        while (current != null) {  
            temp = current.next;  
            current.next = prev;  
            prev = current;  
            current = temp;  
        }  
        singlyList.head = prev;  
    } 
}