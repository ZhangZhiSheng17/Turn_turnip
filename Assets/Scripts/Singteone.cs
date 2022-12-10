public class Singteone<T> where T : class, new()
{
    private static T instance;
    private static readonly System.Object obj = new System.Object();

    protected Singteone()
    {
    }

    public static T Instance()
    {
        if (instance == null)
        {
            lock (obj)
            {
                if (instance == null)
                {
                    instance = new T();
                }
            }
        }

        return instance;
    }
}