namespace ChickenPanic.Core
{
    public interface ICollisionable
    {
        bool HasCollided(ICollisionable other);
    }
}
