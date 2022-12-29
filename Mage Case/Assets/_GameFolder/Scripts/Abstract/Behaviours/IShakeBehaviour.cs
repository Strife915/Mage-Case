using MageCase.Abstract.Behaviours;

namespace MageCase.Abstract.Ui.Behaviours
{
    public interface IShakeBehaviour
    {
        IShakeAttributes ShakeAttributes { get; }
        void Shake();
    }
}