namespace Core.Config.ConfigModel
{
    public class MailConfig:ConfigBase
    {
         public string EmailHost { get; set; }
         public string EmailPort { get; set; }
         public string EmailAddress { get; set; }
         public string EmailPassword { get; set; }
    }
}