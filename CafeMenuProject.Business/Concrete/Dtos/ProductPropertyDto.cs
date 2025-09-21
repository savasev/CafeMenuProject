namespace CafeMenuProject.Business.Concrete.Dtos
{
    /// <summary>
    /// Product property dto
    /// </summary>
    public class ProductPropertyDto
    {
        public int ProductPropertyId { get; set; }

        public int ProductId { get; set; }

        public int PropertyId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
