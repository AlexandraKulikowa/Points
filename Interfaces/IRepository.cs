using Points.Models;
using System.Collections.Generic;

namespace Points.Interfaces
{
    public interface IRepository
    {
        List<Point> GetPoints();
        bool DeletePointById(int id);

    }
}
