
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneStateController
    {
        private ISceneState m_State;
        private bool m_bRunBegin = false;

        public SceneStateController()
        {
            
        }

        public void SetState(ISceneState state,string name)
        {
            m_bRunBegin = false;
            LoadScence(name);
            if (m_State!=null)
            {
                m_State.StateEnd();
            }

            m_State = state;
        }

        private void LoadScence(string name)
        {
            if (name==null|| name.Length==0)
            {
                return;
            }

            SceneManager.LoadScene(name);
        }

        public void StateUpdate()
        {
            if (Application.isLoadingLevel)
            {
                return;
            }

            if (m_State!=null&&m_bRunBegin==false)
            {
                m_State.StateBegin();
                m_bRunBegin = true;
            }

            if (m_State!=null)
            {
                m_State.StateUpdata();
            }
        }
        
    }
