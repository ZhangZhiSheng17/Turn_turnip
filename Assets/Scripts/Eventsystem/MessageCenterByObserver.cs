
    using System.Collections.Generic;

    public class MessageCenterByObserver : Singteone<MessageCenterByObserver>
    {
        public  Dictionary<string,List<IObserver>> MCDic=new Dictionary<string, List<IObserver>>();

        public void AddMessage(string key,IObserver observer)
        {
            if (MCDic.ContainsKey(key))
            {
                if (!MCDic[key].Contains(observer))
                {
                    MCDic[key].Add(observer);
                }
            }
            else
            {
                MCDic.Add(key,new List<IObserver>(){observer});
            }
        }

        public void AddMessage(List<string> keys,IObserver observer)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (MCDic.ContainsKey(keys[i]))
                {
                    if (!MCDic.ContainsKey(keys[i]))
                    {
                        MCDic[keys[i]].Add(observer);
                    }
                }
                else
                {
                    MCDic.Add(keys[i],new List<IObserver>(){observer});
                }
            }
        }
        public void RemoveMessage(string key, IObserver observer)
        {
            if (MCDic.ContainsKey(key))
            {
                if (MCDic[key].Contains(observer))
                {
                    MCDic[key].Remove(observer);
                }
                if (MCDic[key].Count==0)
                {
                    MCDic.Remove(key);
                }
            }
        }
        public void RemoveMessage(List<string> keys, IObserver observer)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (MCDic.ContainsKey(keys[i]))
                {
                    if (MCDic[keys[i]].Contains(observer))
                    {
                        MCDic[keys[i]].Remove(observer);
                    }
                    if (MCDic[keys[i]].Count == 0)
                    {
                        MCDic.Remove(keys[i]);
                    }
                }
            }
       
        }
        //派发
        public virtual void NotifyObserver(string eventKey,Notification notification)
        {
            if (MCDic.ContainsKey(eventKey))
            {
                foreach (var item in MCDic[eventKey])
                {
                    item.HandleNotification(eventKey,notification);
                }
            }
        
        }
        
        
    }
