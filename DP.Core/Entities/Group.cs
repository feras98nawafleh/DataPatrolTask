namespace DP.Core.Entities
{
    public class Group
    {
        public string GroupId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
        public virtual ICollection<GroupPolicy> GroupPolicies { get; set; } = new List<GroupPolicy>();
    }
}