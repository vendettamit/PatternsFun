namespace WcfRestAuthentication.Model
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}