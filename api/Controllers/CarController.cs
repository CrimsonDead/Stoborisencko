using datalayer.Models;
using datalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IRepository<Car> _carRepository;

        public CarController(ILogger<CarController> logger, IRepository<Car> carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        [HttpGet(Name = "Cars")]
        public ActionResult<IEnumerable<Car>> GetCars()
        {
            try
            {
                List<Car> cars = _carRepository.GetItems().ToList();
                if (cars.Count == 0)
                {
                    _logger.LogInformation("Car list is clear");
                    return Ok(cars);
                }
                else if (cars == null)
                {
                    _logger.LogInformation("Car list is null");
                    return Ok(cars);
                }
                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Car list");
                return BadRequest(ex);
            }
        }
        
    }
}