using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;
using System.Data;
using System.Data.Entity;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
                var notes = SelectNotes();
                foreach (var note in notes)
                {
                    Console.WriteLine($"Título: {note.Title}, Content: {note.Content}, " +
                        $"Date Created: {note.DateCreated}, Category: {note.Categories.Name}");
                }
        }

        public static int InsertCategory(Categories category)
        {
            using (DBSchedule context = new DBSchedule())
            {
                context.Categories.Add(category);
                return context.SaveChanges();
            }
        }

        public static int InsertNote(Categories category)
        {
            using (DBSchedule context = new DBSchedule())
            {
                context.Categories.Add(category);
                return context.SaveChanges();
            }
        }

        public static List<Categories> SelectCategory()
        {
            using (DBSchedule context = new DBSchedule())
            {
                return context.Categories.ToList();
            }
        }

        public static List<Notes> SelectNotes()
        {
            using (DBSchedule context = new DBSchedule())
            {
                return context.Notes.Include(n => n.Categories).ToList();
            }
        }
    }
}
