using System;
using System.Linq;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;
using RestaurantRecommendationEngine.Services.Recommendation.Strategies;

namespace RestaurantRecommendationEngine.Services.Recommendation
{
    public class RestaurantRecommendationService
    {
        private List<RestaurantRecommendationStrategy> recommendationStrategies;
        private RestaurantService restaurantService;
        private UserService userService;
        private int recommendationSize;

        public RestaurantRecommendationService(RestaurantService restaurantService, UserService userService)
        {
            recommendationStrategies = new List<RestaurantRecommendationStrategy>();
            recommendationSize = 0;
            this.restaurantService = restaurantService;
            this.userService = userService;
        }
        public void addRecommendationStrategies(List<RestaurantRecommendationStrategy> recommendationStrategies)
        {
            this.recommendationStrategies.AddRange(recommendationStrategies);
        }
        public void setRecommendationSize(int recommendationSize)
        {
            this.recommendationSize = recommendationSize;
        }
        public List<Restaurant> getRecommendations(string userId)
        {
            User user = userService.getUser(userId);
            List<Restaurant> restaurants = restaurantService.getAvailableRestaurants();
            Cuisine primaryCuisine = user.getPrimaryCuisine();
            CostBracket primaryCostBracket = user.getPrimaryCostBracket();

            HashSet<Restaurant> recommendations = new HashSet<Restaurant>();

            foreach (RestaurantRecommendationStrategy recommendationStrategy in recommendationStrategies)
            {
                if (recommendations.Count > recommendationSize)
                {
                    break;
                }
                List<Restaurant> recommendedRestaurants = recommendationStrategy.recommendRestaurants(restaurants, primaryCuisine, primaryCostBracket);

                foreach (Restaurant rest in recommendedRestaurants)
                {
                    recommendations.Add(rest);
                }
            }
            return recommendations.ToList().GetRange(0, recommendationSize - 1);
        }

        public void clearRecommendationStrategies()
        {
            this.recommendationStrategies = new List<RestaurantRecommendationStrategy>();
        }

    }
}
