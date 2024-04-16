﻿namespace BookStore.Application.DTOs
{
    public class OrderRepresentation
    {
        public Guid Id { get; set; }
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? City { get; set; }
        public string? TotalAmount { get; set; }
        public string? Status { get; set; }
        public List<BookRepresentation>? Books { get; set;}
    }
}
