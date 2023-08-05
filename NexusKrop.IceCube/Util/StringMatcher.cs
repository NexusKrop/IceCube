namespace NexusKrop.IceCube.Util;

using System;

public abstract class StringMatcher
{
    public virtual int IsMatch(ReadOnlySpan<char> buffer, int pos)
    {
        return IsMatch(buffer, pos, 0, buffer.Length);
    }

    public abstract int IsMatch(ReadOnlySpan<char> buffer, int start, int bufferStart, int bufferEnd);

    public virtual int Size() => 0;
}
