public class Client
{
    Strategy m_Strategy = null;


    public void SetStrategy(Strategy strategy)
    {
        m_Strategy = strategy;
    }


    public int ExcuteCount(int hp)
    {
        return m_Strategy.CountReduceHp(hp);
    }

}