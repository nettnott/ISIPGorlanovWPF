using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIPGorlanovWPF
{
    internal static class Lists
    {
        public static List<Film> filmsList = Core.Context.Film.ToList();
        public static List<Session> sessionsList = Core.Context.Session.ToList();
        public static List<Film> searchList = new List<Film>();
    }
}
