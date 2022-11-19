using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Data.Dapper;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        
        private readonly IMapper mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(CompanyDto company)
        {
            var mappedCompany=mapper.Map<Company>(company);//dto olarak gelen modelim company olarak dönüşecek
            companyService.Add(mappedCompany);
            return Ok();
        }

        [HttpGet("Companies")]
        public IActionResult Get()
        {
            var result = companyService.GetAll();
            var compandyDto=mapper.Map<List<CompanyDto>>(result.ToList());
            return Ok(compandyDto);   
        }


        [HttpGet("GetAllCompanies")]
        public IActionResult GetAll()
        {
            var result = companyService.GetAll();
            var compandyDto = mapper.Map<List<CompanyDto>>(result.ToList());
            return Ok(compandyDto);
        }
  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = companyService.GetById(id);
            if (result.Any())
            {
                var compandyDto = mapper.Map<List<CompanyDto>>(result.ToList());
                return Ok(compandyDto);
            }
            
            return BadRequest("Aranılan id bulunmamakda");

        }

        [HttpPut("Update")]
        public IActionResult Update(Company campany)
        {
            companyService.Update(campany);
            return Ok(campany);
        }

        [HttpDelete("id")]
        public IActionResult Delete(Company company, int id)
        {
            if (company.Id==id)
            {
                companyService.Delete(company);
                return Ok();
            }
            return NotFound("id bulunamadı");
        }
    }
}
