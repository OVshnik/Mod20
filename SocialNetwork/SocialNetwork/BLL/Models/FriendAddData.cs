using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class FriendAddData
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public FriendAddData(User user) 
        {
            this.Id = user.Id;
        }

    }
}
