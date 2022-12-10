
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 外观
/// </summary>
    public class Facade
    {
        private static Facade _instance;
        public static Facade Instance
        {
            get
            {
                if (_instance == null)			
                    _instance = new Facade();
                return _instance;
            }
        }

        public bool isGame = false;
        
      
        /// <summary>
        /// 关卡系统
        /// </summary>
        private Levelsystem m_Levelsystem = null;
        /// <summary>
        /// 角色系统
        /// </summary>
        private Systemofroles m_Systemofroles = null;
        /// <summary>
        /// 随机系统
        /// </summary>
        private Stochastic_system m_Stochastic_system = null;
        /// <summary>
        /// 陷阱系统
        /// </summary>
        private Trapsystem m_Trapsystem = null;
        
        
        
        /// <summary>
        /// UI界面
        /// </summary>
        private UIsystem m_UIsystem = null;
        
        
        public void Initinal()
        {
            m_Trapsystem=new Trapsystem(this);
            isGame = false;
            m_UIsystem=new UIsystem(this);
            m_Levelsystem = new Levelsystem(this);
            m_Stochastic_system=new Stochastic_system(this);
            m_Systemofroles=new Systemofroles(this);
        
        }

        public void End()
        {
            m_Trapsystem.Release();
            m_UIsystem.Release();
            m_Levelsystem.Release();
            m_Stochastic_system.Release();
            m_Systemofroles.Release();
           
        }

        public void Update()
        {
            m_Trapsystem.Update();
            m_Stochastic_system.Update();
            m_UIsystem.Update();
            m_Systemofroles.Update();
        }

        public List<GameObject> GetMap()
        {
            return m_Trapsystem.Getmap();
        }
        public bool ThisGame()
        {
            return isGame;
        }

        public int GetRaunTa()
        {
           return  m_Trapsystem.GetRaunTa();
        }

        public int GetFaTa()
        {
            return   m_Trapsystem.GetFaTa();
        }
    }
