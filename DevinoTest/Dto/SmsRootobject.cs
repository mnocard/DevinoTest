namespace DevinoTest.Dto
{
    public class SmsRootobject
    {
        public SmsResult[] result { get; set; }
    }

    public class SmsResult
    {
        public string code { get; set; }
        public string messageId { get; set; }
        public object segmentsId { get; set; }
        public SmsReason[] reasons { get; set; }
        public string description { get; set; }
    }

    public class SmsReason
    {
        public string key { get; set; }
        public string _ref { get; set; }
    }
}