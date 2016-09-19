using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;


namespace WebApplication1.Models
{
    public class EFItemRepository : IItemRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public EFItemRepository(ApplicationDbContext connection = null)
        {
            if (connection == null)
            {
                this.db = new ApplicationDbContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Item> Items
        { get { return db.Item; } }

        public Item Save(Item item)
        {
            db.Item.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            db.Item.Remove(item);
            db.SaveChanges();
        }

    }
      
}
