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

        [HttpGet(Name = "Services")]
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
    }
}