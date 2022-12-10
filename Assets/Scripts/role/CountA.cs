public class CountA : Strategy          
{
    public override int CountReduceHp(int hp)
    {
        return hp -= 1;
    }
}