namespace Roslyner.Domain.Interfaces
{
    public interface IClassInstance<out T>
    {
        T Instance();
    }
}
