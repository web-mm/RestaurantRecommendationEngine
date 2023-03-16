using System;
using System.Linq;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services
{
    public class RestaurantService
    {
        private Dictionary<string, Restaurant> restaurants;
        public RestaurantService()
        {
            this.restaurants = new Dictionary<string, Restaurant>();
        }
        public void onboardRestaurant(Cuisine cuisine, CostBracket costBracket, float rating, bool isRecommended)
        {
            Restaurant restaurant = new Restaurant(cuisine, costBracket, rating, isRecommended);
            restaurants.Add(restaurant.getId(), restaurant);
        }
        public Restaurant getRestaurant(string id)
        {
            return this.restaurants[id];
        }
        public List<Restaurant> getAvailableRestaurants()
        {
            List<Restaurant> restaurantList  = new List<Restaurant>();
            
            foreach(var item in restaurants.Values)
            {
                restaurantList.Add(item);
            }
            return restaurantList;
        }

    }
}
