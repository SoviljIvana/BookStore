﻿using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.Requests.Books
{
    [ExcludeFromCodeCoverage]
    public class AddBookRequest
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid CategoryId { get; set; }
    }
}