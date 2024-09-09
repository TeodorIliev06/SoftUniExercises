namespace P01.Stream_Progress;

public class StreamProgressInfo
{
    private StreamableFile file;

    public StreamProgressInfo(StreamableFile file)
    {
        this.file = file;
    }

    public int CalculateCurrentPercent()
    {
        return file.BytesSent * 100 / file.Length;
    }
}
