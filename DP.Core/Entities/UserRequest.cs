using static DP.Core.Enums.Enums;
namespace DP.Core.Entities
{
    public class UserRequest
    {
        public long RequestId { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestDateTime { get; set; }
        public int RequestCode { get; set; }
        public string Description { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CompletionDateTime { get; set; }
        public virtual User RequesterUser { get; set; }

        public class UserRequestBuilder : EntityBuilder<UserRequestBuilder, UserRequest>
        {
            public UserRequestBuilder SetRequestedBy(string requestedBy) => SetProperty((u, val) => u.RequestedBy = val, requestedBy);
            public UserRequestBuilder SetRequestDateTime(DateTime requestDateTime) => SetProperty((u, val) => u.RequestDateTime = val, requestDateTime);
            public UserRequestBuilder SetRequestCode(int requestCode) => SetProperty((u, val) => u.RequestCode = val, requestCode);
            public UserRequestBuilder SetDescription(string description) => SetProperty((u, val) => u.Description = val, description);
            public UserRequestBuilder SetStatus(RequestStatus status) => SetProperty((u, val) => u.Status = val, status);
            public UserRequestBuilder SetCompletionDateTime(DateTime completionDateTime) => SetProperty((u, val) => u.CompletionDateTime = val, completionDateTime);

        }
    }
}