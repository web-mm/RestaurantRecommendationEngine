using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;
using RestaurantRecommendationEngine.Services.Recommendation;
using RestaurantRecommendationEngine.Services.Recommendation.Strategies;

namespace RestaurantRecommendationEngine.Controllers
{
    public class RestaurantRecommendationController
    {
        private RestaurantRecommendationService restaurantRecommendationService;

        public RestaurantRecommendationController(RestaurantRecommendationService restaurantRecommendationService)
        {
            this.restaurantRecommendationService = restaurantRecommendationService;
        }

        public List<Restaurant> getRecommendations(string userId)
        {
            return this.restaurantRecommendationService.getRecommendations(userId);
        }

        public void setRecommendationSize(int size)
        {
            this.restaurantRecommendationService.setRecommendationSize(size);
        }

        public void addRecommendationStrategies(List<RestaurantRecommendationStrategy> recommendationStrategies)
        {
            this.restaurantRecommendationService.addRecommendationStrategies(recommendationStrategies);
        }

        public void clearRecommendationStrategies()
        {
            this.restaurantRecommendationService.clearRecommendationStrategies();
        }

    }
}
