using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BOL;
using DAL.Repository;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, IRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<IEnumerable<customerDto>> GetAsync()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<customerDto>>(customers);
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<customerDto> GetByIdAsync(int id)
        {
            Customer customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<Customer, customerDto>(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] customerDto customerDto)
        {
            try
            {
                Customer customer = _mapper.Map<customerDto, Customer>(customerDto);
                await _customerRepository.InsertAsync(customer);
                return StatusCode(StatusCodes.Status201Created, customerDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
