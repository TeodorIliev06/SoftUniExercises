namespace P01.Stream_Progress;

public abstract class StreamableFile
{
    private int length;
    private int bytesSent;

    public StreamableFile(int length, int bytesSent)
    {
        Length = length;
        BytesSent = bytesSent;
    }

    public int Length
    {
        get => length;
        set => length = value;
    }
    public int BytesSent
    {
        get => bytesSent;
        set => bytesSent = value;
    }
}
