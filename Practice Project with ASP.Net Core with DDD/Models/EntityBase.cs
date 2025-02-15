namespace Practice_Project_with_ASP.Net_Core_with_DDD.Models
{
	public abstract class EntityBase
	{
		public Guid Id { get; private init; } = Guid.NewGuid();
		public DateTimeOffset Created { get; private set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.UtcNow;

		public void UpdateLastModified()
		{
			LastModified = DateTimeOffset.UtcNow;
		}
	}
}
