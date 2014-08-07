﻿using System;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MessageBird.Objects
{
    public enum PaymentMethod
    {
        [EnumMember(Value = "prepaid")]
        Prepaid,
        [EnumMember(Value = "postpaid")]
        Postpaid
    }

    public enum PaymentType
    {
        [EnumMember(Value = "credits")]
        Credits,
        [EnumMember(Value = "euros")]
        Euros
    }

    public class Balance : IIdentifiable<string>
    {
        public string Id
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        [JsonProperty("payment"), JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethod Payment { get; set; }

        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}