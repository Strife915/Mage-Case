namespace MageCase.Abstract.Attributes
{
    public interface IShakeAttributes
    {
        public int Vibrato { get; }
        public float Duration { get; }
        public float DistanceMultiplier { get; }
    }
}