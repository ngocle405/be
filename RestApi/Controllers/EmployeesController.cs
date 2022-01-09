using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Data.Entities;
using RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employeeService.GetAll());
        }
        [HttpGet("{employeeId}")]
        public IActionResult GetById(int employeeId)
        {
           var entities = _employeeService.GetById(employeeId);
            return StatusCode (200, entities);
        }
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            try
            {
                 _employeeService.Add(employee);
                return StatusCode(201,1);
            }
            catch(Exception ex)
            {
                var rs = new
                {
                    useDev=ex.Message,

                };
                return StatusCode(500,rs);
            }
        }
        [HttpPut("{employeeId}")]
        public IActionResult Update(int employeeId, Employee employee)
        {
            try
            {
                _employeeService.Update(employeeId,employee);
                return StatusCode(200, 1);
            }
            catch (Exception ex)
            {
                var rs = new
                {
                    useDev = ex.Message,

                };
                return StatusCode(500, rs);
            }
        }
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(int employeeId)
        {
            _employeeService.Delete(employeeId);
            return StatusCode(200, 1);
        }
    }
}
