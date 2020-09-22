using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OnlineShop.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                                            .GetMember(enumValue.ToString())
                                            .First()
                                            .GetCustomAttribute<DisplayAttribute>();
            if(displayAttribute is object)
                return displayAttribute.GetName();

            return String.Empty;
        }
    }
}