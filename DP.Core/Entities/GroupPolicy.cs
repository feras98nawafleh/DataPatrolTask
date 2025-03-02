namespace DP.Core.Entities
{
    public class GroupPolicy
    {
        public string GroupPolicyId { get; set; }
        public string GroupId { get; set; }
        public string PolicyId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
