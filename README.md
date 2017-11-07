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

đây là hàm tìm giá trị nhỏ nhất trong `int[] dist`. Hàm này trả về *vị trí* của phần tử
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
nếu phần tử nhỏ nhất đã được xác định thì chuyễn sang phần tử nhỏ kế nó. Ví dụ chuỗi sau:
```
0 1 2 3 4 5 6
T T F F F F F
```
phần tử `0` nhỏ nhất nhưng nó là `T` nên `continue` sang `1` và `1` cũng `T` nên chuyển cho phần tử nhỏ tiếp là `2` và có `F` nên nhận `min = 2`
> Dijkstra()

1. gọi hàm `SetInfiniteAllDistElement()` để thiết lập.
2. phần tử xuất phát = 0
3. khai báo biến `start` - biến tạm cho vị trí xuất phát
4. Bắt đầu từ phần tử nhỏ nhất với hàm `Min()`
5. Tìm các phần tử kề với đỉnh `start`
6. Nếu phần tử kề này chưa đánh dấu thì :
7. Kiểm tra và cập nhật lại `dist[i]` và tạo `pre[i]` có giá trị là phần tử root
```Csharp
if (dist[item.Item1 - 1] > dist[start - 1] + item.Item2)
{
    dist[item.Item1 - 1] = dist[start - 1] + item.Item2;
    pre[item.Item1 - 1] = start - 1;
}
```
8. Gán thẻ xác định cho phần tử nhỏ nhất để lần sau không đụng tới (loại bỏ khỏi tập đồ thị).
9. Lặp lại bước 4 cho tới khi phần tử kết thúc không còn nằm trong tập đồ thị.

> ShortestRoad()

hàm hiển thị đường đi của dijkstra bằng `Stack`

===========================================================