![NFluentWeb](https://github.com/tpierrain/nfluent-web/blob/master/NFluentWebBanner.png?raw=true)

NFluent-Web
===========

NFluent.Web is an extension library to [NFluent](https://github.com/tpierrain/NFluent/blob/master/ReadMe.md) for web-related tests.

As simple as possible
=====================

With NFluent assertion libraries:

All you've got to remember is: `Check.That`, cause every assertion is then provided via a super-duper-auto-completion-dot-experience ;-)
------------------------------------------------------------------------------------------------------------------------


Usage sample
------------

With NFluent.Web, you can write simple web assertions like this:
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

Enjoy!
------
