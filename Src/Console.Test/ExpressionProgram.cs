using System.Linq.Expressions;
 
namespace Console.Test
{
    public class ExpressionProgram
    {
        public static void Main(string[] args)
        {
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);
            System.Console.WriteLine(add);
            System.Console.ReadKey();
        }
    }
}