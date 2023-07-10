using Points.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Points.Interfaces
{
    public interface IRepository
    {
        Task<List<Point>> GetPointsAsync();
        Task<bool> DeletePointByIdAsync(int pointId);
    }
}