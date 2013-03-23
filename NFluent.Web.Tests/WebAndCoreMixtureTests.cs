namespace NFluent.Web.Tests
{
    using System.Net;

    using NUnit.Framework;

    [TestFixture]
    public class WebAndCoreMixtureTests
    {
        [Test]
        public void CanMixtCoreAndWebFluentAssertionsInAFluentManner()
        {
            var superHeroes = "Batman and Robin";
            Check.That(superHeroes).StartsWith("Bat").And.Contains("Robin");

            var webRequest = WebRequestHelper.CreateGoogleHttpRequest();
            using (var response = (HttpWebResponse)webRequest.GetResponse())
            {
                Check.That(response).IsNotGZipEncoded();
            }
        }
    }
}
