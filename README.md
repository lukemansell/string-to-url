# String To Url

This NuGet library contains an extension method to turn any string into a string which can be used in an URL. A practical example is how I use this on [Musicstax](https://musicstax.com) where I take track, artist or playlist names and turn them into a URL.

Example:

Input: ```Charlie Puth That's Hilarious```

Output: ```charlie-puth-thats-hilarious```

### Why I have written this

This is a common feature I use for generating URLs from strings which could be of use for others.

### How to use / what this does

Once you have installed the StringToUrl nuget package to your solution you will be able to use this.

There are two ways to use StringToUrl.
* With the default options
* By overriding options with a `UrlOptions` object

#### With  default options
On any string you can do:

```string.ConvertToUrl()```

This will:

* Replace diacritics. Eg: ā is turned into a
* Remove any non alphanumeric characters
* Replace any spaces with -
* Remove any instances where words were stripped in such a way that one or more dashes are next to each other and replace them with just one
* Return the generated URL path

Example:

```c#
var name = "Charlie Puth That's Hilarious";

name.ConvertToUrl(); // returns charlie-puth-thats-hilarious
```

#### Overriding default options

You can pass through a `UrlOptions` object to `string.ConvertToUrl()` to override some the default options.

| Option                                 | Description                                                                                                                                                                                                                                                                                    |
|----------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `SpaceReplacementCharacter`<br/>string | By default spaces are replaced with a dash. You can override this with any value.                                                                                                                                                                                                              |
| `Case`<br/>StringCase enum             | By default the returned URL is converted to lowercase. You can override this with:<br/>`StringCase.UPPER` - returns the string in all uppercase<br/>`StringCase.UNCHANGED` - returns the string without any case change<br/>`StringCase.LOWER` - default - returns the string in all lowercase |
| `MaxLength`<br/>int                    | By default the entire input string is converted and then returned. You can choose to set a max character length by setting this.<br/>Note: if the ending character is a `SpaceReplacementCharacter` this is removed so that the returned URL does not end in a dash for example.               |
| `Append`<br/>string                    | Add to the end of the generated URL path.                                                                                                                                                                                                                                                      |
| `Prepend`<br/>string                   | Add to the start of the generated URL path. Eg: your domain. |

Any of these options can be set without others being set.

To use this:

```c#
var name = "Charlie Puth That's Hilarious";

var options = new UrlOptions {
    SpaceReplacementCharacter = "_",
    Case = StringCase.UPPER,
    MaxLength = 25,
    Prepend = "https://google.co.nz/".
    Append = "/index"
};

name.ConvertToUrl(options); // returns https://google.co.nz/CHARLIE_PUTH_THATS_HILARI/index
```

As noted, you do not need to set all options:

```c#
var name = "Charlie Puth That's Hilarious";

var options = new UrlOptions {
    MaxLength = 25
};

name.ConvertToUrl(options); // returns charlie-puth-thats-hilari
```