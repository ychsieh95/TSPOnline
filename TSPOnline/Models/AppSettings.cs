namespace TSPOnline.Models
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        
        public GoogleReCaptcha GoogleReCaptcha { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class GoogleReCaptcha
    {
        public string SiteKey { get; set; }
        public string Secret { get; set; }
    }
}
