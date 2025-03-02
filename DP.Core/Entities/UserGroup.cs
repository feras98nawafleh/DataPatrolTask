namespace DP.Core.Entities
{
    public class UserGroup
    {
        public string UserId { get; set; }
        public string GroupId { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
}
