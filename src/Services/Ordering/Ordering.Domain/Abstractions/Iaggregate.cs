namespace Ordering.Domain.Abstractions;

public interface Iaggregate<T> : Iaggregate, IEntity<T>
{
}

public interface Iaggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}