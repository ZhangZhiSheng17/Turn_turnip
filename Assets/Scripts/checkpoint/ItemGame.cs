using UnityEngine;

/// <summary>
/// 地图模块类
/// </summary>
public class ItemGame 
{
    /// <summary>
    /// 玩家的当前下标
    /// </summary>
    public int Player_index;
    /// <summary>
    /// 敌人当前下标
    /// </summary>
    public int Enemy_index;
    /// <summary>
    /// 自己的物体
    /// </summary>
    public GameObject m_Gameitem = null;
    public void CreGame(GameObject gameObject)
    {
        m_Gameitem = gameObject;
    }
  
}