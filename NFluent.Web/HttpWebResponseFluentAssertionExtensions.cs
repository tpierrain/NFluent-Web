namespace NFluent.Web
{
    using System.Net;

    using Spike;

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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsEqualTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, object expected)
        {
            // TODO : migrate the implementation directly here?
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);
            
            return assertionStrategy.IsEqualTo(expected);
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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsNotEqualTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, object expected)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);
            
            return assertionStrategy.IsNotEqualTo(expected);
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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsInstanceOf<T>(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);
            
            return assertionStrategy.IsInstanceOf<T>();
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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsNotInstanceOf<T>(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.IsNotInstanceOf<T>();
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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> StatusCodeEqualsTo(this IFluentAssertion<HttpWebResponse> fluentAssertion, HttpStatusCode statusCode)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.StatusCodeEqualsTo(statusCode);
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
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.HasHeader(header);
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
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.HasHeader(headerName);
        }

        /// <summary>
        /// Checks that the actual response content is "gzip" encoded.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual response content is not encoded using gzip.</exception>
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsGZipEncoded(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.IsGZipEncoded();
        }

        /// <summary>
        /// Checks that the actual response content is not encoded using gzip.
        /// </summary>
        /// <param name="fluentAssertion">The fluent assertion to be extended.</param>
        /// <returns>
        /// A chainable fluent assertion.
        /// </returns>
        /// <exception cref="FluentAssertionException">The actual response content is encoded using gzip.</exception>
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> IsNotGZipEncoded(this IFluentAssertion<HttpWebResponse> fluentAssertion)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.IsNotGZipEncoded();
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
        public static IChainableFluentAssertion<IHttpWebResponseFluentAssertion> Contains(this IFluentAssertion<HttpWebResponse> fluentAssertion, params string[] values)
        {
            var assertionStrategy = new HttpWebResponseFluentAssertion(fluentAssertion.Value);

            return assertionStrategy.Contains(values);
        }
    }
}
