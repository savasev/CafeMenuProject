namespace CafeMenuProject.Core.Entities
{
    /// <summary>
    /// Product property entity
    /// </summary>
    public class ProductProperty
    {
        public int ProductPropertyId { get; set; }

        public int ProductId { get; set; }

        public int PropertyId { get; set; }
    }
}
