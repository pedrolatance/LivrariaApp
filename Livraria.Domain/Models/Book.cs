using Livraria.Common.Resources;
using Livraria.Common.Validation;
using System;

namespace Livraria.Domain.Models
{
    public class Book
    {
        #region Ctor
        protected Book() { }
        public Book(string title, string isbn,int storageQty)
        {
            this.Title = title;
            this.ISBN = isbn;
            this.StorageQty = storageQty;
        }
        #endregion

        #region Properties
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int StorageQty { get; private set; }

        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public Author Author { get; set; }
        #endregion

        #region Methods
        public void ValidateBook()
        {
            AssertionConcern.AssertArgumentLength(this.Title, 3, 200, Errors.InvalidBookTitle);
            AssertionConcern.AssertArgumentLength(this.ISBN, 10, 12, Errors.InvalidIsbn);
            AssertionConcern.AssertArgumentNotNull(this.StorageQty, Errors.InformStorageQty);
        }

        public void ChangeDetails(string title, string isbn, int storageQty)
        {
            this.Title = title;
            this.ISBN = isbn;
            this.StorageQty = storageQty;
        }
        #endregion


    }
}
