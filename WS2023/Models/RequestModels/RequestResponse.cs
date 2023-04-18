namespace WS2023.Models.RequestModels
{
    public class RequestResponse
    {
        public int statusCode { get; set; }
        public string content { get; set; }

        public RequestResponse() {}
        public RequestResponse(int statusCode, string content)
        {
            this.statusCode = statusCode;
            this.content = content;
        }
    }
}
