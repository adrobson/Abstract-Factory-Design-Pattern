using AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Helpers
{
    public class MyHtmlHelpers
    {
        public static IHtmlString FormattedRoomDiv(Room room)
        {
            string cssString = "col-md-6 " + SetFormatting(room);
            string htmlString = String.Format("<div class='" + cssString + "'></div>", room);
            return new HtmlString(htmlString);
        }

        public static string SetFormatting(Room r)
        {
            string format = RoomBackground(r);

            format += BorderFormat(r.Sides.Where(x => x.Key == Direction.North).FirstOrDefault().Value, "top");
            format += BorderFormat(r.Sides.Where(x => x.Key == Direction.East).FirstOrDefault().Value, "right");
            format += BorderFormat(r.Sides.Where(x => x.Key == Direction.South).FirstOrDefault().Value, "bottom");
            format += BorderFormat(r.Sides.Where(x => x.Key == Direction.West).FirstOrDefault().Value, "left");
            return format;
        }

        public static string RoomBackground(MapSite m)
        {
            if (m.GetType().ToString() == "AbstractFactory.EnchantedRoom")
            {
                return " room enchanted";
            }
            else if (m.GetType().ToString() == "AbstractFactory.RoomWithABomb")
            {
                return " room withABomb";
            }
            else
            {
                return "room";
            }

        }
        public static string BorderFormat(MapSite m, string direction)
        {
            if (m.GetType().ToString() == "AbstractFactory.Wall")
            {
                return " wall-" + direction;
            }
            else
            {
                return " door-" + direction;
            }
        }
    }
}