/*
    Implementation of Singly and Doubly Linked Lists

    - [x] size() - returns number of data elements in list
    - [x] empty() - bool returns true if empty
    - [x] value_at(index) - returns the value of the nth item (starting at 0 for first)
    - [x] push_front(value) - adds an item to the front of the list
    - [x] pop_front() - remove front item and return its value
    - [x] push_back(value) - adds an item at the end
    - [x] pop_back() - removes end item and returns its value
    - [x] front() - get value of front item
    - [x] back() - get value of end item
    - [x] insert(index, value) - insert value at index, so current item at that index is pointed to by new item at index
    - [x] erase(index) - removes node at given index
    - [x] value_n_from_end(n) - returns the value of the node at nth position from the end of the list
    - [x] reverse() - reverses the list
    - [x] remove_value(value) - removes the first item in the list with this value
*/
internal class ListNode<T>{
        internal T? item;
        internal ListNode<T>? next;
        public ListNode(){}
        public ListNode(T item): this(){
            this.item = item;
            next = null;
        }
}

public class SinglyLinkedList<T>{
    internal ListNode<T> head;

    public SinglyLinkedList(){
        ListNode<T> node = new();
        this.head = node;
    }
    public SinglyLinkedList(T item){
        ListNode<T> node = new(item);
        this.head = node;
    }

    public int Size(){
        int size = 0;
        ListNode<T>? temp = head;
        while(temp != null){
            size++;
            temp = temp.next;
        }
        return size;
    }

    public bool Empty(){
        return EqualityComparer<ListNode<T>>.Default.Equals(head, null);
    }

    public T? ValueAt(int index){
        Console.WriteLine($"Executing ValueAt({index})...");
        ListNode<T>? node = head;
        while(index > 0){
            if(node == null) return default;
            node = node.next;
            index--;
        }
        
        return !EqualityComparer<ListNode<T>>.Default.Equals(node, null) ? node.item : default;
    }

    public void PushFront(T item){
        Console.WriteLine($"Executing PushFront({item})...");
        ListNode<T> newNode = new(item);
        newNode.next = head;
        head = newNode;
    }

    public T PopFront(){
        Console.WriteLine("Executing PopFront()...");
        if(head == null) return default;
        ListNode<T> popped = head;
        head = head.next;
        return popped.item;
    }

    public void PushBack(T item){
        Console.WriteLine($"Executing PushBack({item})...");
        ListNode<T> newNode = new(item);
        // Empty list
        if(head == null) {
            head = newNode;
            return;
        }

        // Navigate to end of list and attach new node
        GetLastLink().next = newNode;
    }

    public T PopBack(){
        Console.WriteLine("Executing PopBack()...");
        

        int size = this.Size();
        ListNode<T> node = head;
        if(size == 1){
            head = null;
        }
        else{
            node = GetLastLink();
            ListNode<T>? temp = head;
            for(int i = 0; i < size-1; i++){
                temp = temp.next;
            }
            temp.next = null;
        }

        return node.item;
    }

    public T? Front(){
        return head != null ? head.item : default;
    }

    public T? Back(){
        return head != null ? GetLastLink().item: default;
    }

    public void Insert(int index, T item){
        Console.WriteLine($"Executing Insert({index}, {item})...");
        if(index == 0){
            PushFront(item);
            return;
        }

        ListNode<T> newNode = new(item);
        ListNode<T> temp = head;
        for(int i = 0; i < index-1; i++){
            if(temp == null) {
                Console.WriteLine($"Index is not within size of list: {this.Size()}");
                return;
            }
            temp = temp.next;
        }
        newNode.next = temp.next;
        temp.next = newNode;
    }

    public void Erase(int index){
        Console.WriteLine($"Executing Erase({index})...");
        if(index == 0) {
            head = head.next;
            return;
        }

        ListNode<T> temp = head;
        for(int i = 0; i < index-1; i++){
            if(temp == null){
                Console.WriteLine($"Index is not within size of list: {this.Size()}");
                return;
            }
            temp = temp.next;
        }
        temp.next = temp.next.next;
    }

    public T? ValueNFromEnd(int index){
        Console.WriteLine($"Executing ValueNFromEnd({index})...");
        int size = this.Size();
        ListNode<T> temp = head;
        for(int i = 0; i < size-index-1; i++){
            if(temp == null) return default;
            temp = temp.next;
        }
        return temp.item;
    }

    public void Reverse(){
        Console.WriteLine("Executing Reverse...");
        if(head != null){
            ListNode<T> curr = head.next;
            ListNode<T> prev = head;
            head = head.next;
            prev.next = null;
        
            while(head!=null){
                head = head.next;
                curr.next = prev;
                prev = curr;
                curr = head;
            }
            head = prev;
        }
    }

    public void RemoveItem(T item){
        Console.WriteLine($"Executing RemoveItem({item})...");
        ListNode<T>? prev = head;
        ListNode<T>? curr = head;

        while(!EqualityComparer<T>.Default.Equals(curr.item,item)){
            prev = curr;
            curr = curr.next;
        }

        prev.next = curr.next;
        curr = null;
    }

    public void Print(){
        if(head != null) Console.WriteLine($"Head: {head.item}");
        else Console.WriteLine("The list appears to be empty.");
        ListNode<T>? temp = head;
        while(temp != null){
            Console.Write(temp.item);
            temp = temp.next;
            if(temp != null) Console.Write(", ");
        }
        Console.WriteLine();
    }

    private ListNode<T> GetLastLink(){
        ListNode<T> temp = head;
        while(temp.next != null){
            temp = temp.next;
        }
        return temp;
    }
}