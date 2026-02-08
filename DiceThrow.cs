namespace Losowanie
{
    public class DiceThrow(int id, List<int> pips)
    {
        public int Id { get; set; } = id;
        public List<int> Pips { get; set; } = pips;
        public int Sum => Pips.Sum();
    }
}