using System.Collections.Generic;

public static class FeedRepository
{
	public static Location GetLocations(string zone)
    {
        var list = new List<Location>()
        {
            new Location("Zone1", 25.0, false),
            new Location("Zone2", 12.0, true),
            new Location("Zone3", 8.0, true),
            new Location("Zone 1", 25.0, true),
        };

        return list.Find(x => x.Zone.Trim().ToLower() == zone.Trim().ToLower());
    }
}