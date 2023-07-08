using Microsoft.EntityFrameworkCore;
using Points.Interfaces;
using Points.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Points.Repositories
{
    public class Repository : IRepository
    {
        private DatabaseContext dbContext;

        public Repository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Point> GetPoints()
        {
            var points = dbContext.Points
                .Include(x => x.Comments)
                .ToList();
            return points; 
        }

        public bool DeletePointById(int id)
        {
            var existingPoint = dbContext.Points.Where(x => x.Id == id).FirstOrDefault();
            if(existingPoint != null)
            {
                dbContext.Points.Remove(existingPoint);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}