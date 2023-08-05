namespace NexusKrop.IceCube.Util;

public class StringSubstituter
{
    private sealed class Result
    {
        public bool Altered { get; }
        public int LengthChange { get; }

        private Result(bool altered, int lengthChange)
        {
            Altered = altered;
            LengthChange = lengthChange;
        }

        public override string ToString()
        {
            return $"Result [altered={Altered}, lengthChange={LengthChange}]";
        }
    }

    /**
     * Constant for the default escape character.
     */
    public static readonly char DEFAULT_ESCAPE = '$';

    /**
     * The default variable default separator.
     *
     * @since 1.5.
     */
    public static readonly string DEFAULT_VAR_DEFAULT = ":-";

    /**
     * The default variable end separator.
     *
     * @since 1.5.
     */
    public static readonly string DEFAULT_VAR_END = "}";

    /**
     * The default variable start separator.
     *
     * @since 1.5.
     */
    public static readonly string DEFAULT_VAR_START = "${";

    /**
     * Constant for the default variable prefix.
     */
    public static readonly StringMatcher DEFAULT_PREFIX = StringMatcherFactory.Instance.StringMatcher(DEFAULT_VAR_START);

    /**
     * Constant for the default variable suffix.
     */
    public static readonly StringMatcher DEFAULT_SUFFIX = StringMatcherFactory.Instance.StringMatcher(DEFAULT_VAR_END);

    /**
     * Constant for the default value delimiter of a variable.
     */
    public static readonly StringMatcher DEFAULT_VALUE_DELIMITER = StringMatcherFactory.Instance
        .StringMatcher(DEFAULT_VAR_DEFAULT);


}
