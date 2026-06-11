using Microsoft.AspNetCore.Mvc;
using TravelAgency.BusinessLogic;

namespace TravelAgency.Api.Controller
{

    [Route("api/favorites")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavorite _fav;

        public FavoriteController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _fav = bl.GetFavoriteActions();
        }

        [HttpPost]
        public IActionResult Add(FavoriteDto dto)
            => Ok(_fav.AddFavorite(dto));

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
            => Ok(_fav.GetUserFavorites(userId));

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
            => Ok(_fav.RemoveFavorite(id));
    }

}