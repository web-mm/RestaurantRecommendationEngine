using System;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services.Recommendation.Strategies
{
    public class AllRestaurantStrategy : RestaurantRecommendationStrategy
    {
        public List<Restaurant> recommendRestaurants(List<Restaurant> restaurants, Cuisine primaryCuisine, CostBracket primaryCostBracket)
        {
            return restaurants;
        }
    }
}
