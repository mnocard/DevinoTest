using System.Text.Json.Serialization;

namespace DevinoTest.Dto
{
    /// <summary>Класс обертка для отправляемых на сервер сообщений</summary>
    public class RootMesagesDto
    {
        [JsonPropertyName("messages")]
        public MessageDto[] Messages { get; set; }
    }

    /// <summary>Отправляемое смс сообщение.</summary>
    public class MessageDto
    {
        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("to")]
        public string To { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
