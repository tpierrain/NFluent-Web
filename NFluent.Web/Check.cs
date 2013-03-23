﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Check.cs" company="">
//   Copyright 2013 Thomas PIERRAIN, Marc-Antoine LATOUR
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace NFluent.Web
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Provides a set of static methods, returning all an instance of a specific subtype of 
    /// <see cref="IFluentAssertion"/> to be used in order to make check(s) on the provided 
    /// system under test (sut) instance.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Simple .NET aliases are not used here because of the Reflection code executed within the T4 template.")]
    public static class Check
    {
        /// <summary>
        /// Returns a <see cref="IHttpWebResponseFluentAssertion" /> instance that will provide assertion methods to be executed on a given HttpWebResponse instance.
        /// </summary>
        /// <param name="value">The HttpWebResponse instance to be tested.</param>
        /// <returns>
        /// A <see cref="IHttpWebResponseFluentAssertion" /> instance to use in order to assert things on the given HttpWebResponse instance.
        /// </returns>
        /// <remarks>
        /// Methods of the returned <see cref="IHttpWebResponseFluentAssertion" /> instance will usually throw a <see cref="FluentAssertionException" /> when failing.
        /// </remarks>
        public static IHttpWebResponseFluentAssertion That(System.Net.HttpWebResponse value)
        {
            return new HttpWebResponseFluentAssertion(value);
        }

        #region Core assertions proxies

        // TODO : Find a way to extract XML documentation via T4, so that we will proxy documentation of core methods too.
        #pragma warning disable 1591

        public static NFluent.IEnumerableFluentAssertion That(System.Collections.IEnumerable enumerable)
        {
            return NFluent.Check.That(enumerable);
        }

        public static NFluent.IStringFluentAssertion That(System.String value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Int32 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Int64 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Double value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(System.Decimal value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Single value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Int16 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(Byte value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(UInt32 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(UInt16 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.INumberFluentAssertion That(UInt64 value)
        {
            return NFluent.Check.That(value);
        }

        public static NFluent.IObjectFluentAssertion That(System.Object value)
        {
            return NFluent.Check.That(value);
        }

        #pragma warning disable 1591

        #endregion
    }
}