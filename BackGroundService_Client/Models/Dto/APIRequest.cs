using static BackGrundTask_Utility.DS;

namespace BackGroundService_Client.Models.Dto
{
    public class APIRequest
    {
        public APITipo APITipo { get; set; } = APITipo.GET;

        public string Url { get; set; }

        public object Data { get; set; }

        public string Token { get; set; }
    }
}
