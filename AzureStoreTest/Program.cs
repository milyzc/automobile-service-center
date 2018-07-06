using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

// Namespace for Table storage types

namespace AzureStoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to Storage Account
            var storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            //Create the table Book, if it not exists
            var tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Book");
            table.CreateIfNotExistsAsync();

            //Create a Book instance
            Book book = new Book
            {
                Author = "Rami",
                BookName = "ASP.NET Core With Azure",
                Publisher = "APress",
                BookId = 1,
            };
            book.RowKey = book.BookId.ToString();
            book.PartitionKey = book.Publisher;
            book.CreatedDate = DateTime.UtcNow;
            book.UpdateDate = DateTime.UtcNow;

            //Insert and Execute operations
            TableOperation insertOperation = TableOperation.Insert(book);
            table.ExecuteAsync(insertOperation);

            Console.ReadLine();
        }
    }
}