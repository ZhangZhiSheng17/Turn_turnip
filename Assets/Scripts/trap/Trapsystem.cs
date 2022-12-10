using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 陷阱系统
/// </summary>
public class Trapsystem : IGameSystem, IObserver
{
    public Trapofabstraction m_Randomtrap;
    public Trapofabstraction m_Fixedtrap;
    private int m_Randomtrap_index = 0;
    private int m_Fixedtrap_index = 0;
    private int index = 0;
    public List<GameObject> map = new List<GameObject>();

    public Trapsystem(Facade facade) : base(facade)
    {
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
        Initialize();
    }

    public override void Initialize()
    {
        GameObject obj = UnityTool.FindGameObject("map");
        map = UnityTool.FindChildGameObject(obj);
        Debug.Log(map.Count);
        m_Randomtrap = new Randomtrap();
        m_Randomtrap.CreGame(UnityTool.FindGameObject("random"), Getindex("random"));
        m_Randomtrap_index = index;
        m_Fixedtrap = new Fixedtrap();
        m_Fixedtrap.CreGame(UnityTool.FindGameObject("fixed"), Getindex("fixed"));
        m_Fixedtrap_index = index;

        Debug.Log(m_Fixedtrap.GetName());
        Debug.Log(m_Randomtrap.GetName());
    }

    public List<GameObject> Getmap()
    {
        return map;
    }


    private int Getindex(string random)
    {
        for (int i = 0; i < map.Count; i++)
        {
            if (map[i].name == random)
            {
                index = i;
            }
        }

        return index;
    }

    public List<string> listNotification()
    {
        List<string> list = new List<string>()
        {
            EventOrder.Trap_index
        };

        return list;
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case "Trapindex":
                Setindex(notification.index,notification.count);
                break;
        }
    }

    private void Setindex(int notificationIndex,int count=2)
    {
        if (count!=2)
        {
            Notification nos=new Notification();
            nos.index = count;
          MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Reduction_blood,nos);
        }
        if (notificationIndex!=m_Fixedtrap_index)
        {
            Vector3 pos = map[notificationIndex].transform.position;
            map[notificationIndex].transform.position = map[m_Randomtrap_index].transform.position;
            map[m_Randomtrap_index].transform.position = pos;

            // var temp = map[m_Randomtrap_index];
            // var temps=map[notificationIndex];
            // map.Remove(map[m_Randomtrap_index]);
            // map.Remove(map[notificationIndex]);
            // map.Insert(notificationIndex,temp);
            // map.Insert(m_Randomtrap_index,temps);
            //
            //
            //     // map[m_Randomtrap_index] = map[notificationIndex];
            //     // map[notificationIndex] = temp;
            Swap(map,m_Randomtrap_index,notificationIndex); 
                m_Randomtrap.Setindex(notificationIndex);
        }
        m_Randomtrap_index = m_Randomtrap.Getindex();
        Debug.Log(m_Randomtrap.Getindex());
        m_Fixedtrap_index = m_Fixedtrap.Getindex();
    }
    private static List<T> Swap<T>(List<T> list, int index1, int index2)
    {
        var temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
        return list;
    }
    public int GetRaunTa()
    {
        return m_Randomtrap_index;
    }

    public int GetFaTa()
    {
        return m_Fixedtrap_index;
    }
}