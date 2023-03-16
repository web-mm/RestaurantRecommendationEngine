using RestaurantRecommendationEngine.Services;

namespace RestaurantRecommendationEngine.Controllers
{
    public class OrderController
    {
        private OrderService orderService;
        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        public void order(string userId, string restaurantId)
        {
            this.orderService.order(userId, restaurantId);
        }

    }
}
