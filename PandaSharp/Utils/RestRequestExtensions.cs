using PandaSharp.Services.Common;
using RestSharp;
using System;
using System.Linq;
using System.Reflection;

namespace PandaSharp.Utils
{
    internal static class RestRequestExtensions
    {
        public static void AddParameterIfSet(this IRestRequest restRequest, string parameter, int? value)
        {
            if (value.HasValue)
            {
                restRequest.AddParameter(parameter, value.Value);
            }
        }

        public static void AddParameterEnum(this IRestRequest restRequest, string parameter, Enum value)
        {
            restRequest.AddParameter(parameter, value.GetEnumStringRepresentation());
        }

        private static string GetEnumStringRepresentation(this Enum enumeration)
        {
            var attribute = enumeration
                .GetType()
                .GetMember(enumeration.ToString())
                .Where(member => member.MemberType == MemberTypes.Field)
                .FirstOrDefault()
                .GetCustomAttributes(typeof(StringRepresentationAttribute), false)
                .Cast<StringRepresentationAttribute>()
                .SingleOrDefault();

            return attribute?.AsString;
        }
    }
}
