
    public abstract class IGameSystem
    {
        protected Facade m_Facade = null;

        public IGameSystem(Facade facade)
        {
            m_Facade = facade;
        }
        public virtual void Initialize(){}
        public virtual void Release(){}
        public virtual void Update(){} }
