using System;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services.Recommendation.Strategies
{
    public class FeaturedRestaurantStrategy : RestaurantRecommendationStrategy
    {
        public List<Restaurant> recommendRestaurants(List<Restaurant> restaurants, Cuisine primaryCuisine, CostBracket primaryCostBracket)
        {
            List<Restaurant> recommendations = new List<Restaurant>();
            foreach (Restaurant restaurant in restaurants)
            {
                if (restaurant.getIsRecommended() &&
                restaurant.getCuisine().Equals(primaryCuisine) &&
                restaurant.getCostBracket().Equals(primaryCostBracket))
                {
                    recommendations.Add(restaurant);
                }
            }


            if (recommendations.Count == 0)
            {
                foreach (Restaurant restaurant in restaurants)
                {
                    if (restaurant.getIsRecommended() &&
                    (restaurant.getCuisine().Equals(primaryCuisine) ||
                    restaurant.getCostBracket().Equals(primaryCostBracket)))
                    {
                        recommendations.Add(restaurant);
                    }
                }
            }
            return recommendations;
        }

    }
}
