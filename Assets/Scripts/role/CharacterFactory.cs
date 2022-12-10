using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 人物工厂抽象类
/// </summary>
public abstract class CharacterFactory
{
    protected string m_Name = "";
    protected GameObject m_GameObejct = null;
    protected int m_index = 0;
    protected int hp = 4;
    public List<GameObject> map = null;
    public CharacterFactory()
    {
        
    }
    public abstract void CretPlay();

    public string GetName()
    {
        return m_Name;
    }

    public int GetIndex()
    {
        return m_index;
    }

    public GameObject GetGameObject()
    {
        return m_GameObejct;
    }

    public int GetHp()
    {
        return hp;
    }

    public abstract void Update();
    public void GetMap(List<GameObject> getMap)
    {
        map = getMap;
    }
    public abstract void Move(int count,int rw);
    
    Client client = new Client();
    public  void ReductionHP()
    {
        client.SetStrategy(new CountA());
        hp=client.ExcuteCount(hp);
        Debug.Log("掉血了当前生命值"+hp);
    }

    public abstract void Initialposition();
}