using datalayer.Models;
using datalayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly IRepository<Offer> _offerRepository;
        public OfferController(ILogger<OfferController> logger, IRepository<Offer> offerRepository)
        {
            _offerRepository = offerRepository;
            _logger = logger;

        }

        // TODO create method for get offer by some properties.

        [HttpGet("getAll", Name = "GetOffers")]
        public ActionResult<IEnumerable<Offer>> GetOffers()
        {
            try
            {
                List<Offer> offer = _offerRepository.GetItems().ToList();
                if (offer.Count == 0)
                {
                    _logger.LogInformation("Offer list is clear");
                    return Ok(offer);
                }
                else if (offer == null)
                {
                    _logger.LogInformation("Offer list is null");
                    return Ok(offer);
                }
                return Ok(offer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Offer list");
                return BadRequest(ex);
            }
        }

        [HttpGet("getById/{id}", Name = "Offer")]
        public ActionResult<Car> GetOfferById(int id)
        {
            try
            {
                Offer offer = _offerRepository.GetItemById(id);
                if (offer == null)
                {
                    _logger.LogInformation("Offer item is null");
                    return Ok(offer);
                }
                _logger.LogInformation("Offer is successfully receive");
                return Ok(offer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Offer");
                return BadRequest(ex);
            }
        }

        [HttpPost("createNew", Name = "NewOffer")]
        public async Task<ActionResult> CreateOfferAsync([FromForm] Offer offer)
        {
            try
            {
                await _offerRepository.AddAsync(offer);
                _logger.LogInformation("Offer is successfully create");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create Offer");
                return BadRequest(ex);
            }
        }

        [HttpPut("change", Name = "ChangeOffer")]
        public async Task<ActionResult> UpdateOfferAsync([FromForm] Offer newOffer)
        {
            try
            {
                await _offerRepository.UpdateAsync(newOffer);
                Offer offer = _offerRepository.GetItemById(newOffer.Id);
                if (offer == newOffer)
                {
                    _logger.LogInformation("Offer is successfully change");
                    return Ok();
                }
                else 
                {
                    _logger.LogInformation("Failed to change Offer");
                    return Ok(null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update Offer");
                return BadRequest(ex);
            }
        }
        
        [HttpDelete("delete", Name = "DeleteOffer")]
        public async Task<ActionResult> DeleteOfferAsync([FromForm] Offer car)
        {
            try
            {
                await _offerRepository.DeleteAsync(car);
                _logger.LogInformation("Offer is successfully delete");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Offer");
                return BadRequest(ex);
            }
        }

    }
}