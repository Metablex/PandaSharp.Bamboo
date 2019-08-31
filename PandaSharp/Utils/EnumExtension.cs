using System;
using System.Linq;
using System.Reflection;
using PandaSharp.Attributes;

namespace PandaSharp.Utils
{
    public static class EnumExtension
    {
        public static string GetEnumStringRepresentation(this Enum enumeration)
        {
            var attribute = enumeration
                .GetType()
                .GetMember(enumeration.ToString())
                .First(member => member.MemberType == MemberTypes.Field)
                .GetCustomAttributes(typeof(StringRepresentationAttribute), false)
                .Cast<StringRepresentationAttribute>()
                .SingleOrDefault();

            return attribute?.AsString;
        }
    }
}