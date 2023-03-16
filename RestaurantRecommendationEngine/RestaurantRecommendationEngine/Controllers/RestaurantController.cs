using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;
using RestaurantRecommendationEngine.Services;


namespace RestaurantRecommendationEngine.Controllers
{
    public class RestaurantController
    {
        private RestaurantService restaurantService;
        public RestaurantController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        public void onboardRestaurant(Cuisine cuisine, CostBracket costBracket, float rating, bool isRecommended)
        {
            this.restaurantService.onboardRestaurant(cuisine, costBracket, rating, isRecommended);
        }

        public List<Restaurant> getAvailableRestaurants()
        {
            return this.restaurantService.getAvailableRestaurants();
        }
    }
}
