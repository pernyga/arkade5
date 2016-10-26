﻿using System.Collections.Generic;

namespace Arkivverket.Arkade.Core.Addml.Definitions.DataTypes
{
    public class StringDataType : DataType
    {
        public static readonly StringDataType Default = new StringDataType();

        private readonly string _fieldFormat;

        public StringDataType()
        {
            
        }
        public StringDataType(string fieldFormat, List<string> nullValues) : base(nullValues)
        {
            _fieldFormat = fieldFormat;
        }

        protected bool Equals(StringDataType other)
        {
            return string.Equals(_fieldFormat, other._fieldFormat);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StringDataType) obj);
        }

        public override int GetHashCode()
        {
            return (_fieldFormat != null ? _fieldFormat.GetHashCode() : 0);
        }
    }
}