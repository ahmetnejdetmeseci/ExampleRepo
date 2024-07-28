using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface IEmployeeService
    {
        IQueryable<EmployeeModel> Query();
        bool Add(EmployeeModel model);
        bool Delete(EmployeeModel model);
        bool Update(EmployeeModel model);
        bool DeleteAll(EmployeeModel model);
        bool Delete(int id);
    }
}
