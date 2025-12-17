' File: Level2_OOP_LINQ.vb
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace TestLevel2
    ' 1. Interface
    Public Interface IPayable
        Function CalculateSalary() As Decimal
    End Interface

    ' 2. Abstract Base Class (Lớp cha trừu tượng)
    Public MustInherit Class Employee
        Implements IPayable

        Public Property Id As Integer
        Public Property Name As String

        Public Sub New(id As Integer, name As String)
            Me.Id = id
            Me.Name = name
        End Sub

        ' Hàm ảo (MustOverride -> abstract)
        Public MustOverride Function CalculateSalary() As Decimal Implements IPayable.CalculateSalary
    End Class

    ' 3. Derived Class (Lớp con kế thừa)
    Public Class FullTimeEmployee
        Inherits Employee

        Public Property BaseSalary As Decimal
        Public Property Bonus As Decimal

        Public Sub New(id As Integer, name As String, salary As Decimal)
            MyBase.New(id, name)
            Me.BaseSalary = salary
            Me.Bonus = 1000 ' Default bonus
        End Sub

        Public Overrides Function CalculateSalary() As Decimal
            Return BaseSalary + Bonus
        End Function
    End Class

    ' 4. Business Logic sử dụng LINQ
    Public Class HRManager
        Private _employees As New List(Of Employee)()

        Public Sub SeedData()
            _employees.Add(New FullTimeEmployee(1, "Alice", 5000))
            _employees.Add(New FullTimeEmployee(2, "Bob", 3000))
            _employees.Add(New FullTimeEmployee(3, "Charlie", 7000))
        End Sub

        ' Test LINQ: Lọc và Sắp xếp
        Public Function GetHighEarners(threshold As Decimal) As List(Of String)
            ' Logic: Lấy tên nhân viên có lương > threshold, sắp xếp giảm dần theo lương
            Return _employees _
                .Where(Function(e) e.CalculateSalary() > threshold) _
                .OrderByDescending(Function(e) e.CalculateSalary()) _
                .Select(Function(e) e.Name) _
                .ToList()
        End Function
    End Class
End Namespace