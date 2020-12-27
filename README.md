# Gross Market App Project .NET 5.0

A Web Api project where a gross market can manage its products, customers, employees and suppliers.

Bir gross marketin kendi içinde ürünlerini, müşterilerini, çalışanlarını ve tedarikçilerini yönetebileceği bir Web Api projesi.


Kullandığım teknolojiler:


.NET 5.0 Core Web APi

Entity Framework Code First

MS SQL

Relational database

Layered Arch

UnitOfWork

Repository

------------------------------

# Kurulumu

appsettings.json dosyasında Connection String'i kendinize göre düzenleyiniz.

Powershell'den ya da Package Manager Console'dan update database yaparak database'i oluşturunuz.

Swagger: localhost/swagger/index.html

------------------------------

# Kullanımı

Kategoriler: 

GET /api/categories Tüm kategorileri getirir.

GET /api/categories/id ID'ye göre kategoriyi getirir.

GET /api/categories/id/products ID'ye göre o kategoriye ait ürünleri getirir.

POST /api/categories Yeni kategori ekler. Yeni kategori için CategoryName ve Note girilmesi zorunludur.

POST /api/categories/save-all Birden fazla kategori ekler. Yeni kategori için Kategori adı ve Note girilmesi zorunludur.

DELETE /api/categories/id ID'ye göre kategoriyi siler.

DELETE /api/categories/delete-all Birden fazla kategori ID'si body'e yazılarak silme işlemi yapılır.

UPDATE /api/categories Güncelleme için Id, CategoryName, Note gönderilmelidir.

------------------------------


Ürünler:

Diğerlerinden farklı olarak:

GET /api/products/id/category ID'ye gore ürünün ait olduğu kategoriyi verir.

GET /api/products/id/supplier ID'ye gore ürünün ait olduğu tedarikçiyi verir.

Güncelleme ve Ekleme işlemlerinde gerekli olan veriler: Id(güncellemede), ProductName, Stock, Price, CategoryId, SupplierId, Note 

------------------------------


Tedarikçiler:


Diğerlerinden farklı olarak:

GET /api/suppliers/id/products ID'ye gore tedarikçiye ait ürünleri verir.

Güncelleme ve Ekleme işlemlerinde gerekli olan veriler: Id(güncellemede), SupplierName, SupplierPhoneNumber, SupplierAddress, SupplierEmailAddress, Note

------------------------------

Çalışanlar:
/api/employees

Diğerlerinden farklı olarak: 

Güncelleme ve Ekleme işlemlerinde gerekli olan veriler: Id(güncellemede), EmployeeName, EmployeeAge, EmployeeSalary, EmployeeAddress, EmployeePhoneNumber, EmployeeJob

------------------------------


Üye Müşteriler: /api/membercustomers

Diğerlerinden farklı olarak: 

Güncelleme ve Ekleme işlemlerinde gerekli olan veriler: Id(güncellemede), MemberCustomerName, MemberCustomerAge, MemberCustomerPhoneNumber, Note
# GrossMarketApi
