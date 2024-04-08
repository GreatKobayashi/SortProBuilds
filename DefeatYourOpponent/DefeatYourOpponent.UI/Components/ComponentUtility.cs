namespace DefeatYourOpponent.UI.Components
{
    public static class ComponentUtility
    {
        private static readonly string _championImagesDirectoryPath = "images/champion/tiles/";
        private static readonly string _itemImagesDirectoryPath = "images/item/";
        private static readonly string _etcDirectoryPath = "images/etc/";

        public static string GetChampionImagePath(string championName)
        {
            return $"{_championImagesDirectoryPath}{championName}_0.jpg";
        }

        public static string GetItemImagePath(int id)
        {
            return GetItemImagePath(id.ToString());
        }

        public static string GetItemImagePath(string id)
        {
            return $"{_itemImagesDirectoryPath}{id}.png";
        }

        public static string GetKillIconImagePath()
        {
            return $"{_etcDirectoryPath}killing.png";
        }
    }
}
