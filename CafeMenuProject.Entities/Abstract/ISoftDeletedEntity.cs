namespace CafeMenuProject.Entities.Abstract
{
    public interface ISoftDeletedEntity
    {
        bool IsDeleted { get; set; }
    }
}
