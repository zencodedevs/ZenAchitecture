﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ZenAchitecture.Domain.Common
{
    public class Constants
    {
        public const string PrimarySecurityPolicy = "BasePolicy";
        public const string SettingsSecurityPolicy = "SettingsPolicy";

        public struct SystemCultureNames
        {
            public const string English = "en-US";
            public const string Georgian = "ka-GE";
        }


        public struct Subscription { }

        public struct DataCultureNames
        {
            public const string English = "en-US";
            public const string Georgian = "ka-GE";
        }

        public struct NullValues
        {
            public const string StringNullValue = "";
            public const int IntNullValue = 0;
        }

        public struct Regexes
        {
            public const string Website = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
            public const string EmailPrefix = @"^[a-z0-9.-]*$";
        }

        public struct Pageing
        {
            public const int FirstPageIndex = 1;
            public const int PageSize = 5;
            public const int ActivitiesPageSize = 10;
        }

        public struct Nlog
        {
            public const string WebUiDbRegisterClause = "insert into \"Logs\"(\"When\",\"Message\",\"Level\",\"Exception\",\"Trace\",\"Logger\",\"Channel\")VALUES (now(),@msg,@level,@exception,@trace,@logger,'WebUI')";
        }

        public static class NewtonsoftSerializer
        {
            public static JsonSerializerSettings Strategy()
            {
                var jsonSerializerSettings = new JsonSerializerSettings();
                jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                return jsonSerializerSettings;
            }

        }

        public struct Infinite
        {
            public const string Value = "infinite";
        }
        public struct Currencies
        {
            public const string GEL = "₾";
        }

        public struct Routes { }
    }

    public static class Permissions
    {
        public static class PermissionType
        {
            public const string SettingPerm = nameof(SettingPerm);
        }

        public class Settings { }

        public class ProfileMenu { }
    }
}
