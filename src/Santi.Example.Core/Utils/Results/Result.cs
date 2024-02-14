namespace Santi.Example.Core.Utils.Results
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        public List<string> Erros { get; set; }
    }
}
