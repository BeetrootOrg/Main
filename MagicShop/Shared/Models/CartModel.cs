using Shared.Models.Base;

namespace Shared.Models
{
    public class CartModel
    {
        private List<BaseEntityModel> _cartCollection = new List<BaseEntityModel>();

        public void AddItem(BaseEntityModel BaseEntityModel)
        {
            _cartCollection.Add(BaseEntityModel);
        }

        public void RemoveItem(BaseEntityModel BaseEntityModel)
        {
            _cartCollection.RemoveAll(l => l.Id == BaseEntityModel.Id);
        }

        public decimal ComputeTotalValue()
        {
            return _cartCollection.Sum(e => e.Price);

        }
        public void Clear()
        {
            _cartCollection.Clear();
        }

        public IEnumerable<BaseEntityModel> GetItems
        {
            get { return _cartCollection; }
        }
    }
}
