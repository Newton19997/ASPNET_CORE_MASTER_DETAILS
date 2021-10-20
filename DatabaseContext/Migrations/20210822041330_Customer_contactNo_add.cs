using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class Customer_contactNo_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Customers",
                nullable: true);



            migrationBuilder.Sql(@"create procedure[dbo].[Sp_OrderInfo]
as
begin
SELECT        o.id, o.OrderNo, o.OrderDate, c.CustomerName, SUM(ISNULL(od.Qty, 0) * ISNULL(od.UnitPrice, 0)) AS Totalprice
FROM            dbo.Orders AS o LEFT OUTER JOIN
                         dbo.Customers AS c ON o.CustomerId = c.Id LEFT OUTER JOIN
                         dbo.OrderDetails AS od ON od.OrderId = o.id
GROUP BY o.id, o.OrderNo, o.OrderDate, c.CustomerName
end"
                                            );


            migrationBuilder.Sql(@"create procedure[dbo].[Sp_OrderInfo_withParamater] 
(
@OrderNo nvarchar(20),
@CustomerName  nvarchar(50)

)
as
begin
SELECT o.id,
o.OrderNo, 
o.OrderDate,
c.CustomerName, 
SUM(ISNULL(od.Qty, 0) * ISNULL(od.UnitPrice, 0)) AS Totalprice
FROM  dbo.Orders AS o 
 JOIN dbo.Customers AS c ON o.CustomerId = c.Id 
 JOIN dbo.OrderDetails AS od ON od.OrderId = o.id

where 
o.OrderNo LIKE '%'+case when @OrderNo ='' then o.OrderNo else @OrderNo end +'%'
and c.CustomerName LIKE '%'+case when @CustomerName ='' then c.CustomerName else @CustomerName end +'%'
--LIKE '%'+CASE WHEN @WorkOrderNo='' THEN WOM.WorkOrderNo ELSE @WorkOrderNo END+'%'
GROUP BY o.id, o.OrderNo, o.OrderDate, c.CustomerName
end"
                                      );


            migrationBuilder.Sql(@"create procedure[dbo].[spOrderID]
(
@OrderID int
)
as
begin
select 
a.id,
a.OrderNo,
a.OrderDate,
a.CustomerId,
b.CustomerName from Orders a
join Customers b on a.CustomerId=b.Id
where a.id=@OrderID
end"
                                     );



            migrationBuilder.Sql(@"create procedure[dbo].[spOrderIDWiseDetails]
(
@OrderID int
)
as
begin
SELECT
a.Id,
OrderId,
ProductId,
Name,
Qty,
UnitPrice,
DiscountPercentage

FROM OrderDetails a
join Products b on a.ProductId=b.Id
where OrderId=@OrderID
end"
                                     );


            migrationBuilder.Sql(@"create procedure [dbo].[spProductlist]
(
@Id int
)
as
begin
select
a.Id,a.Name,Price,Description,IsActive,ImageName,a.CategoryId, b.Name as CategoryName
 from Products a
join Categorys b on b.Id=a.CategoryId
where a.Id= @Id 
end"
                                     );



            migrationBuilder.Sql(@"create VIEW vw_OrderInfo
AS 
SELECT        o.Id, o.OrderNo, o.OrderDate, c.CustomerName, SUM(ISNULL(od.Qty, 0) * ISNULL(od.UnitPrice, 0)) AS Totalprice
FROM            dbo.Orders AS o LEFT OUTER JOIN
                         dbo.Customers AS c ON o.CustomerId = c.Id LEFT OUTER JOIN
                         dbo.OrderDetails AS od ON od.OrderId = o.Id
GROUP BY o.Id, o.OrderNo, o.OrderDate, c.CustomerName"
                                   );

            migrationBuilder.Sql(@"create VIEW vw_Productlist
AS
SELECT        a.Id, a.Name, a.Price, a.Description, a.IsActive, a.ImageName, a.CategoryId, b.Name AS CategoryName
FROM            dbo.Products AS a INNER JOIN
                         dbo.Categorys AS b ON b.Id = a.CategoryId"
                                  );


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Customers");

            migrationBuilder.Sql("drop procedure if exists dbo.Sp_OrderInfo");
            migrationBuilder.Sql("drop procedure if exists dbo.Sp_OrderInfo_withParamater");
            migrationBuilder.Sql("drop procedure if exists dbo.spOrderID");
            migrationBuilder.Sql("drop procedure if exists dbo.spOrderIDWiseDetails");
            migrationBuilder.Sql("drop procedure if exists dbo.spProductlist");


            migrationBuilder.Sql("drop VIEW if exists dbo.vw_OrderInfo");
            migrationBuilder.Sql("drop VIEW if exists dbo.vw_Productlist");


        }
    }
}
