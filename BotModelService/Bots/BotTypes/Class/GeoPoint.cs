using System.Globalization;

namespace BotModel.Bots.BotTypes.Class
{
    public struct GeoPoint
    {
        public delegate string ToStringFunc(double x, double y);
        public double Long, Lat;

        public static GeoPoint Parse(string point)
        {
            var splitted = point.Split(new char[] { ' ' }, count: 2);
            return new GeoPoint(double.Parse(splitted[0], CultureInfo.InvariantCulture), double.Parse(splitted[1], CultureInfo.InvariantCulture));
        }

        public GeoPoint(double @long, double lat)
        {
            Long = @long;
            Lat = lat;
        }

        public override string ToString() => $"{Long.ToString(CultureInfo.InvariantCulture)} {Lat.ToString(CultureInfo.InvariantCulture)}";
        public string ToString(string format) => string.Format(format, Long.ToString(CultureInfo.InvariantCulture), Lat.ToString(CultureInfo.InvariantCulture));
        public string ToString(ToStringFunc formatFunc) => formatFunc(Long, Lat);
    }
}