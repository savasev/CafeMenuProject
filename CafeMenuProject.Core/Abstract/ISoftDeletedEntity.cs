namespace CafeMenuProject.Core.Abstract
{
    /// <summary>
    /// Soft deleted entity interface
    /// </summary>
    public interface ISoftDeletedEntity
    {
        bool IsDeleted { get; set; }
    }
}
