namespace DefeatYourOpponent.UI.Components
{
    public static class ComponentUtility
    {
        private static readonly string _championImagesDirectoryPath = "images/champion/tiles/";
        private static readonly string _itemImagesDirectoryPath = "images/item/";

        public static string GetChampionImagePath(string championName)
        {
            return $"{_championImagesDirectoryPath}{championName}_0.jpg";
        }

        public static string GetItemImagePath(long id)
        {
            return $"{_itemImagesDirectoryPath}{id}.png";
        }
    }
}
