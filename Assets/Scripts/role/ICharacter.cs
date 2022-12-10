using System;
using System.Collections;
using UnityEngine;
/// <summary>
/// 具体角色工厂
/// </summary>
public class ICharacter  : CharacterFactory
{
    private bool isGame = false;
    private int m_count;
    private int indexcount=0;
    private float times = Time.deltaTime;
    private int rw;
    public ICharacter(string name)
    {
       m_Name= name;
    }
    
    public override void CretPlay()
    {
        if (m_Name != null|| m_Name!="")
        {
            m_GameObejct = UnityTool.Game(m_Name);
            m_index = 0;
        }
    }

    public override void Update()
    {
        if (isGame)
        {
            times += Time.deltaTime;
            if (times>=1f)
            {
                indexcount += 1;
                if (indexcount==1)
                {
                    if (m_count>0&&m_count!=0)
                    {
                        mobile();   
                    }
                    else
                    {
                        times = 0;
                        indexcount = 0;
                        isGame = false;
                        Notification notification=new Notification();
                        notification.index = m_index;
                        notification.count = rw;
                        MessageCenterByObserver.Instance().NotifyObserver(EventOrder.Map_player,notification);
                        
                    }
                    m_count -= 1;
                }
                times = 0;
                indexcount = 0;
            }
        }
    }

    public override void Move(int count,int rw)
    {
        m_count = count;
        isGame = true;
        this.rw = rw;
    }

    public override void Initialposition()
    {
        Vector3 pos = map[0].transform.position;
        m_GameObejct.transform.position=new Vector3(pos.x,0.1f,pos.z);
        m_index = 0;
    }

    public void mobile()
    {
        m_index += 1;
        if (m_index>=map.Count-1)
        {
            m_index = map.Count - 1;
        }

        Vector3 pos = map[m_index].transform.position;
        m_GameObejct.transform.position=new Vector3(pos.x,0.1f,pos.z);
    }
    
}