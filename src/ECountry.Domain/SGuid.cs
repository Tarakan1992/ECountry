using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ECountry.Domain
{
    public sealed class SGuid : ValueObject
    {
        private readonly string _value;

        public SGuid(string guid)
        {
            if(!Regex.IsMatch(guid, @"[0-9A-F]{32}", RegexOptions.IgnoreCase))
            {
                throw new ArgumentException("Invalid SGuid", nameof(guid));
            }

            _value = guid;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _value;
        }

        public static SGuid New()
        {
            return new SGuid(Guid.NewGuid().ToString("N"));
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(SGuid guid)
        {
            return guid.ToString();
        }

        public static implicit operator SGuid(string guid)
        {
            return new SGuid(guid);
        }
    }
}
