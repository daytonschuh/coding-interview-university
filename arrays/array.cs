/*
    Implementation of Mutable Dynamic Array

    - [ ] Practice coding using arrays and pointers, and pointer math to jump to an index instead of using indexing.
    - [ ] New raw data array with allocated memory
        - can allocate int array under the hood, just not use its features
        - start with 16, or if starting number is greater, use power of 2 - 16, 32, 64, 128
    - [x] size() - number of items
    - [x] capacity() - number of items it can hold
    - [x] is_empty()
    - [x] at(index) - returns item at given index, blows up if index out of bounds
    - [x] push(item)
    - [x] insert(index, item) - inserts item at index, shifts that index's value and trailing elements to the right
    - [x] prepend(item) - can use insert above at index 0
    - [x] pop() - remove from end, return value
    - [x] delete(index) - delete item at index, shifting all trailing elements left
    - [x] remove(item) - looks for value and removes index holding it (even if in multiple places)
    - [x] find(item) - looks for value and returns first index with that value, -1 if not found
    - [x] resize(new_capacity) // private function
        - when you reach capacity, resize to double the size
        - when popping an item, if size is 1/4 of capacity, resize to half
*/
public class DynamicArray<T>{
    public T[] Arr;
    public int Size;
    public int Capacity;

    internal DynamicArray(){
        this.Arr = new T[1];
        this.Capacity = 1;
        this.Size = 0;
    }
    internal DynamicArray(int capacity){
        this.Arr = new T[1];
        this.Capacity = capacity;
        this.Size = 0;
    }
    internal DynamicArray(T[] arr){
        this.Arr = arr;
        this.Capacity = arr.Length;
        this.Size = arr.Length;
    }

    public T Get(int i){
        return this.Arr[NormalizeIndex(i)];
    }

    public void Set(int i, dynamic val){
        this.Arr[NormalizeIndex(i)] = val;
    }

    public bool IsEmpty(){
        return this.Size == 0;
    }

    public void Push(dynamic val){
        Resize();
        this.Arr[this.Size] = val;
        this.Size++;
    }

    public void Insert(int index, dynamic val){
        Resize();
        T[] temp = new T[this.Capacity];
        int flag = 0;
        for(int i = 0; i < this.Capacity; i++){
            if(i == index) {
                temp[index] = val;
                flag = 1;
            }
            else temp[i] = this.Arr[i-flag]; 
        }

        this.Arr = temp;
        this.Size++;
    }

    public void Prepend(dynamic val){
        Resize();
        T[] temp = new T[this.Capacity+1];
        temp[0] = val;
        this.Size++;
        for(int i = 1; i < this.Capacity; i++){
            temp[i] = this.Arr[i-1];
        }
        temp[this.Capacity] = this.Arr[this.Capacity-1];
        this.Arr = temp;
    }

    public T Pop(){
        T val = this.Arr[this.Size-1];
        this.Arr[this.Size-1] = default;
        this.Size--;
        Resize();
        return val;
    }

    public void Delete(int index){
        for(int i = index; i < this.Capacity-1; i++){
            this.Arr[i] = this.Arr[i+1];
        }
        this.Size--;
        Resize();
    }

    public void Remove(dynamic val){
        for(int i = 0; i < this.Size; i++){
            if(this.Arr[i] == val) {
                this.Size--;
                for(int j = i; j < this.Size; j++){
                    this.Arr[j] = this.Arr[j+1];
                }
                i--;
            }
        }
        Resize();
    }

    public int Find(dynamic val){
        for(int i = 0; i < this.Capacity; i++){
            if(this.Arr[i] == val) return i;
        }
        return -1;
    }

    private int NormalizeIndex(int i){
        return i%this.Size;
    }

    private void Resize(){
        if(this.Size == this.Capacity){
            T[] temp = new T[2*this.Capacity];
            for(int i = 0; i < this.Capacity; i++){
                temp[i] = this.Arr[i];
            }

            this.Capacity *= 2;
            this.Arr = temp;
        }
        if(this.Size <= this.Capacity / 4){
            this.Capacity /= 2;
        }
    }
}