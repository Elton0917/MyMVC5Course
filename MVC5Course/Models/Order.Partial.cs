namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(OrderMetaData))]
    public partial class Order : IValidatableObject
    {
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if(String.IsNullOrEmpty(this.OrderStatus))
            {
                yield return new ValidationResult("必須輸入狀態");
            }
        }
    }
    
    public partial class OrderMetaData
    {
        [Required]
        public int OrderId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        [MyValidation]
        public Nullable<decimal> OrderTotal { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        public string OrderStatus { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
