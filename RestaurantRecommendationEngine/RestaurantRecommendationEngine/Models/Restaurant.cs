using System;

namespace RestaurantRecommendationEngine.Models
{
    public class Restaurant
    {
        private string id;
        private Cuisine cuisine;
        private CostBracket costBracket;
        private float rating;
        private bool isRecommended;
        private DateTime onboardedTime;

        public Restaurant(Cuisine cuisine, CostBracket costBracket, float rating, bool isRecommended)
        {
            this.id = System.Guid.NewGuid().ToString();
            this.cuisine = cuisine;
            this.costBracket = costBracket;
            this.rating = rating;
            this.isRecommended = isRecommended;
            this.onboardedTime = new DateTime();
        }

        public string getId()
        {
            return id;
        }

        public Cuisine getCuisine()
        {
            return cuisine;
        }
        public CostBracket getCostBracket()
        {
            return costBracket;
        }

        public bool getIsRecommended()
        {
            return isRecommended;
        }
        public float getRating()
        {
            return rating;
        }
        public DateTime getOnboardedTime()
        {
            return onboardedTime;
        }
        public override string ToString()
        {
            return "Restaurant{" +
            "id='" + id + '\'' +
            ", cuisine=" + cuisine +
            ", costBracket=" + costBracket +
            ", rating=" + rating +
            ", isRecommended=" + isRecommended +
            ", onboardedTime=" + onboardedTime +
            '}';
        }
    }
}
