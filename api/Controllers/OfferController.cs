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

        [HttpGet(Name = "Offers")]
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
    }
}