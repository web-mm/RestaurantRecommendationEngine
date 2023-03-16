using RestaurantRecommendationEngine.Services;

namespace RestaurantRecommendationEngine.Controllers
{
    public class UserController
    {
        private UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        public string addUser()
        {
            return userService.addUser();
        }

    }
}
