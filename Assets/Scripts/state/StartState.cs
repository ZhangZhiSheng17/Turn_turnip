public class StartState : ISceneState
{
    
    public StartState(SceneStateController controller) : base(controller)
    {
        this.SetName = "theOne";
    }

    public override void StateBegin()
    {
    }

    public override void StateUpdata()
    {
        m_Contorller.SetState(new MainMenuState(m_Contorller),"SampleScene");
    }
}