using System;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services.Recommendation.Strategies
{
    public class PrimaryCuisineAndCostBracketWithRatingGreaterThanThresholdStrategy : RestaurantRecommendationStrategy
    {
        private static readonly float rating = 4F;
        public List<Restaurant> recommendRestaurants(List<Restaurant> restaurants, Cuisine primaryCuisine, CostBracket primaryCostBracket)
        {
            List<Restaurant> recommendations = new List<Restaurant>();
            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.getCuisine().Equals(primaryCuisine) &&
                restaurant.getCostBracket().Equals(primaryCostBracket) && restaurant.getRating() >= rating)
                {
                    recommendations.Add(restaurant);
                }
            }
            return recommendations;
        }
    }
}
