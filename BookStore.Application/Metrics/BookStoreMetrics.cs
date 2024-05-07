﻿using System.Diagnostics.Metrics;

namespace BookStore.Application.Metrics
{
    public class BookStoreMetrics
    {
        // Books meters
        private readonly Counter<int> _booksAddedCount;
        private readonly Counter<int> _booksDeletedCount;
        private readonly Counter<int> _booksUpdatedCount;
        private readonly UpDownCounter<int> _totalBooksUpDownCounter;

        // Categories meters
        private readonly Counter<int> _categoriesAddedCount;
        private readonly Counter<int> _categoriesDeletedCount;
        private readonly Counter<int> _categoriesUpdatedCount;
        private int _totalCategories = 0;

        // Order meters
        private readonly Histogram<decimal> _ordersPriceHistogram;
        private readonly Histogram<int> _numberOfBooksPerOrderHistogram;
        private int _ordersCancelled = 0;
        private readonly Counter<int> _totalOrdersCounter;

        public BookStoreMetrics(IMeterFactory meterFactory)
        {
            // metrics_bookstore_books_added_count
            var meter = meterFactory.Create("Metrics.BookStore");

            _booksAddedCount = meter.CreateCounter<int>("books_added_count");
            _booksDeletedCount = meter.CreateCounter<int>("books_deleted_count");
            _booksUpdatedCount = meter.CreateCounter<int>("books_updated_count");
            _totalBooksUpDownCounter = meter.CreateUpDownCounter<int>("books_total_count");

            _categoriesAddedCount = meter.CreateCounter<int>("categories_added_count");
            _categoriesDeletedCount = meter.CreateCounter<int>("categories_deleted_count");
            _categoriesUpdatedCount = meter.CreateCounter<int>("categories_updated_count");
            
            _ordersPriceHistogram = meter.CreateHistogram<decimal>("orders_price");
            _numberOfBooksPerOrderHistogram = meter.CreateHistogram<int>("orders_number_of_books");

            _totalOrdersCounter = meter.CreateCounter<int>("total_orders_count");
        }

        // Books meters
        public void AddBook() => _booksAddedCount.Add(1);
        public void DeleteBook() => _booksDeletedCount.Add(1);
        public void UpdateBook() => _booksUpdatedCount.Add(1);
        public void IncreaseTotalBooks() => _totalBooksUpDownCounter.Add(1);
        public void DecreaseTotalBooks() => _totalBooksUpDownCounter.Add(-1);

        // Categories meters
        public void AddCategory() => _categoriesAddedCount.Add(1);
        public void DeleteCategory() => _categoriesDeletedCount.Add(1);
        public void UpdateCategory() => _categoriesUpdatedCount.Add(1);

        // Orders meters
        public void RecordOrderTotalPrice(decimal price) => _ordersPriceHistogram.Record(price);
        public void RecordNumberOfBooks(int amount) => _numberOfBooksPerOrderHistogram.Record(amount);
        public void IncreaseOrdersCanceled() => _ordersCancelled++;
        public void IncreaseTotalOrders(string city) => _totalOrdersCounter.Add(1, KeyValuePair.Create<string, object>("City", city)!);
    }
}