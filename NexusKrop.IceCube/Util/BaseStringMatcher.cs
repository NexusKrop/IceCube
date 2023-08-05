namespace NexusKrop.IceCube.Util;

using System;

internal abstract class BaseStringMatcher : StringMatcher
{
    internal sealed class AndStringMatcher : BaseStringMatcher
    {

        /**
         * Matchers in order.
         */
        private readonly StringMatcher[] _stringMatchers;

        /**
         * Constructs a new initialized instance.
         *
         * @param stringMatchers Matchers in order. Never null since the {@link StringMatcherFactory} uses the
         *        {@link NoneMatcher} instead.
         */
        internal AndStringMatcher(params StringMatcher[] stringMatchers)
        {
            this._stringMatchers = (StringMatcher[])_stringMatchers!.Clone();
        }

        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            int total = 0;
            int curStart = start;
            foreach (StringMatcher stringMatcher in _stringMatchers)
            {
                if (stringMatcher != null)
                {
                    var len = stringMatcher.IsMatch(buffer, curStart, bufferStart, bufferEnd);
                    if (len == 0)
                    {
                        return 0;
                    }
                    total += len;
                    curStart += len;
                }
            }
            return total;
        }

        public override int Size()
        {
            int total = 0;
            foreach (StringMatcher stringMatcher in _stringMatchers)
            {
                if (stringMatcher != null)
                {
                    total += stringMatcher.Size();
                }
            }
            return total;
        }
    }

    internal sealed class CharArrayMatcher : BaseStringMatcher
    {

        /** The string to match, as a character array, implementation treats as immutable. */
        private readonly char[] _chars;

        /** The string to match. */
        private readonly string _matchString;

        /**
         * Constructs a matcher from a String.
         *
         * @param chars the string to match, must not be null
         */
        internal CharArrayMatcher(params char[] chars)
        {
            this._matchString = new(chars);
            this._chars = (char[])_chars!.Clone();
        }

        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            var len = Size();
            if (start + len > bufferEnd)
            {
                return 0;
            }
            int j = start;
            for (int i = 0; i < len; i++, j++)
            {
                if (_chars[i] != buffer[j])
                {
                    return 0;
                }
            }
            return len;
        }

        public override int Size()
        {
            return _chars.Length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}[\"{_matchString}\"]";
        }

    }

    internal sealed class CharMatcher : BaseStringMatcher
    {

        /** The character to match. */
        private readonly char _ch;

        /**
         * Constructs a matcher for a single character.
         *
         * @param ch the character to match
         */
        internal CharMatcher(char ch)
        {
            this._ch = ch;
        }

        /**
         * Returns {@code 1} if there is a match, or {@code 0} if there is no match.
         *
         * @param buffer the text content to match against, do not change
         * @param start the starting position for the match, valid for buffer
         * @param bufferStart unused
         * @param bufferEnd unused
         * @return The number of matching characters, zero for no match
         */
        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            return _ch == buffer[start] ? 1 : 0;
        }

        /**
         * Returns 1.
         *
         * @since 1.9
         */
        public override int Size()
        {
            return 1;
        }

        public override string ToString()
        {
            return $"{base.ToString()}['{_ch}']";
        }
    }

    internal sealed class CharSetMatcher : BaseStringMatcher
    {
        /** The set of characters to match. */
        private readonly char[] _chars;

        /**
         * Constructs a matcher from a character array.
         *
         * @param chars the characters to match, must not be null
         */
        internal CharSetMatcher(char[] chars)
        {
            this._chars = (char[])chars.Clone();
            Array.Sort(this._chars);
        }

        /**
         * Returns {@code 1} if there is a match, or {@code 0} if there is no match.
         *
         * @param buffer the text content to match against, do not change
         * @param start the starting position for the match, valid for buffer
         * @param bufferStart unused
         * @param bufferEnd unused
         * @return The number of matching characters, zero for no match
         */
        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            return Array.BinarySearch(_chars, buffer[start]) >= 0 ? 1 : 0;
        }

        public override int Size()
        {
            return 1;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{Arrays.ToString(_chars)}";
        }

    }

    internal sealed class NoneMatcher : BaseStringMatcher
    {

        /**
         * Constructs a new instance of {@code NoMatcher}.
         */
        internal NoneMatcher()
        {
        }

        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            return 0;
        }

        /**
         * Returns 0.
         *
         * @since 1.9
         */
        public override int Size()
        {
            return 0;
        }
    }

    internal sealed class TrimMatcher : BaseStringMatcher
    {

        /**
         * The space character.
         */
        private const int SPACE_INT = 32;

        /**
         * Constructs a new instance of {@code TrimMatcher}.
         */
        internal TrimMatcher()
        {
        }

        /**
         * Returns {@code 1} if there is a match, or {@code 0} if there is no match.
         *
         * @param buffer the text content to match against, do not change
         * @param start the starting position for the match, valid for buffer
         * @param bufferStart unused
         * @param bufferEnd unused
         * @return The number of matching characters, zero for no match
         */
        public override int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd)
        {
            return buffer[start] <= SPACE_INT ? 1 : 0;
        }

        public override int Size()
        {
            return 1;
        }
    }

    protected BaseStringMatcher() { }
}
