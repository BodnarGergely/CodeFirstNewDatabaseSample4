using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstNewDatabaseSample4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
            using (var db = new BloggingContext())
            {

                /* var rows = from o in db.
                            select o;
                 foreach (var row in rows)
                 {
                     dataDb.Table.Remove(row);
                 }
                 db.SaveChanges();*/

                Console.WriteLine("Wait for init Tickets: ");
                var ticket = new Ticket { TicketId = 1, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 26, 12, 2, 15), StopOfValidity = (new DateTime(2015, 4, 26, 12, 2, 15)).AddMonths(1) };
                db.Tickets.Add(ticket);
                var ticket2 = new Ticket { TicketId = 2, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 15, 12, 2, 15) };
                db.Tickets.Add(ticket2);
                var ticket3 = new Ticket { TicketId = 3, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 15, 12, 2, 15) };
                db.Tickets.Add(ticket3);
                var ticket4 = new Ticket { TicketId = 4, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 26, 12, 2, 15) };
                db.Tickets.Add(ticket4);
                var ticket5 = new Ticket { TicketId = 5, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 17, 12, 2, 15) };
                db.Tickets.Add(ticket5);
                var ticket6 = new Ticket { TicketId = 6, Title = "Havi bérlet", StartOfValidity = new DateTime(2015, 4, 17, 12, 2, 15) };
                db.Tickets.Add(ticket6);


                Console.WriteLine("Wait for init Passangers: ");
                var passanger = new Passanger { PassangerId = 1, Name = "Bodnar Gergely", DateOfBirth = new DateTime(2008, 5, 1, 8, 30, 52), ZipCode = 1157, City = "Budapest", Address = "Korakas park 10", IdentityCard = "111MA"/*, PhoneNumber = "06704188991" */};
                db.Passangers.Add(passanger);
                var passanger2 = new Passanger { PassangerId = 2, Name = "Kis Pisti", DateOfBirth = new DateTime(1940, 5, 1, 8, 30, 52), ZipCode = 1117, City = "Budapest", Address = "Vegyész utca 10", IdentityCard = "131MA" };
                db.Passangers.Add(passanger2);
                var passanger3 = new Passanger { PassangerId = 3, Name = "Nagy Pisti", DateOfBirth = new DateTime(1910, 5, 1, 8, 30, 52), ZipCode = 2059, City = "Kistarcsa", Address = "Kossuth utca 10", IdentityCard = "545VJ" };
                db.Passangers.Add(passanger3);

                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Passangers
                            orderby b.Name
                            select b;

                Console.WriteLine("All Passangers:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                var query_t = from b in db.Tickets
                              orderby b.TicketId
                              select b;

                Console.WriteLine("All Tickets:");
                foreach (var item in query_t)
                {
                    Console.WriteLine(item.TicketId);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Passanger
    {
        [Key]
        public int PassangerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
       // public string PhoneNumber { get; set; }
        public string IdentityCard { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
        /* Passanger()
         {
             this.PassangerId = Guid.NewGuid();
         }*/
    }

    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string Title { get; set; }
        public DateTime StartOfValidity { get; set; }
        public DateTime StopOfValidity { get; set; }

        //public virtual Passanger Passangers { get; set; }
    }

    public class Inspector
    {
        [Key]
        public string InspectorId { get; set; }
        public string Name { get; set; }
    }/*

    public class Penalty
    {
        [Key]
        public string PenaltyId { get; set; }
        public string Name { get; set; }
    }*/

    public class BloggingContext : DbContext
    {
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
    }
}
