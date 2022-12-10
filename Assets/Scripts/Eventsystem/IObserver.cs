
    using System.Collections.Generic;

    public interface IObserver
    {
        List<string> listNotification();
        void HandleNotification(string key, Notification notification);
    }
