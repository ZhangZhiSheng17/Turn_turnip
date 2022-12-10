
    using UnityEngine;

    public class Notification
    {
        public string msg;
        public GameObject m_Game;
        public Vector3 Pos;
        public int count;
        public int index;

        public void Refresh(string msg,GameObject gameObject,Vector3 vector3,int m_int,int index)
        {
            this.msg = msg;
            this.m_Game = gameObject;
            this.Pos = vector3;
            this.count = m_int;
            this.index = index;

        }

        public void Clear()
        {
            msg = string.Empty;
            m_Game = null;
            Pos = Vector3.zero;
            count = 0;
            index = 0;
        }
        
        
    }
