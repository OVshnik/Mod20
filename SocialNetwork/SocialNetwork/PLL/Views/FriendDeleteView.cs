using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendDeleteView
    {
        FriendsService friendsService;
        public FriendDeleteView(FriendsService friendsService)
        {
            this.friendsService = friendsService;
        }

        public void Show(User user)
        {
            FriendAddData friendAddData = new (user);

            Console.Write("Введите почтовый адрес получателя: ");
            friendAddData.Email = Console.ReadLine();

            try
            {
                friendsService.DeleteFriend(friendAddData);

                SuccessMessage.Show($"Пользователь {user.FirstName} {user.LastName} удален из списка друзей");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }
        }
    }
}
