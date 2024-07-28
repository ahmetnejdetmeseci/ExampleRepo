using Business.Models;
using Business.Results.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface ICompanyModel
    {
        IQueryable<CompanyModel> Query();

        Result Add(CompanyModel model);

        Result Update(CompanyModel model);

        Result Delete(int id);
    }
}
