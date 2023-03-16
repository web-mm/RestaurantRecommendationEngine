using System;
using System.Collections.Generic;

namespace RestaurantRecommendationEngine.Models
{
    public class User
    {
        private string id;
        private Dictionary<Cuisine, int> cuisineTracking;
        private Dictionary<CostBracket, int> costTracking;

        private Cuisine primaryCuisine;
        private CostBracket primaryCostBracket;

        public User()
        {
            this.id = System.Guid.NewGuid().ToString();
            cuisineTracking = new Dictionary<Cuisine, int>();
            costTracking = new Dictionary<CostBracket, int>();
        }
        public string getId()
        {
            return id;
        }
        public void addCostPreference(CostBracket costBracket)
        {
            this.costTracking[costBracket] =  0;
            this.costTracking[costBracket] = costTracking[costBracket] + 1;


            if (primaryCostBracket == null || costTracking.ContainsKey(costBracket) && costTracking.ContainsKey(primaryCostBracket) && costTracking[costBracket] > costTracking[primaryCostBracket])
            {
                primaryCostBracket = costBracket;
            }
        }

        public void addCuisinePreference(Cuisine cuisine)
        {
            this.cuisineTracking[cuisine] =  0;
            this.cuisineTracking[cuisine] = cuisineTracking[cuisine] + 1;


            if (primaryCuisine == null || cuisineTracking.ContainsKey(cuisine) && cuisineTracking.ContainsKey(primaryCuisine) && cuisineTracking[cuisine] > cuisineTracking[primaryCuisine])
            {
                primaryCuisine = cuisine;
            }
        }

        public Cuisine getPrimaryCuisine()
        {
            return primaryCuisine;
        }

        public CostBracket getPrimaryCostBracket()
        {
            return primaryCostBracket;
        }

    }
}
