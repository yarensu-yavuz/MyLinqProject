use NORTHWND

select *from Products--ToList()
select *from Categories
select *from Customers
select *from Products as k where k.UnitPrice=15-- db.Products.Where(k => k.UnitPrice == 15).ToList();



select *from Products as p
inner join Categories as c on p.CategoryID=c.CategoryID
--
select *from Products where ProductID=1--db.Products.Where(p => p.ProductID ==id).FirstOrDefault();

--update Products set ProductName='Portakal' where ProductID=1
