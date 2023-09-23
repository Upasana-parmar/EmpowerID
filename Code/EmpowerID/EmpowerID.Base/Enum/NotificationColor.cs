using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Base.Enum
{
    public enum NotificationColor
    {
        Error,
        Success,
        Warning,
        danger
    }

    public static class ErrorLevelExtensions
    {
        /// <summary>
        /// Get Color Name
        /// </summary>
        /// <param name="jsonColor"></param>
        /// <returns>string</returns>
        public static string ToColorName(this NotificationColor jsonColor)
        {
            if (jsonColor == NotificationColor.danger)
                return NotificationColor.Error.ToString().ToLower();
            return jsonColor.ToString().ToLower();
        }
    }
}
