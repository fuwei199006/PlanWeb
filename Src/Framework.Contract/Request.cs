namespace Framework.Contract
{
    public class Request:ModelBase
    {

        public Request()
        {
            PageSize = 5000;
        }

        public int Top
        {
            set
            {
                this.PageSize = value;
                PageIndex = 1;
            }
        }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
         
    }
}