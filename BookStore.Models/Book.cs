﻿namespace BookStore.Models
{
    public class Book : BaseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? PublishDate { get; set; }

        public Guid? InventoryId { get; set; }

        public virtual List<Category>? Categories { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
