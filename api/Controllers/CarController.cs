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

        // TODO create method for get car by some properties.

        [HttpGet("getAll", Name = "GetCars")]
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
                _logger.LogInformation("Car list is successfully receive");
                return Ok(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Car list");
                return BadRequest(ex);
            }
        }

        [HttpGet("getById/{id}", Name = "Car")]
        public ActionResult<Car> GetCarById(int id)
        {
            try
            {
                Car car = _carRepository.GetItemById(id);
                if (car == null)
                {
                    _logger.LogInformation("Car item is null");
                    return Ok(car);
                }
                _logger.LogInformation("Car is successfully receive");
                return Ok(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Car");
                return BadRequest(ex);
            }
        }

        [HttpPost("createNew", Name = "NewCar")]
        public async Task<ActionResult> CreateCarAsync([FromForm] Car car)
        {
            try
            {
                await _carRepository.AddAsync(car);
                _logger.LogInformation("Car is successfully create");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Car");
                return BadRequest(ex);
            }
        }

        [HttpPut("change", Name = "ChangeCar")]
        public async Task<ActionResult> UpdateCarAsync([FromForm] Car newCar)
        {
            try
            {
                await _carRepository.UpdateAsync(newCar);
                Car car = _carRepository.GetItemById(newCar.Id);
                _logger.LogInformation("Car is successfully change");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Car");
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("delete", Name = "DeleteCar")]
        public async Task<ActionResult> DeleteCarAsync([FromForm] Car car)
        {
            try
            {
                await _carRepository.DeleteAsync(car);
                _logger.LogInformation("Car is successfully delete");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Car");
                return BadRequest(ex);
            }
        }
    }
}