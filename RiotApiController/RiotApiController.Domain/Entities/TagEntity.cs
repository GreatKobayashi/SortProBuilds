namespace RiotApiController.Domain.Entities
{
    public class TagEntity
    {
        public string? Champion { get; set; }
        public bool? Win { get; set; }
        public string? Position { get; set; }

        public TagEntity(Dictionary<string, string> tagKeyValuePairs)
        {
            foreach (var tag in tagKeyValuePairs)
            {
                switch (tag.Key)
                {
                    case "Champion":
                        Champion = tag.Value;
                        break;
                    case "Win":
                        Win = Convert.ToBoolean(tag.Value);
                        break;
                    case "Position":
                        Position = tag.Value;
                        break;
                }
            }
        }

        public bool IsMatch(GameResultEntity matchResultEntity)
        {
            if (!string.IsNullOrEmpty(Champion) && matchResultEntity.Champion != Champion ||
                Win != null && matchResultEntity.Win != Win ||
                !string.IsNullOrEmpty(Position) && matchResultEntity.Position != Position)
            {
                return false;
            }

            return true;
        }
    }
}
