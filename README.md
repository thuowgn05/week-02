# Week 02 — ASP.NET Core MVC

Dự án thực hành **.NET 8 / ASP.NET Core MVC**, gồm phần tìm hiểu, mã nguồn ví dụ và ảnh chụp ứng dụng đang chạy.

## Nội dung

| Chủ đề | Bài tìm hiểu và giải thích code | Trang thực hành |
|---|---|---|
| Partial View và View Component | [Đọc bài](docs/view-component-va-partial-view.md) | `/ViewExamples` |
| Conventional Routing và Attribute Routing | [Đọc bài](docs/conventional-va-attribute-routing.md) | `/RoutingExamples` |

## Chạy ứng dụng

Yêu cầu: .NET SDK 8. Không cần database hoặc cài thêm thư viện NuGet cho các ví dụ này.

```bash
dotnet build WebApplication1/WebApplication1.csproj
dotnet run --project WebApplication1 --launch-profile http
```

Mở http://localhost:5048, chọn **Ví dụ View** hoặc **Ví dụ Routing** trên menu. Nhấn Ctrl+C trong terminal để dừng. Nếu cổng 5048 đang được dùng, dừng phiên chạy cũ trước khi chạy lại.

Trên máy đã cài SDK vào thư mục riêng trong phiên thực hành này, đặt biến môi trường trước khi chạy:

```bash
export DOTNET_ROOT="$HOME/.dotnet/sdk-8.0.426-local"
```

Máy cài .NET theo cách chuẩn thường không cần dòng trên.

## Mã nguồn cần đọc

```text
WebApplication1/
├── Program.cs                                      # Conventional route mặc định
├── Controllers/
│   ├── ViewExamplesController.cs                   # Dữ liệu cho Partial View
│   ├── RoutingExamplesController.cs                # Conventional routing
│   └── AttributeProductsController.cs              # Attribute routing
├── Models/
│   ├── ProductViewModel.cs
│   └── RoutingExampleViewModel.cs
├── ViewComponents/
│   └── FeaturedProductsViewComponent.cs            # Xử lý dữ liệu riêng
└── Views/
    ├── ViewExamples/Index.cshtml
    ├── RoutingExamples/
    │   ├── Index.cshtml
    │   └── Result.cshtml                           # View chung cho hai kiểu route
    └── Shared/
        ├── _ProductCard.cshtml                     # Partial View dùng lại
        └── Components/FeaturedProducts/Default.cshtml
```

Dữ liệu sản phẩm và giá đều là dữ liệu mẫu phục vụ học tập. Các trang routing chỉ hiển thị giá trị nhận được từ request, không xác nhận sản phẩm tồn tại.

## Ảnh minh họa

Ảnh được chụp từ ứng dụng chạy thực tế bằng trình duyệt, không phải mock-up.

### Partial View và View Component

![Partial View và View Component](docs/images/01-view-examples.png)

### Conventional Routing và Attribute Routing

![Trang tìm hiểu routing](docs/images/02-routing-overview.png)

- [Ảnh kết quả Conventional Routing](docs/images/03-conventional-routing.png)
- [Ảnh kết quả Attribute Routing](docs/images/04-attribute-routing.png)

## Tự kiểm tra

Sau khi chạy ứng dụng:

```bash
curl -i http://localhost:5048/ViewExamples
curl -i http://localhost:5048/RoutingExamples
curl -i http://localhost:5048/RoutingExamples/Product/5
curl -i http://localhost:5048/routing-demo/products/5
```

Bốn URL trên phải trả **200**. Trên trang View, component hiển thị hai sản phẩm theo giá tăng dần và có ví dụ danh sách rỗng. Trên hai trang kết quả routing, tham số id phải là **5**.

Kiểm tra điều kiện routing:

```bash
# Không khớp constraint int: mong đợi 404.
curl -i http://localhost:5048/routing-demo/products/abc

# Action attribute-routed không có thêm URL conventional: mong đợi 404.
curl -i http://localhost:5048/AttributeProducts/Details/5

# Đúng URL nhưng sai HTTP method: mong đợi 405.
curl -i -X POST http://localhost:5048/routing-demo/products/5
```

**Lỗi có sẵn ở bản nguồn, ngoài phạm vi các bài trên:** `/Hello` trả 500 vì thiếu `Views/Hello/Index.cshtml`. `/Hello/Welcome?name=Anh&ID=3` hoạt động bình thường.

## Nguồn dự án và tài liệu

- Dự án nền được nhập từ [TvC2170/day2](https://github.com/TvC2170/day2), commit `ee3af24937ef66a694a4e205080fdc777a1eb759`.
- Giữ nguyên các giấy phép thư viện trong `WebApplication1/wwwroot/lib`.
- Các bài trong `docs/` có liên kết tài liệu Microsoft Learn tương ứng.
