namespace NexusKrop.IceCube.Util;

public class StringMatcherFactory
{
    /**
 * Matches the comma character.
 */
    private static readonly BaseStringMatcher.CharMatcher COMMA_MATCHER = new(',');

    /**
     * Matches the double quote character.
     */
    private static readonly BaseStringMatcher.CharMatcher DOUBLE_QUOTE_MATCHER = new(
        '"');

    /**
     * Defines the singleton for this class.
     */
    public static readonly StringMatcherFactory Instance = new();

    /**
     * Matches no characters.
     */
    private static readonly BaseStringMatcher.NoneMatcher NONE_MATCHER = new();

    /**
     * Matches the single or double quote character.
     */
    private static readonly BaseStringMatcher.CharSetMatcher QUOTE_MATCHER = new(
        "'\"".ToCharArray());

    /**
     * Matches the double quote character.
     */
    private static readonly BaseStringMatcher.CharMatcher SINGLE_QUOTE_MATCHER = new(
        '\'');

    /**
     * Matches the space character.
     */
    private static readonly BaseStringMatcher.CharMatcher SPACE_MATCHER = new(' ');

    /**
     * Matches the same characters as StringTokenizer, namely space, tab, newline, form feed.
     */
    private static readonly BaseStringMatcher.CharSetMatcher SPLIT_MATCHER = new(
        " \t\n\r\f".ToCharArray());

    /**
     * Matches the tab character.
     */
    private static readonly BaseStringMatcher.CharMatcher TAB_MATCHER = new('\t');

    /**
     * Matches the String trim() whitespace characters.
     */
    private static readonly BaseStringMatcher.TrimMatcher TRIM_MATCHER = new();

    /**
     * No need to build instances for now.
     */
    private StringMatcherFactory()
    {
        // empty
    }

    /**
     * Creates a matcher that matches all of the given matchers in order.
     *
     * @param stringMatchers the matcher
     * @return a matcher that matches all of the given matchers in order.
     * @since 1.9
     */
    public StringMatcher AndMatcher(params StringMatcher[] stringMatchers)
    {
        var len = stringMatchers.Length;
        if (len == 0)
        {
            return NONE_MATCHER;
        }
        if (len == 1)
        {
            return stringMatchers[0];
        }
        return new BaseStringMatcher.AndStringMatcher(stringMatchers);
    }

    /**
     * Constructor that creates a matcher from a character.
     *
     * @param ch the character to match, must not be null
     * @return a new Matcher for the given char
     */
    public StringMatcher CharMatcher(char ch)
    {
        return new BaseStringMatcher.CharMatcher(ch);
    }

    /**
     * Constructor that creates a matcher from a set of characters.
     *
     * @param chars the characters to match, null or empty matches nothing
     * @return a new matcher for the given char[]
     */
    public StringMatcher CharSetMatcher(params char[] chars)
    {
        int len = chars.Length;
        if (len == 0)
        {
            return NONE_MATCHER;
        }
        if (len == 1)
        {
            return new BaseStringMatcher.CharMatcher(chars[0]);
        }
        return new BaseStringMatcher.CharSetMatcher(chars);
    }

    /**
     * Creates a matcher from a string representing a set of characters.
     *
     * @param chars the characters to match, null or empty matches nothing
     * @return a new Matcher for the given characters
     */
    public StringMatcher CharSetMatcher(string chars)
    {
        var len = chars.Length;
        if (len == 0)
        {
            return NONE_MATCHER;
        }
        if (len == 1)
        {
            return new BaseStringMatcher.CharMatcher(chars[0]);
        }
        return new BaseStringMatcher.CharSetMatcher(chars.ToCharArray());
    }

    /**
     * Returns a matcher which matches the comma character.
     *
     * @return a matcher for a comma
     */
    public StringMatcher CommaMatcher()
    {
        return COMMA_MATCHER;
    }

    /**
     * Returns a matcher which matches the double quote character.
     *
     * @return a matcher for a double quote
     */
    public StringMatcher DoubleQuoteMatcher()
    {
        return DOUBLE_QUOTE_MATCHER;
    }

    /**
     * Matches no characters.
     *
     * @return a matcher that matches nothing
     */
    public StringMatcher NoneMatcher()
    {
        return NONE_MATCHER;
    }

    /**
     * Returns a matcher which matches the single or double quote character.
     *
     * @return a matcher for a single or double quote
     */
    public StringMatcher QuoteMatcher()
    {
        return QUOTE_MATCHER;
    }

    /**
     * Returns a matcher which matches the single quote character.
     *
     * @return a matcher for a single quote
     */
    public StringMatcher SingleQuoteMatcher()
    {
        return SINGLE_QUOTE_MATCHER;
    }

    /**
     * Returns a matcher which matches the space character.
     *
     * @return a matcher for a space
     */
    public StringMatcher SpaceMatcher()
    {
        return SPACE_MATCHER;
    }

    /**
     * Matches the same characters as StringTokenizer, namely space, tab, newline and form feed.
     *
     * @return The split matcher
     */
    public StringMatcher SplitMatcher()
    {
        return SPLIT_MATCHER;
    }

    /**
     * Creates a matcher from a string.
     *
     * @param chars the string to match, null or empty matches nothing
     * @return a new Matcher for the given String
     * @since 1.9
     */
    public StringMatcher StringMatcher(params char[] chars)
    {
        var length = chars.Length;
        return length == 0 ? NONE_MATCHER
            : length == 1 ? new BaseStringMatcher.CharMatcher(chars[0])
                : new BaseStringMatcher.CharArrayMatcher(chars);
    }

    /**
     * Creates a matcher from a string.
     *
     * @param str the string to match, null or empty matches nothing
     * @return a new Matcher for the given String
     */
    public StringMatcher StringMatcher(string str)
    {
        return string.IsNullOrEmpty(str) ? NONE_MATCHER : StringMatcher(str.ToCharArray());
    }

    /**
     * Returns a matcher which matches the tab character.
     *
     * @return a matcher for a tab
     */
    public StringMatcher TabMatcher()
    {
        return TAB_MATCHER;
    }

    /**
     * Matches the String trim() whitespace characters.
     *
     * @return The trim matcher
     */
    public StringMatcher TrimMatcher()
    {
        return TRIM_MATCHER;
    }
}
