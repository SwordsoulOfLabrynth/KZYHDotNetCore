using KZYHDotNetTraining.ConsoleApp;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();
//Console.ReadKey();

//C# <=> Database

//ADO.NET   /old
//Dapper    (ORM) object relational mapping
//EFCore    /Entity Framework Core (ORM) 

//C# => sql query => database

//nuget (package)

AdoDotNetExample adoDotNetExample=new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Update();
//adoDotNetExample.Delete();

DapperExample dapperExample= new DapperExample();
//dapperExample.Read();
//dapperExample.Create("asdas","dasaw","asdwfkws");
//dapperExample.Edit(1);
//dapperExample.Edit(2);
//dapperExample.Update(1, "Hello", "Hi", "asdwfkws");
//dapperExample.Delete(3);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(1);
//eFCoreExample.Create("TestBook", "TestAuthor", "TestContent");
//eFCoreExample.Update(4, "Testing", "Author", "TestContent");
eFCoreExample.Delete(5);




