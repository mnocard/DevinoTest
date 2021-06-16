using System.Text.Json.Serialization;

namespace DevinoTest.Dto
{
    /// <summary>Класс обертка для получаемого с сервера ответа</summary>
    public class SmsRootobject
    {
        [JsonPropertyName("result")]
        public SmsResult[] Result { get; set; }
    }

    /// <summary>Результат отправки сообщения</summary>
    public class SmsResult
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        [JsonPropertyName("segmentsId")]
        public object SegmentsId { get; set; }

        [JsonPropertyName("reasons")]
        public SmsReason[] Reasons { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    /// <summary>Массив ошибок, произошедших во время обработки сообщения.</summary>
    public class SmsReason
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("_ref")]
        public string Ref { get; set; }
    }
}