// --------------------------------------------------------------------------------------------------------------------
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
    /// <summary>
    /// Provides a set of static methods, returning all an instance of a specific subtype of 
    /// <see cref="IFluentAssertion"/> to be used in order to make check(s) on the provided 
    /// system under test (sut) instance.
    /// </summary>
    public static class Check
    {
        // TODO : Define some use case around web http stuff

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
    }
}