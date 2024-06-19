namespace DefeatYourOpponent.UI.Components
{
    public static class ComponentUtility
    {
        private static readonly string _eventDirectoryPath = "images/event/";

        public static string GetKillIconImagePath()
        {
            return $"{_eventDirectoryPath}killing.png";
        }

        public static string GetPurchaseIconImagePath()
        {
            return $"{_eventDirectoryPath}purchase.png";
        }

        public static string GetTitleImagePath()
        {
            return "images/title.png";
        }
    }
}
