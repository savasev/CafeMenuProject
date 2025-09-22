namespace CafeMenuProject.Business.Concrete.Dtos
{
    /// <summary>
    /// Category with product count dto
    /// </summary>
    public class CategoryWithProductCountDto
    {
        #region Properties

        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public int TotalProductCount { get; set; }

        #endregion
    }
}
