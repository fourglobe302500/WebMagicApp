using MagicApp.Stores;
using MagicApp.Stores.UserStore;
using System.ComponentModel.DataAnnotations;

namespace MagicApp.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void ValidSubmit(IStore<UserState> user)
        {
            ((UserStore)user).ChangeState(Name, null);
        }
    }
}