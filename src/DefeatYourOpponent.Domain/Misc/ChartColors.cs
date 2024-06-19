using System.Drawing;

namespace DefeatYourOpponent.Domain.Misc
{
    public static class ChartColors
    {
        public static Color Red(int alpha) => Color.FromArgb(alpha, 255, 99, 132);
        public static Color Orange(int alpha) => Color.FromArgb(alpha, 255, 159, 64);
        public static Color Yellow(int alpha) => Color.FromArgb(alpha, 255, 205, 86);
        public static Color Green(int alpha) => Color.FromArgb(alpha, 75, 192, 192);
        public static Color Blue(int alpha) => Color.FromArgb(alpha, 54, 162, 235);
        public static Color Purple(int alpha) => Color.FromArgb(alpha, 153, 102, 255);
        public static Color Grey(int alpha) => Color.FromArgb(alpha, 201, 203, 207);

    }
}
