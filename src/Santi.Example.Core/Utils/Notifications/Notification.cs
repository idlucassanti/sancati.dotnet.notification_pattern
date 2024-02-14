namespace Santi.Example.Core.Utils.Notifications
{
    public class Notification
    {
        public Notification(string key, string messsage)
        {
            Key = key;
            Message = messsage;
        }

        public string Key { get; set; }

        public string Message { get; set; }
    }
}
