using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories

{
    public interface IFriendRepository
    {
        int Create(FriendEntity friendEntity);
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        public IEnumerable<FriendEntity> FindAll();

        int Delete(int id);
    }
}