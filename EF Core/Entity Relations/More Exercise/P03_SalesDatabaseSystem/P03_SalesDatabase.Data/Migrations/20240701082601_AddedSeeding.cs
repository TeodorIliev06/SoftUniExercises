using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P03_SalesDatabase.Data.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CreditCardNumber", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "0000 0000 0000 9691", "customer1@example.com", "Customer1" },
                    { 2, "0000 0000 0000 5981", "customer2@example.com", "Customer2" },
                    { 3, "0000 0000 0000 8315", "customer3@example.com", "Customer3" },
                    { 4, "0000 0000 0000 4381", "customer4@example.com", "Customer4" },
                    { 5, "0000 0000 0000 8874", "customer5@example.com", "Customer5" },
                    { 6, "0000 0000 0000 1678", "customer6@example.com", "Customer6" },
                    { 7, "0000 0000 0000 6206", "customer7@example.com", "Customer7" },
                    { 8, "0000 0000 0000 9076", "customer8@example.com", "Customer8" },
                    { 9, "0000 0000 0000 4146", "customer9@example.com", "Customer9" },
                    { 10, "0000 0000 0000 1555", "customer10@example.com", "Customer10" },
                    { 11, "0000 0000 0000 4558", "customer11@example.com", "Customer11" },
                    { 12, "0000 0000 0000 8383", "customer12@example.com", "Customer12" },
                    { 13, "0000 0000 0000 3407", "customer13@example.com", "Customer13" },
                    { 14, "0000 0000 0000 4025", "customer14@example.com", "Customer14" },
                    { 15, "0000 0000 0000 7454", "customer15@example.com", "Customer15" },
                    { 16, "0000 0000 0000 3897", "customer16@example.com", "Customer16" },
                    { 17, "0000 0000 0000 3133", "customer17@example.com", "Customer17" },
                    { 18, "0000 0000 0000 6089", "customer18@example.com", "Customer18" },
                    { 19, "0000 0000 0000 9652", "customer19@example.com", "Customer19" },
                    { 20, "0000 0000 0000 9894", "customer20@example.com", "Customer20" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Product1", 715.886626816514m, 85m },
                    { 2, "Product2", 472.758330157478m, 18m },
                    { 3, "Product3", 44.7385604921745m, 90m },
                    { 4, "Product4", 812.061024763184m, 31m },
                    { 5, "Product5", 346.860975203073m, 19m },
                    { 6, "Product6", 92.4866277855415m, 73m },
                    { 7, "Product7", 31.8685121399691m, 68m },
                    { 8, "Product8", 2.20596237637582m, 41m },
                    { 9, "Product9", 965.189283461139m, 65m },
                    { 10, "Product10", 303.589661231976m, 66m },
                    { 11, "Product11", 142.048446020546m, 70m },
                    { 12, "Product12", 677.275943870152m, 61m },
                    { 13, "Product13", 173.98110166669m, 68m },
                    { 14, "Product14", 752.640530170056m, 68m },
                    { 15, "Product15", 921.877557540711m, 13m },
                    { 16, "Product16", 535.012174780144m, 72m },
                    { 17, "Product17", 960.467787302992m, 52m },
                    { 18, "Product18", 332.581520725301m, 23m },
                    { 19, "Product19", 446.413119465568m, 19m },
                    { 20, "Product20", 721.53510012853m, 12m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Name" },
                values: new object[,]
                {
                    { 1, "Store1" },
                    { 2, "Store2" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "Name" },
                values: new object[,]
                {
                    { 3, "Store3" },
                    { 4, "Store4" },
                    { 5, "Store5" },
                    { 6, "Store6" },
                    { 7, "Store7" },
                    { 8, "Store8" },
                    { 9, "Store9" },
                    { 10, "Store10" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "Date", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(2024, 2, 26, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(1952), 2, 8 },
                    { 2, 10, new DateTime(2022, 10, 3, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(1990), 9, 1 },
                    { 3, 8, new DateTime(2023, 10, 2, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(1994), 18, 4 },
                    { 4, 5, new DateTime(2022, 9, 4, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(1998), 2, 1 },
                    { 5, 6, new DateTime(2024, 1, 27, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2000), 9, 4 },
                    { 6, 6, new DateTime(2023, 3, 27, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2005), 7, 5 },
                    { 7, 12, new DateTime(2024, 5, 31, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2009), 3, 3 },
                    { 8, 5, new DateTime(2023, 12, 30, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2012), 3, 1 },
                    { 9, 18, new DateTime(2023, 2, 28, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2016), 5, 1 },
                    { 10, 15, new DateTime(2023, 3, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2021), 2, 3 },
                    { 11, 19, new DateTime(2024, 4, 25, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2025), 20, 4 },
                    { 12, 1, new DateTime(2023, 7, 4, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2028), 11, 8 },
                    { 13, 6, new DateTime(2023, 10, 1, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2031), 5, 10 },
                    { 14, 20, new DateTime(2024, 4, 19, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2034), 2, 8 },
                    { 15, 17, new DateTime(2023, 11, 26, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2038), 12, 4 },
                    { 16, 8, new DateTime(2022, 2, 10, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2041), 19, 2 },
                    { 17, 13, new DateTime(2024, 5, 15, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2044), 19, 3 },
                    { 18, 9, new DateTime(2023, 7, 4, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2049), 13, 8 },
                    { 19, 6, new DateTime(2022, 9, 26, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2052), 2, 2 },
                    { 20, 5, new DateTime(2022, 5, 21, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2056), 4, 3 },
                    { 21, 4, new DateTime(2023, 9, 20, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2059), 1, 10 },
                    { 22, 16, new DateTime(2023, 3, 20, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2062), 7, 6 },
                    { 23, 2, new DateTime(2022, 3, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2065), 16, 6 },
                    { 24, 17, new DateTime(2022, 6, 19, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2068), 5, 3 },
                    { 25, 3, new DateTime(2022, 10, 9, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2071), 7, 7 },
                    { 26, 19, new DateTime(2023, 8, 12, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2075), 6, 8 },
                    { 27, 20, new DateTime(2023, 11, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2078), 20, 1 },
                    { 28, 10, new DateTime(2024, 1, 3, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2081), 3, 4 },
                    { 29, 18, new DateTime(2022, 1, 8, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2084), 19, 10 },
                    { 30, 12, new DateTime(2022, 8, 3, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2088), 18, 4 },
                    { 31, 4, new DateTime(2022, 10, 27, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2129), 17, 4 },
                    { 32, 12, new DateTime(2022, 9, 9, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2134), 1, 9 },
                    { 33, 10, new DateTime(2023, 1, 12, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2138), 15, 2 },
                    { 34, 20, new DateTime(2022, 12, 8, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2143), 10, 2 },
                    { 35, 1, new DateTime(2022, 4, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2146), 5, 3 },
                    { 36, 7, new DateTime(2022, 12, 25, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2149), 15, 9 },
                    { 37, 7, new DateTime(2022, 10, 15, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2151), 6, 1 },
                    { 38, 15, new DateTime(2024, 3, 4, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2154), 12, 7 },
                    { 39, 13, new DateTime(2023, 6, 14, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2157), 20, 6 },
                    { 40, 17, new DateTime(2022, 7, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2159), 4, 10 },
                    { 41, 7, new DateTime(2021, 10, 22, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2162), 2, 7 },
                    { 42, 8, new DateTime(2024, 2, 1, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2165), 10, 9 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "CustomerId", "Date", "ProductId", "StoreId" },
                values: new object[,]
                {
                    { 43, 20, new DateTime(2022, 7, 7, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2169), 4, 7 },
                    { 44, 10, new DateTime(2021, 12, 28, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2171), 10, 8 },
                    { 45, 6, new DateTime(2023, 9, 13, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2174), 5, 2 },
                    { 46, 10, new DateTime(2024, 3, 28, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2177), 15, 7 },
                    { 47, 2, new DateTime(2022, 4, 25, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2181), 5, 2 },
                    { 48, 6, new DateTime(2022, 9, 12, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2184), 2, 9 },
                    { 49, 13, new DateTime(2023, 9, 10, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2188), 19, 6 },
                    { 50, 12, new DateTime(2023, 12, 1, 11, 26, 0, 895, DateTimeKind.Local).AddTicks(2191), 19, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "StoreId",
                keyValue: 10);
        }
    }
}
