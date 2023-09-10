namespace MAIN.Dtos.Results
{
    public class ActionResultDto
    {
        public int ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public ActionResultMetaDto Meta { get; set; }
        public object Data { get; set; }
    }

    public class ActionResultDto<T>
    {
        public ActionResultMetaDto Meta { get; set; }
        public T Data { get; set; }
    }
}
