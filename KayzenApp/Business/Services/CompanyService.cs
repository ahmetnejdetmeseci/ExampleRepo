using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly Db _context;

        public CompanyService(Db context)
        {
            _context = context;
        }

        public IQueryable<CompanyModel> Query()
        {
            return _context.Companies.Select(c => new CompanyModel
            {
                Id = c.CompanyId,
                Name = c.CompanyName,
                RegistrationDate = c.RegistrationDate,
                TrialEndDate = c.TrialEndDate,
                IsActive = c.IsActive
            });
        }

        public async Task<bool> AddAsync(CompanyModel model)
        {
            var entity = new Company
            {
                CompanyName = model.Name,
                RegistrationDate = model.RegistrationDate,
                TrialEndDate = model.TrialEndDate,
                IsActive = model.IsActive
            };
            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CompanyModel model)
        {
            var entity = await _context.Companies.FindAsync(model.Id);
            if (entity == null)
            {
                return false;
            }
            entity.CompanyName = model.Name;
            entity.RegistrationDate = model.RegistrationDate;
            entity.TrialEndDate = model.TrialEndDate;
            entity.IsActive = model.IsActive;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CompanyModel> GetByIdAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null)
            {
                return null;
            }
            return new CompanyModel
            {
                Id = entity.CompanyId,
                Name = entity.CompanyName,
                RegistrationDate = entity.RegistrationDate,
                TrialEndDate = entity.TrialEndDate,
                IsActive = entity.IsActive
            };
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
