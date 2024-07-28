using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly Db _db;

        public DepartmentService(Db db)
        {
            _db = db;
        }
        public bool Add(DepartmentModel model)
        {
            try
            {
                // Aynı şirket altında aynı ada sahip bir departmanın var olup olmadığını kontrol et
                bool departmentExists = _db.Departments.Any(d => d.DepartmentName == model.Name && d.CompanyId == model.CompanyId);

                if (departmentExists)
                {
                    // Departman zaten mevcut, ekleme yapılmayacak
                    return false;
                }

                var department = new Department
                {
                    DepartmentName = model.Name,
                    CompanyId = model.CompanyId
                };

                _db.Departments.Add(department);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                // Hata durumunda exception loglanabilir
                return false;
            }
        }

        public bool Delete(DepartmentModel model)
        {
            return Delete(model.Id);
        }

        public bool Delete(int id)
        {
            try
            {
                var department = _db.Departments.Find(id);
                if (department != null)
                {
                    _db.Departments.Remove(department);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                // Log exception here
                return false;
            }
        }

        public bool DeleteAll(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DepartmentModel> Query()
        {
            return _db.Departments
                .Include(d => d.Company)
                .Include(d => d.Employees)
                .Include(d => d.Improvements)
                .Select(d => new DepartmentModel
                {
                    Id = d.DepartmentId,
                    Name = d.DepartmentName,
                    CompanyId = d.CompanyId,
                    ComanyOutput = d.Company.CompanyName,
                    EmployeeOutput = string.Join(", ", d.Employees.Select(e => e.EmployeeName)),
                    ImprovementOutput = string.Join(", ", d.Improvements.Select(i => i.Description))
                });
        }

        public bool Update(DepartmentModel model)
        {
            try
            {
                var department = _db.Departments.Find(model.Id);
                if (department != null)
                {
                    department.DepartmentName = model.Name;
                    department.CompanyId = model.CompanyId;
                    // If you need to update employees or improvements, handle them here

                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                // Log exception here
                return false;
            }
        }
    }
}
