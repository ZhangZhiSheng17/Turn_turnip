
    using UnityEngine;

    /// <summary>
    /// 抽象工厂
    /// </summary>
    public abstract class Trapofabstraction
    {
        protected GameObject m_Game = null;
        protected int m_index=0;
        protected string m_Name = "";

        public  Trapofabstraction()
        {
            
        }

        public  void CreGame(GameObject obj, int index)
        {
            if (obj!=null)
            {
                m_Name = obj.name;
                m_Game = obj;
                m_index = index;
            }
        }
        public string GetName()
        {
            return m_Name;
        }

        public GameObject GetGameObject()
        {
            return m_Game;
        }

        public int Getindex()
        {
            return m_index;
        }

        public void Setindex(int notificationIndex)
        {
            m_index = notificationIndex;
        }

        public abstract void Setatrap(int count);
    }
