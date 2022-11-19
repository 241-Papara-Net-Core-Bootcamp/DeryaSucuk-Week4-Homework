using PaparaThirdWeek.Data.Abstracts;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Services.Concretes
{
    public class CompanyServices : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyServices(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Add(Company company)
        {
            _companyRepository.Add(company);
        }

        public IEnumerable<Company> GetAll()
        {
            return _companyRepository.Get().ToList();
        }

        public IEnumerable<Company> GetById(int id)
        {
            return _companyRepository.GetById(id);
        }

        public void Update(Company company)
        {
            _companyRepository.Update(company);
        }
        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
        }

        public void Remove(Company company)
        {
            _companyRepository.Remove(company);
        }
    }
}
