namespace Plain.Dto.Request
{
    public class UserRequest : Framework.Contract.Request
    {
        public UserRequest()
        {
            Top = 10;
        }
        public string LoginName { get; set; }
    }
}