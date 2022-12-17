namespace Education.DataBase.Interfaces;

public interface IEntity<T>
{
    T Id { get; set; }
}