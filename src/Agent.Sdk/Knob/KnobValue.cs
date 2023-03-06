// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Threading;
using Microsoft.VisualStudio.Services.Agent.Util;

namespace Agent.Sdk.Knob
{
    public class KnobValue
    {
        public KnobSourceType Source { get; private set; }
        private readonly string _value;
        private readonly string _defaultValue = null;

        public string DefaultValue => _defaultValue;

        public KnobValue(string value, KnobSourceType source)
        {
            _value = value;
            Source = source;
        }

        public KnobValue(string value, string defaultValue, KnobSourceType source) : this(value, source)
        {
            _defaultValue = defaultValue;
        }

        public string AsString()
        {
            return _value;
        }

        public bool AsBoolean()
        {
            return StringUtil.ConvertToBoolean(_value);
        }

        public bool AsBooleanStrict()
        {
            try
            {
                return StringUtil.ConvertToBooleanStrict(_value);
            }
            catch (Exception)
            {
                if (_defaultValue != null)
                {
                    return StringUtil.ConvertToBoolean(_defaultValue);
                }

                throw;
            }
        }

        public int AsInt()
        {
            try
            {
                return Int32.Parse(_value);
            }
            catch (Exception)
            {
                if (_defaultValue != null)
                {
                    return int.Parse(_defaultValue);
                }

                throw;
            }
        }
    }
}
