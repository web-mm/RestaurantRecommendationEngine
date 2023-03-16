using System;
using System.Collections.Generic;
using RestaurantRecommendationEngine.Models;

namespace RestaurantRecommendationEngine.Services
{
    public class UserService
    {
        Dictionary<string, User> users;

        public UserService()
        {
            this.users = new Dictionary<string, User>();
        }

        public string addUser()
        {
            User user = new User();
            users.Add(user.getId(), user);
            return user.getId();
        }

        public User getUser(string userId)
        {
            return users[userId];
        }

        public void trackUserPreferences(string userId, Cuisine cuisine, CostBracket costBracket)
        {
            User user = users[userId];
            user.addCostPreference(costBracket);
            user.addCuisinePreference(cuisine);
        }
    }
}
