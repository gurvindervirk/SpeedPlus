using System.Collections.Generic;
using System.Linq;
using VegaModel;

namespace VegaBusinessLayer
{
    public class CompanyRepository : GenericRepository<CompanyModel>, ICompanyRepository
    {
        public IList<CompanyModel> GetAllLogin()
        {
            var companyList = from company in _context.CompanyModels select company;
            var companyNames = companyList.ToList<CompanyModel>();
            return companyNames;
        }
        public IEnumerable<CompanyModel> GetLoginName()
        {
            throw new System.NotImplementedException();
        }
    }
}
