using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Bases
{
    public interface IImprovementService
    {
        IQueryable<ImprovementModel> Query();
        bool Add(ImprovementModel model);
        bool Update(ImprovementModel model);
        bool Delete(ImprovementModel model);
        bool Delete(int id);
    }
}
