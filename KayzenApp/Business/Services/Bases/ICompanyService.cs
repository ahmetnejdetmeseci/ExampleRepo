using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface ICompanyService
    {
        IQueryable<CompanyModel> Query();
        Task<bool> AddAsync(CompanyModel model);
        Task<bool> UpdateAsync(CompanyModel model);
        Task<bool> DeleteAsync(int id);
        Task<CompanyModel> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
