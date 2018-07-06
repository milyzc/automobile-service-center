using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStoreTest
{
    public class BaseEntity: TableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate {get; set;}
		public DateTime UpdateDate { get; set; }
		public string CreatedBy { set; get; }
		public string UpdatedBy { get; set; }
    }
}
