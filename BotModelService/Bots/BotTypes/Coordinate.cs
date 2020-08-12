using System.Globalization;
using BotModel.Bots.BotTypes.Class;

namespace BotModel.Bots.BotTypes
{
	public abstract class Point
	{
		public char Alias { get; set; } = ' ';

		public abstract string OriginText { get; }
		public string Urls { get; set; }
	}

	public class Coordinate : Point
	{
		
		public float Latitude { get; }
		public float Longitude{ get; }
		public override string OriginText { get;}
		
		public Coordinate(float lat , float @long, string originText)
		{
			Latitude = lat;
			Longitude = @long;
			OriginText = originText;
		}

		public Coordinate(GeoPoint point, string originText)
		{
			Latitude = (float)point.Lat;
			Longitude = (float)point.Long;
			OriginText = originText;
		}

		public override string ToString() => string.Format(CultureInfo.InvariantCulture, "{0:G}", Latitude) + "," +
		                                     string.Format(CultureInfo.InvariantCulture, "{0:G}", Longitude);
	}

	public class Place : Point
	{
		public override string OriginText { get; }

		public Place(string originText)
		{
			OriginText  = originText;
		}

		public override string ToString() => OriginText;
	}
}
