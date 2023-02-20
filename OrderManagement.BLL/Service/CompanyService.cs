using OrderManagement.BLL.DTO;
using OrderManagement.DAL.Repository;
using OrderManagement.Entities;

namespace OrderManagement.BLL.Service
{
    public class CompanyService
    {
        private readonly CompanyRepository _repo;

        public CompanyService()
        {
            _repo = new CompanyRepository();
        }

        public IEnumerable<CompanyDTO> GetAll()
        {
            var companies = _repo.GetAll();

            var result = from company in companies
                         select new CompanyDTO()
                         {
                             CompanyId = company.Id,
                             CompanyName = company.CompanyName,
                             CompanyStatus = company.CompanyStatus,
                             OrderFinishTime = company.OrderFinishTime,
                             OrderStartTime = company.OrderStartTime,
                         };
            return result;
        }

        public CompanyDTO GetById(int id)
        {
            var company = _repo.GetById(id);
            if (company == null)
                return null;
            var dto = new CompanyDTO()
            {
                CompanyId = company.Id,
                CompanyName = company.CompanyName,
                CompanyStatus = company.CompanyStatus,
                OrderFinishTime = company.OrderFinishTime,
                OrderStartTime = company.OrderStartTime,
            };
            return dto;
        }

        public Company GetCompanyDomainById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddCompany(CompanyPostDTO company)
        {
            var companyToAdd = new Company()
            {
                CompanyName = company.CompanyName,
                CompanyStatus = company.CompanyStatus,
                OrderFinishTime = new TimeSpan(company.OrderFinishHour, company.OrderFinishMinute, 0),
                OrderStartTime = new TimeSpan(company.OrderStartHour, company.OrderStartMinute, 0),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.MinValue
            };

            _repo.Add(companyToAdd);
        }

        public bool UpdateCompany(int id, CompanyPostDTO company)
        {
            var companyToUpdate = _repo.GetById(id);
            if (companyToUpdate == null)
            {
                return false;
            }
            companyToUpdate.CompanyName = company.CompanyName;
            companyToUpdate.CompanyStatus = company.CompanyStatus;
            companyToUpdate.OrderFinishTime = new TimeSpan(company.OrderFinishHour, company.OrderFinishMinute, 0);
            companyToUpdate.OrderStartTime = new TimeSpan(company.OrderStartHour, company.OrderStartMinute, 0);
            companyToUpdate.UpdatedAt = DateTime.Now;

            _repo.Update(companyToUpdate);
            return true;
        }

        public void RemoveCompany(int id)
        {
            _repo.Delete(id);
        }
    }
}
