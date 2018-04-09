using Livraria.Common.Resources;
using Livraria.Common.Validation;

namespace Livraria.Domain.Models
{
    public class Category
    {
        #region Ctor
        protected Category() { }
        public Category(string name)
        {
            this.Name = name;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; private set; }
        #endregion

        #region Methods
        public void ValidateCategory()
        {
            AssertionConcern.AssertArgumentLength(this.Name, 3, 150, Errors.InvalidName);
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }
        #endregion
    }
}