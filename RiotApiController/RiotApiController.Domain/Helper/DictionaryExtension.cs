namespace RiotApiController.Domain.Helper
{
    public static class DictionaryExtension
    {
        public static void Add<T>(this Dictionary<string, string> dic, string key, T element)
        {
#pragma warning disable CS8604
#pragma warning disable CS8602
            dic.Add(key, element.ToString());
#pragma warning restore CS8602
#pragma warning restore CS8604
        }
    }
}
