namespace MetaNotes.Services
{
    public interface ILogParser
    {
        bool TryParse(string str, out LogMessage message);
    }
}
