namespace Framework.Utility.Utility
{
    public class Singleton<T> where T : new()
    {
        private static readonly object Olock = new object();
        private static T _current;
        public static T Current
        {
            get
            {
                if (_current == null)
                {
                    lock (Olock)
                    {
                        if (_current == null)
                        {

                            return new T();

                        }

                    }
                }

                return _current;
            }
        }
    }
}