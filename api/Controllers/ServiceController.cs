using datalayer.Models;
using datalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IRepository<Service> _serviceRepository;
        public ServiceController(ILogger<ServiceController> logger, IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
            _logger = logger;

        }

        [HttpGet("getAll", Name = "GetServices")]
        public ActionResult<IEnumerable<Service>> GetServices()
        {
            try
            {
                List<Service> service = _serviceRepository.GetItems().ToList();
                if (service.Count == 0)
                {
                    _logger.LogInformation("Service list is clear");
                    return Ok(service);
                }
                else if (service == null)
                {
                    _logger.LogInformation("Service list is null");
                    return Ok(service);
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Service list");
                return BadRequest(ex);
            }
        }

        [HttpGet("getById/{id}", Name = "Service")]
        public ActionResult<Car> GetCarById(int id)
        {
            try
            {
                Service service = _serviceRepository.GetItemById(id);
                if (service == null)
                {
                    _logger.LogInformation("Service item is null");
                    return Ok(service);
                }
                _logger.LogInformation("Service is successfully receive");
                return Ok(service);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Service");
                return BadRequest(ex);
            }
        }

        [HttpPost("createNew", Name = "NewService")]
        public async Task<ActionResult> CreateCarAsync([FromForm] Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                _logger.LogInformation("Service is successfully create");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Service");
                return BadRequest(ex);
            }
        }

        [HttpPut("change", Name = "ChangeService")]
        public async Task<ActionResult> UpdateCarAsync([FromForm] Service newService)
        {
            try
            {
                await _serviceRepository.UpdateAsync(newService);
                Service service = _serviceRepository.GetItemById(newService.Id);
                _logger.LogInformation("Service is successfully change");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Service");
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("delete", Name = "DeleteService")]
        public async Task<ActionResult> DeleteCarAsync([FromForm] Service service)
        {
            try
            {
                await _serviceRepository.DeleteAsync(service);
                _logger.LogInformation("Service is successfully delete");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Service");
                return BadRequest(ex);
            }
        }

    }
}