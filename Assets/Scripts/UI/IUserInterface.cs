
    using UnityEngine;

    public abstract class IUserInterface
    {
        protected Facade m_Facade = null;
        public IUserInterface(Facade facade)
        {
            m_Facade = facade;
        }
        public virtual void Initialize(){}
        public virtual void Release(){}
        public virtual void Update(){}
    }
