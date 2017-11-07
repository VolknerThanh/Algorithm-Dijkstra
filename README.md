# Algorithm-Dijkstra

### Các Chuỗi
```Csharp
int[] dist = new int[n];
```
đây là chuỗi lưu lại các đỉnh
```Csharp
int[] pre = new int[n];
```
đây là chuỗi lưu lại đường đi của thuật toán
```Csharp
int[] label = new bool[n];
```
đây là chuỗi cờ đánh dấu các đỉnh đã hoàn thành
### Thiết Lập
> mặc định tất cả các đỉnh `dist[i]` có giá trị lớn nhất
> ```charp
> dist[i] = int.MaxValue;
> ```
> mặc định các đỉnh ban đầu có `pre[i]` là `-1`
> đỉnh đầu tiên sẽ có `dist[xp] = 0`
### Các Hàm Và Chức Năng
> Input()

hàm dùng để đọc file `graph.inp` và khai báo các biến các cấu trúc dữ liệu.
> Output()

hàm xuất dữ liệu đã đọc từ file `graph.inp`.
> DFS()

hàm duyệt theo chiều sâu để kiểm tra tính liên thông của đồ thị.
> PrintDFS()

hàm in danh sách các phần tử đã được duyệt theo chiều sâu
> SetInfiniteAllDistElement()

hàm thiết lập cho các `dist[i]` giá trị lớn nhất là vô cực và `pre[i]` với giá trị là -1
> Solve()

hàm kiểm tra đồ thị bằng `DFS()`. Nếu điểm kết thúc không liên thông với điểm bắt đầu thì không thể chạy được, ngược lại sẽ chạy hàm `dijkstra()` và in ra `ShortestRoad()`
> Min()

đây là hàm tìm giá trị nhỏ nhất trong `int[] dist`
```csharp
if(min == -1)
{
    if (label[i] == true)
        continue;
    else
        min = i;
}
if (dist[i] < dist[min] && label[i] == false)
    min = i;
```
nếu phần tử nhỏ nhất đã được xác định thì chuyễn sang phần tử nhỏ kế nó. Ví dụ
`0 1 2 3 4 5 6`
`T T F F F F F`
