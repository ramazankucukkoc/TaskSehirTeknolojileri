namespace TaskSehirTeknolojileri_Core.Utilities.Results
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
    }
}
