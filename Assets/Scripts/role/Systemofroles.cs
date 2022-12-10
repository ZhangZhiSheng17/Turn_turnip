using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色系统
/// </summary>
public class Systemofroles : IGameSystem, IObserver
{
    List<CharacterFactory> m_Game = new List<CharacterFactory>();
    private int index;
    private CharacterFactory m_currGame;
    private int count = -1;

    public Systemofroles(Facade facade) : base(facade)
    {
        MessageCenterByObserver.Instance().AddMessage(listNotification(), this);
        Initialize();
    }

    public override void Initialize()
    {
        AddPlayer(new ICharacter("player"));
        AddPlayer(new ICharacter("enem"));
        m_currGame = m_Game[index];
    }

    public void AddPlayer(CharacterFactory player)
    {
        if (!m_Game.Contains(player))
        {
            player.CretPlay();
            player.GetMap(m_Facade.GetMap());
            m_Game.Add(player);
        }
        else
        {
            Debug.Log(player.GetName() + "已经存在");
        }
    }

    public override void Update()
    {
        for (int i = 0; i < m_Game.Count; i++)
        {
            m_Game[i].Update();
        }
    }

    public override void Release()
    {
    }

    public List<string> listNotification()
    {
        List<string> list = new List<string>()
        {
            EventOrder.Player_Forward,
            EventOrder.Reduction_blood
        };

        return list;
    }

    public void HandleNotification(string key, Notification notification)
    {
        switch (key)
        {
            case "playerforward":
                Playerform(notification);
                break;
            case "Reductionblood":
                Reductionblood(notification);
                break;
        }
    }

    private void Reductionblood(Notification notification)
    {
        m_Game[notification.index].ReductionHP();
        m_Game[notification.index].Initialposition();
    }

    private void Playerform(Notification notification)
    {
        if (notification.index != 4)
        {
            Debug.Log("对齐了前进一步");
            count = 0;
        }
        else
        {
            count += 1;
        }

        if (count == 0)
        {
            m_Game[count].GetMap(m_Facade.GetMap());
            m_Game[count].Move(notification.count, count);
        }
        else
        {
            m_Game[count].GetMap(m_Facade.GetMap());
            m_Game[count].Move(notification.count, count);
            count = -1;
        }
    }
}