using System;
using System.Linq;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services.Recommendation.Strategies
{
    public class NewRestaurantStrategy : RestaurantRecommendationStrategy
    {
        private static readonly int count = 4;
        public List<Restaurant> recommendRestaurants(List<Restaurant> restaurants, Cuisine primaryCuisine, CostBracket primaryCostBracket)
        {
            restaurants.Sort((o1, o2) => o2.getOnboardedTime().CompareTo(o1.getOnboardedTime()));
            return restaurants.GetRange(0, count);
        }

    }
}
