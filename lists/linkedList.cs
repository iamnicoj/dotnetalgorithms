using System.Collections;  
using System.Collections.Generic;  

public class LinkedList<T> : IEnumerable  
{
    internal Node<T> head { get; set; }
    private int length;
    public int Length
    {
        get { return length; }
        set { length = value; }
    }
    
    public LinkedList(){
        
    }    

    public void Add(T item){
        var temp = new Node<T>(item);

        temp.Next = head;
        head = temp;

        Length++;
    }  

    public T GetItem(T item){
        var temp = head;

        while (temp != null)
        {
            if(temp.Item.Equals(item))
                return temp.Item;
            temp = temp.Next;
        }

        return default(T);
    }    

    public bool RemoveItem(T item){
        Node<T> past = null;
        Node<T> temp = head;

        while (temp != null)
        {
            if(temp.Item.Equals(item)){
                if( past == null ) 
                { 
                    head = temp.Next; 
                    Length--;
                    return true; 
                }
                
                past.Next = temp.Next;      
                Length--;
                return true;
            } 
            past = temp;
            temp = temp.Next;
        }
        return false;
    }    

    public void BubbleSort(){
        if(this.head ==null && this.head.Next == null) return;

        var iterator = this.head;
        T temp;
        int movindEnd;

        for (int i = 1; i < this.length; i++){
            movindEnd = 1;
            while (iterator !=null && iterator.Next != null && movindEnd <= this.length - i)        
            {            
                movindEnd++;
                if (Comparer<T>.Default.Compare(iterator.Item, iterator.Next.Item) > 0){
                    temp = iterator.Item;
                    iterator.Item = iterator.Next.Item;
                    iterator.Next.Item = temp;
                }

                iterator = iterator.Next;
            }
            iterator = this.head;
        }
    }

    public void ReverseList()
    {
        Queue<T> queue = new Queue<T>();

        var temp = this.head;

        while(temp != null)
        {
            queue.Enqueue(temp.Item);
            temp = temp.Next;
        }

        this.head = null;
        while(queue.Count > 0)
        {
            this.Add(queue.Dequeue());
        }

        return;
    }
    
    // IEnumerable Member  
    public IEnumerator GetEnumerator()  
    {  
        return new LinkedListEnum<T>(this);
    }      

}

public class LinkedListEnum<T> : IEnumerator
{
    public LinkedList<T> lst { get; set; }
    Node<T> currentItem;
    bool flag;

    public LinkedListEnum(LinkedList<T> list)    
    {

         if(list != null){
            flag = true;
            lst = list;
            currentItem = list.head;
        }
    }

    public object Current 
    {
        get
        {
            return currentItem != null ? currentItem.Item :  default(T);
        }
    }

    public bool MoveNext()
    {
        if(flag){
            flag = false;
            return true;
        }
        else if(currentItem != null){
            currentItem = currentItem.Next;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        if(lst != null) {
            currentItem = lst.head;
        }
    }
}

public class Node<T>{
    public T Item { get; set; }

    internal Node<T> Next { get; set; }

    public Node(T item)
    {
        this.Item = item;        
    }
}