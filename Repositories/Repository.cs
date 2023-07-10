using Microsoft.EntityFrameworkCore;
using Points.Database;
using Points.Interfaces;
using Points.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Points.Repositories
{
    public class Repository : IRepository
    {
        private DatabaseContext dbContext;

        public Repository(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Point>> GetPointsAsync()
        {
            var points = await dbContext.Points
                .Include(x => x.Comments)
                .ToListAsync();
            return points;
        }
        
        public async Task<bool> DeletePointByIdAsync(int pointId)
        {
            var existingPoint = await dbContext.Points
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.PointId == pointId);

            if (existingPoint != null)
            {
                dbContext.Points.Remove(existingPoint);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}