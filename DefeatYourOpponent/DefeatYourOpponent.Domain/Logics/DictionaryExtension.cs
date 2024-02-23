namespace DefeatYourOpponent.Domain.Logics
{
    public static class DictionaryExtension
    {
        public static string GetInternalValue(this Dictionary<string, Dictionary<string, string>> dictionary, string value1, string value2)
        {
            if (dictionary.TryGetValue(value1, out var keyValuePairs))
            {
                if (keyValuePairs.TryGetValue(value2, out var message))
                {
                    return message;
                }
                else
                {
                    return keyValuePairs.First().Value;
                }
            }
            else
            {
                return dictionary.First().Value.First().Value;
            }
        }
    }
}
