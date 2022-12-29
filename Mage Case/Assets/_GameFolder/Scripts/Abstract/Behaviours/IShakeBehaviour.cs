using MageCase.Abstract.Behaviours;

namespace Magecase.Abstract.Ui.Behaviours
{
    public interface IShakeBehaviour
    {
        IShakeAttributes ShakeAttributes { get; }
        void Shake();
    }
}