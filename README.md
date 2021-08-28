My Media Search is a Windows program for indexing and searching media files on the user's computer.

Windows already indexes the media files on the user's computer, so what's the point?

Well, it was a good exercise in seeing how to get extended metadata properties of files on Windows.

Unfortunately, the API for getting that metadata is quite slow, making this project more of a proof of concept...for metastrings!

This program was originally written using SQLite, but then I developed metastrings (https://metastrings.io), and this project seemed like a good place to try things out.

It really turned my head around, helping me see what is great about metastrings, like full-text indexing, and the things that I needed to rethink, like how not every use case calls for a client-server architecture.  I learned to embrace the server-less architecture, and things went well from there.

Visit https://www.mymediasearch.com to download the build and for detailed documentation. Enjoy.
