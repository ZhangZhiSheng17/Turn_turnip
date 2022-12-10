using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 关卡系统
/// </summary>
public class Levelsystem : IGameSystem, IObserver
{
    List<ItemGame> m_Gameitem = new List<ItemGame>();
    public int m_RaunTa = 0;
    public int m_FaTa = 0;
    private int playerindex = 0;
    private int enemyindex = 0;

    public Levelsystem(Facade facade) : base(facade)
    {
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
        Initialize();
    }

    public override void Initialize()
    {
        Refresh();
        m_FaTa = m_Facade.GetFaTa();
    }

    public void Refresh()
    {
        m_Gameitem.Clear();
        List<GameObject> map = m_Facade.GetMap();
        for (int i = 0; i < map.Count; i++)
        {
            m_Gameitem.Add(new ItemGame());
        }

        for (int i = 0; i < m_Gameitem.Count; i++)
        {
            m_Gameitem[i].CreGame(map[i]);
        }
    }

    public List<string> listNotification()
    {
        List<string> list = new List<string>()
        {
            EventOrder.Map_player,
            EventOrder.Map_trap,
        };
        return list;
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case "mapplayer":
                PLayerindex(notification);
                break;
            case "maptrap":
                m_RaunTa = m_Facade.GetRaunTa();
                int Ruanidnex = Random.Range(1, m_Gameitem.Count-1);
                Notification notif = new Notification();
                if (playerindex == m_FaTa || playerindex==Ruanidnex)
                {
                    notif.count = 0;
                }
                else if (enemyindex == m_FaTa || enemyindex== Ruanidnex)
                {
                    notif.count = 1;
                }
                else
                {
                    notif.count = 2;
                }
                notif.index = Ruanidnex;
                Debug.Log(Ruanidnex);
                MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Trap_index, notif);
              //  Maptrap(notification);
                break;
        }
    }

    // private void Maptrap(Notification notification)
    // {
    // }

    private void PLayerindex(Notification notification)
    {
        if (notification.count == 0)
        {
            playerindex = notification.index;
        }
        else
        {
            enemyindex = notification.index;
        }

        m_RaunTa = m_Facade.GetRaunTa();
        if (playerindex == enemyindex)
        {
            Notification noti = new Notification();
            noti.count = 1;
            noti.index = notification.count;
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Player_Forward, noti);
            noti.Clear();
        }
        

        if (playerindex == m_RaunTa || enemyindex == m_RaunTa)
        {
            Notification nos=new Notification();
            nos.index = notification.count;
            MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Reduction_blood,nos);
        }
    }

    public override void Update()
    {
    }
}