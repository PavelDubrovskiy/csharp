namespace Mfc.Health.Corner.Common
{
    public class ApplicationSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ConfirmEmailUrl { get; set; }
        public AuthOptions AuthOptions { get; set; }
        public EmailSettings EmailSettings { get; set; }
        public TelegramBotSettings TelegramBotSettings { get; set; }
        public ExamResultSendMailSettings ExamResultSendMailSettings { get; set; }
        public SendStatusInfoSettings SendStatusInfoSettings { get; set; }
    }
}
