using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 随机系统
/// </summary>
public class Stochastic_system : IGameSystem, IObserver
{
    private int index=0;
    public Stochastic_system(Facade facade) : base(facade)
    {
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
    }

    public override void Initialize()
    {
        
    }
    public List<string> listNotification()
    {
        List<string> list = new List<string>()
        {
            EventOrder.That_card,
        };

        return list;
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case "card":
                Randomvalue();
                break;
        }
    }

    public void Randomvalue()
    {
        index = Random.Range(1, 5);
        Debug.Log(index);
        if (index<4&& index!=4)
        {
            Notification data=new Notification();
            data.count = index;
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Figures_forward,data);
        }
        else 
        {
            Notification data=new Notification();
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Turn_turnip,data);
        }
    }
}