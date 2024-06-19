namespace DefeatYourOpponent.Domain.Entities
{
    public class ImagePostionEntity
    {
        public double StartX { get; set; }
        public double EndX { get; set; }
        public int Y { get; set; }

        public ImagePostionEntity(double startX, double endX, int y)
        {
            StartX = startX;
            EndX = endX;
            Y = y;
        }
    }
}
