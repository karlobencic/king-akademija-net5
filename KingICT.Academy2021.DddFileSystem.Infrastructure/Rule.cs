namespace KingICT.Academy2021.DddFileSystem.Infrastructure
{
    public class Rule
    {
        public string Code { get; }
        public string Message { get; }

        public Rule(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
