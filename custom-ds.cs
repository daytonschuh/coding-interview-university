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