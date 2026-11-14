using KZYHDotNetTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KZYHDotNetTraining.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db=new AppDbContext();
            var lst=db.Blogs.Where(x=> x.DeleteFlag==false).ToList();

            foreach(var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            var item= db.Blogs.Where(x => x.BlogId == id && x.DeleteFlag == false).FirstOrDefault();
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Create(string title, string author, string content)
        {
            BlogDataModel blog= new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
                DeleteFlag = false
            };
            AppDbContext db = new AppDbContext();
            db.Add(blog);
            var result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed");
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db= new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id && x.DeleteFlag == false);
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }

            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }

            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State=EntityState.Modified;
            var result = db.SaveChanges();

            Console.WriteLine(result==1 ? "Data updated successfully." : "Data update failed.");
        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x=> x.DeleteFlag==false && x.BlogId==id);
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }
            item.DeleteFlag = true;
            db.Entry(item).State = EntityState.Modified;
            var result = db.SaveChanges();

            Console.WriteLine(result==1 ? "Data deleted successfully." : "Data deletion failed.");
        }
    }
}
