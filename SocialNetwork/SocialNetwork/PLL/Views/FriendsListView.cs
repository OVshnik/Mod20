using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsListView
    {
        FriendsService friendsService;
        public FriendsListView(FriendsService friendsService)
        {
            this.friendsService = friendsService;
        }
        public void Show()
        {
            try
            {
                var friendsList = friendsService.GetFriendsListInUsers();
                if (friendsList !=null)
                {
                    Console.WriteLine("Друзья:");
                    foreach (var friend in friendsList)
                    {
                        Console.WriteLine("{0} {1}, {2}", friend.FirstName, friend.LastName, friend.Email);
                    }
                }
                else 
                {
                    Console.WriteLine("Список друзей пуст");
                }
            }
            catch (Exception) 
            {
                Console.WriteLine("Не удалось получить список друзей");
            }
        }
    }
}
