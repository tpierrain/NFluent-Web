namespace NFluent.Web
{
    using System.Linq;
    using System.Net;

    using NFluent.Extensions;
    using NFluent.Helpers;
    using NFluent.Web.Helpers;

    /// <summary>
    /// Provides assertion methods to be executed on an http header, and allowing them to be
    /// chained with other assertions related to the underlying IHttpWebResponse instance this time.
    /// </summary>
    public static class HttpWebResponseFluentAssertionExtensions
    {
        /// <summary>
        /// Checks that a given instance is considered to be equal to another expected instance. Throws <see cref="FluentAssertionException" /> otherwise.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="expected">The expected instance.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual value is not equal to the expected value.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsEqualTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, object expected)
        {
            EqualityHelper.IsEqualTo(fluentAssertion.Value, expected);
            
            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that a given instance is considered to not be equal to another expected instance. Throws <see cref="FluentAssertionException" /> otherwise.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="expected">The expected instance.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual value is equal to the expected value.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsNotEqualTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, object expected)
        {
            EqualityHelper.IsNotEqualTo(fluentAssertion.Value, expected);

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that the actual instance is an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The expected Type of the instance.</typeparam>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual instance is not of the provided type.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsInstanceOf<T>(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            IsInstanceHelper.IsInstanceOf(fluentAssertion.Value, typeof(T));

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that the actual instance is not an instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type not expected for this instance.</typeparam>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual instance is of the provided type.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsNotInstanceOf<T>(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            IsInstanceHelper.IsNotInstanceOf(fluentAssertion.Value, typeof(T));

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that the http response status code equals the provided status code.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="statusCode">The expected http status code.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The http response code does not equal to the given status code.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> StatusCodeEqualsTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, HttpStatusCode statusCode)
        {
            if (fluentAssertion.Value.StatusCode != statusCode)
            {
                throw new FluentAssertionException(string.Format("[{0}] not equals to the expected http status code [{1}]", fluentAssertion.Value.StatusCode.ToStringProperlyFormated(), statusCode.ToStringProperlyFormated()));
            }

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Check whether the specified header is part of the response headers of the <see cref="HttpWebResponse" />.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="header">The expected response header value.</param>
        /// <returns>
        /// A chainable assertion that may be used to assert on the given header or on the <see cref="HttpWebResponse" />.
        /// </returns>
        /// <exception cref="FluentAssertionException">The response headers of the <see cref="HttpWebResponse" /> instance does not contain any header with the specified name.</exception>
        public static IChainableHttpHeaderOrHttpWebResponseFluentAssertion HasHeader(this IFluentAssertion<HttpWebResponse> fluentAssertion, HttpResponseHeader header)
        {
            string headerName = header.ToString();
            string headerContent = fluentAssertion.Value.Headers[header];

            return HasHeaderInternal(headerContent, headerName, fluentAssertion);
        }

        /// <summary>
        /// Check whether the specified header is part of the response headers of the <see cref="HttpWebResponse" />.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="headerName">The expected response header name.</param>
        /// <returns>
        /// A chainable assertion that may be used to assert on the given header or on the <see cref="HttpWebResponse" />.
        /// </returns>
        /// <exception cref="FluentAssertionException">The response headers of the <see cref="HttpWebResponse" /> instance does not contain any header with the specified name.</exception>
        public static IChainableHttpHeaderOrHttpWebResponseFluentAssertion HasHeader(this IFluentAssertion<HttpWebResponse> fluentAssertion, string headerName)
        {
            string headerContent = fluentAssertion.Value.Headers[headerName];

            return HasHeaderInternal(headerContent, headerName, fluentAssertion);
        }

        /// <summary>
        /// Checks that the actual response content is "gzip" encoded.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual response content is not encoded using gzip.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsGZipEncoded(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            if (!IsGZipEncodedInternal(fluentAssertion))
            {
                throw new FluentAssertionException("The http response content is not encoded using gzip.");
            }

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that the actual response content is not encoded using gzip.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual response content is encoded using gzip.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> IsNotGZipEncoded(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            if (IsGZipEncodedInternal(fluentAssertion))
            {
                throw new FluentAssertionException("The http response content is encoded using gzip.");
            }

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        /// <summary>
        /// Checks that the response content contains the given expected values, in any order.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <param name="values">The expected values to be found.</param>
        /// <returns>
        /// A chainable assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The response content does not contains all the given strings in any order.</exception>
        public static IChainableFluentAssertion<IFluentAssertion<HttpWebResponse>> Contains(this IFluentAssertion<HttpWebResponse> fluentAssertion, params string[] values)
        {
            var responseContent = IsGZipEncodedInternal(fluentAssertion) ?
                                        HttpHelper.ReadGZipStream(fluentAssertion.Value) :
                                        HttpHelper.ReadResponseStream(fluentAssertion.Value);
            var notFound = values.Where(value => !responseContent.Contains(value)).ToList();

            if (notFound.Count > 0)
            {
                throw new FluentAssertionException(string.Format(@"The http response content does not contain the expected value(s): [{0}].", notFound.ToEnumeratedString()));
            }

            return new ChainableFluentAssertion<IFluentAssertion<HttpWebResponse>>(fluentAssertion);
        }

        private static IChainableHttpHeaderOrHttpWebResponseFluentAssertion HasHeaderInternal(string headerContent, string headerName, IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            if (string.IsNullOrEmpty(headerContent))
            {
                throw new FluentAssertionException(string.Format("[{0}] header was not found in the response headers", headerName.ToStringProperlyFormated()));
            }

            return new ChainableHttpHeaderOrHttpWebResponseFluentAssertion(headerName, headerContent, fluentAssertion);
        }

        private static bool IsGZipEncodedInternal(IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            return fluentAssertion.Value.ContentEncoding == "gzip";
        }
    }
}
