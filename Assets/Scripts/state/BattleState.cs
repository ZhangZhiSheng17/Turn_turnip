 public class BattleState : ISceneState
    {
        public BattleState(SceneStateController controller) : base(controller)
        {
            this.SetName = "BattleState";
        }

        public override void StateBegin()
        {
            Facade.Instance.Initinal();
        }

        public override void StateUpdata()
        {
            Facade.Instance.Update();
            if (Facade.Instance.ThisGame())
            {
                m_Contorller.SetState(new MainMenuState(m_Contorller), "SampleScene");
            }
        }

        public override void StateEnd()
        {
            Facade.Instance.End();
        }
    }
