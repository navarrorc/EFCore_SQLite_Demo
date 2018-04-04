using System;
using System.Linq;
using EFCore_SQLite_Demo.Models;

namespace EFCore_SQLite_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add Todo
            //AddTodo();

            // Edit Todo
            //EditTodo();

            // Delete Todo
            //DeleteTodo();

            // List Todos
            ListTodo();

            Console.ReadLine();
        }

        private static void DeleteTodo()
        {
            using (var db = new TasksContext())
            {
                var todo = db.Tasks.SingleOrDefault(t => t.Title.Contains("trash!!!"));
                db.Remove(todo);
                db.SaveChanges();
            }
        }

        private static void EditTodo()
        {
            using (var db = new TasksContext())
            {
                var todo = db.Tasks.SingleOrDefault(t => t.Title.Contains("trash!!!"));
                todo.Completed = true;
                db.Update(todo);
                db.SaveChanges();
            }
        }

        private static void AddTodo()
        {
            var todo = new Tasks
            {
                Completed = false,
                Title = "Pay internet bill"
            };

            using (var db = new TasksContext())
            {
                db.Tasks.Add(todo);
                db.SaveChanges();
            }
        }

        private static void ListTodo()
        {
            using (var db = new TasksContext())
            {
                db.Tasks.ToList().ForEach(t => Console.WriteLine($"{t.ID}. {t.Title} ({t.Completed})"));
            }
        }
    }
}
