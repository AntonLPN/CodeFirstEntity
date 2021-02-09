using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstEntity
{
//    1.	Используя структуру таблиц из предыдущего домашнего задания, создайте модель при помощи CodeFfirst и выполните все задачи.
//2.	Используя структуру таблиц из предыдущего домашнего задания, создайте модель при помощи Code First Reverse Engineering и выполните все задачи.
//3.	Используя структуру таблиц из предыдущего домашнего задания, переименуйте названия всех таблиц – ‘Table + название таблицы’.
//4.	Используя структуру таблиц из предыдущего домашнего задания, примените все рассмотренные атрибуты.


    public class Context:DbContext
    {
        public Context() : base("LibraryCodeFirst") 
        {

        }



        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Client> Clients { get; set; }//добавлено при первой миграции

    }
    /// <summary>
    /// //Таблица авторов
    /// </summary>
    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }


        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
    /// <summary>
    /// Таблица книги
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(20)]//добавлено изменение размераа при первой миграции  с максимума на 20
        public string NameBook { get; set; }
        public int ClientsId { get; set; }
        public int AuthorsId { get; set; }

       
        public virtual Author Authors { get; set; }
        public virtual Client Client { get; set; }
    }
    /// <summary>
    /// Таблица клиентов
    /// </summary>
    public  class Client
    {
       
        public Client()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Dept { get; set; }

       
        public virtual ICollection<Book> Books { get; set; }
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context())
            {
                db.Authors.Add(new Author() { FirstName = "1", LastName = "1" });

                db.Clients.Add(new Client() { FirstName = "test", LastName = "test", Dept = "True" });
                db.Books.Add(new Book() { ClientsId = 1, AuthorsId = 1, NameBook = "firstMigration" });
                db.SaveChanges();
            }
        }
    }
}
