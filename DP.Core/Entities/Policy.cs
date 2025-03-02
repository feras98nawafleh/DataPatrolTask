namespace DP.Core.Entities
{
    public class Policy
    {
        public string PolicyId { get; set; }
        public string PolicyName { get; set; }
        public bool IsDefault { get; set; }
        public int PolicyType { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public virtual ICollection<GroupPolicy> GroupPolicies { get; set; } = new List<GroupPolicy>();
    }
}