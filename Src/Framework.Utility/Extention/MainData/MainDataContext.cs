namespace Framework.Utility.Extention.MainData
{
    public class MainDataContext
    {



        public static IMainDataProvider EnumProviderContext
        {
            get
            {
                return new EnumProvider();
            }
        }

        public static IMainDataProvider DbProviderContext
        {
            get
            {
                return new DbProvider();
            }
        }

        public static IMainDataProvider FileProviderContext
        {
            get
            {
                return new FileProvider();
            }
        }
    }
}
