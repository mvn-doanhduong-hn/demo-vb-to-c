Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace InventorySystem
    ' ---------------------------------------------------------
    ' 1. DATA MODEL (Mô hình dữ liệu - Tương ứng với Table trong DB)
    ' ---------------------------------------------------------
    Public Class Product
        Public Property Id As Integer
        Public Property Name As String
        Public Property Price As Decimal
        Public Property StockQuantity As Integer
        Public Property Category As String

        Public Sub New(id As Integer, name As String, price As Decimal, stock As Integer, category As String)
            Me.Id = id
            Me.Name = name
            Me.Price = price
            Me.StockQuantity = stock
            Me.Category = category
        End Sub
    End Class

    ' ---------------------------------------------------------
    ' 2. BUSINESS LOGIC (Nghiệp vụ xử lý)
    ' ---------------------------------------------------------
    Public Class InventoryManager
        Private _products As List(Of Product)

        Public Sub New()
            _products = New List(Of Product)()
        End Sub

        ' Chức năng: Thêm sản phẩm mới
        Public Sub AddProduct(p As Product)
            If p.Price < 0 Then
                Console.WriteLine("Error: Price cannot be negative.")
                Return
            End If
            _products.Add(p)
            Console.WriteLine($"[Log] Added product: {p.Name}")
        End Sub

        ' Chức năng: Tính tổng giá trị tồn kho
        Public Function GetTotalInventoryValue() As Decimal
            ' Logic này giúp test xem công cụ có convert được vòng lặp/công thức không
            Dim total As Decimal = 0
            For Each p In _products
                total += (p.Price * p.StockQuantity)
            Next
            Return total
        End Function

        ' Chức năng: Lọc sản phẩm sắp hết hàng (Sử dụng LINQ)
        Public Function GetLowStockProducts(threshold As Integer) As List(Of Product)
            ' Logic này test khả năng convert LINQ/Lambda Expression
            Return _products.Where(Function(p) p.StockQuantity <= threshold).ToList()
        End Function
    End Class

    ' ---------------------------------------------------------
    ' 3. MAIN PROGRAM (Chương trình chính)
    ' ---------------------------------------------------------
    Module Program
        Sub Main(args As String())
            Console.WriteLine("=== STARTING INVENTORY SYSTEM ===")

            Dim manager As New InventoryManager()

            ' 1. Tạo dữ liệu mẫu
            manager.AddProduct(New Product(1, "Laptop Dell XPS", 25000000, 10, "Electronics"))
            manager.AddProduct(New Product(2, "Mouse Logitech", 500000, 4, "Accessories"))   ' Sắp hết
            manager.AddProduct(New Product(3, "Mechanical Keyboard", 1200000, 2, "Accessories")) ' Sắp hết
            manager.AddProduct(New Product(4, "Monitor LG 24inch", 3500000, 15, "Electronics"))

            ' 2. Test Logic tính tổng
            Dim totalValue As Decimal = manager.GetTotalInventoryValue()
            Console.WriteLine($"Total Inventory Value: {totalValue:C0}")

            ' 3. Test Logic lọc hàng tồn kho thấp
            Console.WriteLine(vbCrLf & "--- Low Stock Warnings (< 5 items) ---")
            Dim lowStockItems = manager.GetLowStockProducts(5)

            If lowStockItems.Count > 0 Then
                For Each item In lowStockItems
                    Console.WriteLine($"WARNING: {item.Name} (ID: {item.Id}) only has {item.StockQuantity} left!")
                Next
            Else
                Console.WriteLine("All stocks are sufficient.")
            End If

            Console.WriteLine(vbCrLf & "Press Enter to exit...")
            Console.ReadLine()
        End Sub
    End Module
End Namespace