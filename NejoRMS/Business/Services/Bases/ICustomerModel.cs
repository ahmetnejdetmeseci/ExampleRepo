using Business.Models;
using Business.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface ICustomerModel
    {
        IQueryable<CustomerModel> Query();

        Result Add(CustomerModel model);

        Result Update(CustomerModel model);

        Result Delete(int id);
    }
}
