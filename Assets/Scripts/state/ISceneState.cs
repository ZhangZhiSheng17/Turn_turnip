
    public class ISceneState
    {
        private string m_StateName = "ISceneState";
        public string SetName
        {
            get { return m_StateName;}
            set { m_StateName = value; }
        }

        protected SceneStateController m_Contorller = null;

        public ISceneState(SceneStateController controller)
        {
            m_Contorller = controller;
        }

        public virtual void StateBegin()
        {
            
        }

        public virtual void StateUpdata()
        {
            
        }

        public virtual void StateEnd()
        {
            
        }
        
    }
