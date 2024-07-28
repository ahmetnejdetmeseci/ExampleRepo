using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface IDepartmentService
    {
        IQueryable<DepartmentModel> Query();
        bool Add(DepartmentModel model);
        bool Update(DepartmentModel model);
        bool Delete(DepartmentModel model);
        bool DeleteAll(DepartmentModel model);
        bool Delete(int id);
    }
}
