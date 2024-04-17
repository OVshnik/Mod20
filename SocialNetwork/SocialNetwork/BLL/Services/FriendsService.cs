using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendsService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;
        UserService userService;
        public FriendsService() 
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
            userService = new UserService();
        }
        public void AddFriend(FriendAddData friendAddData)
        {
            if (String.IsNullOrEmpty(friendAddData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendAddData.Email));

            var frUser = userService.FindByEmail(friendAddData.Email);

            friendAddData.Id++;

            var frEntity = new FriendEntity()
            {
                user_id = frUser.Id,
                friend_id = friendAddData.Id
            };

            Console.ForegroundColor= ConsoleColor.Red;

            if (this.friendRepository.Create(frEntity) == 0)
                throw new Exception("Данный пользователь уже добавлен в список друзей");

            Console.ForegroundColor=ConsoleColor.Gray;

        }
        public IEnumerable<User> GetFriendsListInUsers()
        {
            var users = userRepository.FindAll().ToList();
            
            var friends = friendRepository.FindAll().ToList();

            var listFriends = users.Join(friends, u => u.id, f => f.user_id, (u, f) => new User { FirstName = u.firstname, LastName = u.lastname, Email = u.email });

            return listFriends;
        }
        public void DeleteFriend(FriendAddData friendAddData)
        {
            if (String.IsNullOrEmpty(friendAddData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendAddData.Email));

            var user = userService.FindByEmail(friendAddData.Email);

            var friends = friendRepository.FindAllByUserId(user.Id).ToList();

            foreach (var friend in friends)
            {
                if(friend.user_id==user.Id) 
                {
                    friendRepository.Delete(friend.id);
                }
                throw new Exception();
            }

        }

    }
}
