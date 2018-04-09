using Livraria.Common.Resources;
using Livraria.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Domain.Models
{
    public class Author
    {
        #region Ctor
        protected Author() { }
        public Author(string name)
        {
            this.Name = name;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; private set; }
        #endregion

        #region Methods
        public void ValidateAuthor()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 100, Errors.InvalidName);
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}
