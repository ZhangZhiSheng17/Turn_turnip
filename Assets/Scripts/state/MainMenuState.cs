
    using UnityEngine.UI;

    public class MainMenuState : ISceneState
    {
        public MainMenuState(SceneStateController controller) : base(controller)
        {
            this.SetName = "SampleScene";
        }

        public override void StateBegin()
        {
            Button tempbt = UITool.GetUIComponent<Button>("kai");
            if (tempbt!=null)
            {
                tempbt.onClick.AddListener(() =>
                {
                    m_Contorller.SetState(new BattleState(m_Contorller),"BattleScene");
                });
            }
        }
    }
