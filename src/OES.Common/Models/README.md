# About `Models` Directory

These classes either represent a request body to or a response body from the OES API.
This design is similar to that of GitHub's .NET library for its API `octokit.net`.
You may want to take a look at that repository for more information.

## `Response` Models

General guidelines for designing `Response` models:

1. In client software's code,
they should only be obtained via their respective `Client`.
The constructors of those models are intended to be used by the server software.

2. The models should be immutable. To modify the model and send the modification
to the server, they should first be converted to a `Request` model via the
`ToUpdate()` method and sent by their respective `Client`.

3. To provide backward compatibility to older versions of database structures,
models should come with different versions of serialisers and deserialisers.