namespace DefeatYourOpponent.Domain.Helper
{
    public static class DictionaryExtension
    {
        public static void Add<T>(this Dictionary<string, List<string>> dic, string key, List<T> elementList)
        {
#pragma warning disable CS8602
            dic.Add(key, elementList.ConvertAll(x => x.ToString() ?? throw new ArgumentNullException()));
#pragma warning restore CS8602
        }

        public static void Add<T>(this Dictionary<string, List<string>> dic, string key, T element)
        {
#pragma warning disable CS8602
            dic.Add(key, new() { element.ToString() ?? throw new ArgumentNullException() });
#pragma warning restore CS8602
        }
    }
}
