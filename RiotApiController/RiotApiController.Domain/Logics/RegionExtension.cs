using RiotSharp.Misc;

namespace RiotApiController.Domain.Logics
{
    public static class RegionExtension
    {
        public static Region ToArea(this Region region)
        {
            switch (region)
            {
                case Region.Jp:
                case Region.Kr:
                    return Region.Asia;
                case Region.Na:
                case Region.Br:
                case Region.Lan:
                case Region.Las:
                    return Region.Americas;
                case Region.Eune:
                case Region.Euw:
                case Region.Tr:
                case Region.Ru:
                    return Region.Europe;
                default: return region;
            }
        }
    }
}
