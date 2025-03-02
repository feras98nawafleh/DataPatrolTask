using System.ComponentModel.DataAnnotations;

namespace DP.Core.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }
        public bool IsEnabled { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual ICollection<UserRequest> Requests { get; set; } = new List<UserRequest>();
        public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();

        public class UserBuilder : EntityBuilder<UserBuilder, User>
        {
            public UserBuilder SetUserId(string userId) => SetProperty((u, val) => u.UserId = val, userId);
            public UserBuilder SetUsername(string username) => SetProperty((u, val) => u.Username = val, username);
            public UserBuilder SetIsEnabled(bool isEnabled) => SetProperty((u, val) => u.IsEnabled = val, isEnabled);
            public UserBuilder SetPasswordHash(string passwordHash) => SetProperty((u, val) => u.PasswordHash = val, passwordHash);
            public UserBuilder SetCreationDate(DateTime creationDate) => SetProperty((u, val) => u.CreatedDateTime = val, creationDate);

        }
    }
}