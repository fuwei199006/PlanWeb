namespace Core.Exception
{
    public class RunableException:BaseException
    {

        public RunableException():this("系统已经关闭，如开启请联系管理员")
        {
            
        }
        public RunableException(string message) :
            base("error", message)
        {
      
        }

        
    }
}