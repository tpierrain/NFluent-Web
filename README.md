![NFluentWeb](https://github.com/tpierrain/nfluent-web/blob/master/NFluentWebBanner.png?raw=true)

NFluent-Web
===========

NFluent.Web is an extension library to __[NFluent](https://github.com/tpierrain/NFluent/blob/master/ReadMe.md)__ for web-related assertions.

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

- - -

Uses cases
----------
__[NFluent use cases are available here](https://github.com/tpierrain/NFluent/blob/master/UseCases.md)__.

Newsgroup
---------
For any comment, remark or question on the library, please use the __[NFluent-Discuss google group](https://groups.google.com/forum/#!forum/nfluent-discuss)__.

BackLog
-------
Nfluent __backlog is available as github issues__

New feature to be added?
------------------------
+ If you want to join the project and contribute: __[Check this out first](./CONTRIBUTING.md)__, but be our guest. 
+ If you don't want to contribute on the library, but you need a feature not yet implemented, don't hesitate to request it on the __[NFluent-Discuss google group](https://groups.google.com/forum/#!forum/nfluent-discuss)__.
__In any cases: you are welcome!__

