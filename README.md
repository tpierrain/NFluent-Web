NFluent-Web
===========

NFluent Web assertions.

Usage sample
------------

With NFluent, you can write simple web assertions like this:
```c#	
    var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
	request.UserAgent = "Mozilla/5.0 compatible";
	request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");

    using (var response = (HttpWebResponse)request.GetResponse())
    {
        Check.That(response).StatusCodeEqualsTo(HttpStatusCode.OK)
                            .And.HasHeader(HttpResponseHeader.CacheControl)
                            .And.HasHeader("X-Frame-Options").Which.Contains("SAMEORIGIN")
                            .And.HasHeader(HttpResponseHeader.Server).Which.Contains("gws")
                            .And.IsGZipEncoded()
							.And.Contains("Google");

        // TODO: Allow usage of multiple assertions on a given header such as:  .And.HasHeader("X-Frame-Options").Which.Contains("SAMEORIGIN").And.StartsWith("SAME").And.EndsWith("ORIGIN")
    }

```