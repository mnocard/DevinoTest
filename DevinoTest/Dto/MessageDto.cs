namespace DevinoTest.Dto
{
    public class RootMesagesDto
    {
        public MessageDto[] messages { get; set; }
    }

    public class MessageDto
    {
        public string from { get; set; }
        public string to { get; set; }
        public string text { get; set; }
    }
}
