using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegaModel;

namespace VegaBusinessLayer
{
   public interface ICompanyRepository: IGenericRepository<CompanyModel>
    {
        IEnumerable<CompanyModel> GetLoginName();
        IList<CompanyModel> GetAllLogin();
    }
}
