using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CommunityManager.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string self)
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            var textInfo = cultureInfo.TextInfo;


            return textInfo.ToTitleCase(self);
        }
    }
}