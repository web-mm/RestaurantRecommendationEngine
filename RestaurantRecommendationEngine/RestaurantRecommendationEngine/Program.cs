using System;
using System.Collections.Generic;
using System.Threading;
using RestaurantRecommendationEngine.Controllers;
using RestaurantRecommendationEngine.Models;
using RestaurantRecommendationEngine.Services;
using RestaurantRecommendationEngine.Services.Recommendation;
using RestaurantRecommendationEngine.Services.Recommendation.Strategies;

namespace RestaurantRecommendationEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Onboard some restaurants
                RestaurantService restaurantService = new RestaurantService();
                RestaurantController restaurantController = new RestaurantController(restaurantService);
                onboardRestaurants(restaurantController);
                List<Restaurant> availableRestaurants = restaurantController.getAvailableRestaurants();


                //Add a user
                UserService userService = new UserService();
                UserController userController = new UserController(userService);
                string userId = userController.addUser();


                //User orders on each restaurant
                OrderService orderService = new OrderService(userService, restaurantService);
                OrderController orderController = new OrderController(orderService);
                foreach (Restaurant restaurant in availableRestaurants)
                {
                    orderController.order(userId, restaurant.getId());
                }


                //Get User Preferences
                User user = userService.getUser(userId);
                Console.WriteLine("User Preferences:");
                Console.WriteLine("Primary Cuisine: " + user.getPrimaryCuisine());
                Console.WriteLine("Primary Cost Bracket: " + user.getPrimaryCostBracket());


                //recommend restaurants to the user
                RestaurantRecommendationService restaurantRecommendationService = new RestaurantRecommendationService(restaurantService, userService);
                RestaurantRecommendationController restaurantRecommendationController = new RestaurantRecommendationController(restaurantRecommendationService);
                restaurantRecommendationController.setRecommendationSize(10);


                List<RestaurantRecommendationStrategy> restaurantRecommendationStrategyList = formulateRecommendationStrategy();


                restaurantRecommendationController.clearRecommendationStrategies();
                restaurantRecommendationController.addRecommendationStrategies(restaurantRecommendationStrategyList);


                List<Restaurant> recommendations = restaurantRecommendationController.getRecommendations(userId);
                foreach (Restaurant recommendation in recommendations)
                {
                    Console.WriteLine("Recommendations: ");
                    Console.WriteLine(recommendation.ToString());
                }
            }
            catch(ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void onboardRestaurants(RestaurantController restaurantController)
        {
            try
            {
                restaurantController.onboardRestaurant(Cuisine.NorthIndian, CostBracket.High, 5, true);
                restaurantController.onboardRestaurant(Cuisine.SouthIndian, CostBracket.Low, 5, false);
                restaurantController.onboardRestaurant(Cuisine.NorthIndian, CostBracket.Medium, 3, false);
                restaurantController.onboardRestaurant(Cuisine.Chinese, CostBracket.High, 5, true);
                restaurantController.onboardRestaurant(Cuisine.NorthIndian, CostBracket.Low, 5, true);
                restaurantController.onboardRestaurant(Cuisine.NorthIndian, CostBracket.High, 3, false);
                restaurantController.onboardRestaurant(Cuisine.Chinese, CostBracket.Medium, 5, true);
                restaurantController.onboardRestaurant(Cuisine.SouthIndian, CostBracket.Low, 5, true);
                restaurantController.onboardRestaurant(Cuisine.NorthIndian, CostBracket.High, 3, false);
                Thread.Sleep(1000);
                restaurantController.onboardRestaurant(Cuisine.Chinese, CostBracket.Medium, 5, true);
                restaurantController.onboardRestaurant(Cuisine.SouthIndian, CostBracket.Low, 5, true);
                restaurantController.onboardRestaurant(Cuisine.Chinese, CostBracket.High, 3, false);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private static List<RestaurantRecommendationStrategy> formulateRecommendationStrategy()
        {
            List<RestaurantRecommendationStrategy> restaurantRecommendationStrategyList = new List<RestaurantRecommendationStrategy>();
            restaurantRecommendationStrategyList.Add(new FeaturedRestaurantStrategy());
            restaurantRecommendationStrategyList.Add(new PrimaryCuisineAndCostBracketWithRatingGreaterThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new PrimaryCuisineAndSecondaryCostBracketWithRatingGreaterThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new SecondaryCuisineAndPrimaryCostBracketWithRatingGreaterThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new NewRestaurantStrategy());
            restaurantRecommendationStrategyList.Add(new PrimaryCuisineAndCostBracketWithRatingLessThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new PrimaryCuisineAndSecondaryCostBracketWithRatingLessThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new SecondaryCuisineAndPrimaryCostBracketWithRatingLessThanThresholdStrategy());
            restaurantRecommendationStrategyList.Add(new AllRestaurantStrategy());
            return restaurantRecommendationStrategyList;
        }
    }
}
