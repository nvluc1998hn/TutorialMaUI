namespace TutorialMaUI.Extensions
{
    public sealed class Singleton<T> where T : new()
    {
        private Singleton()
        {
        }

        private static readonly Lazy<T> lazy = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}
