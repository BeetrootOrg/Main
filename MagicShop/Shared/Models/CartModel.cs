using Shared.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<BaseEntityModel> Lines
        {
            get { return _cartCollection; }
        }
    }
}
