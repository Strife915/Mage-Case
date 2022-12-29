using MageCase.Abstract.Attributes;

namespace MageCase.Abstract.Ui.Behaviours
{
    public interface IShakeBehaviour
    {
        IShakeAttributes ShakeAttributes { get; }
        void Shake();
    }
}