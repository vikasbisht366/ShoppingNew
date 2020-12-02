using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Cart
/// </summary>
/// [Serializable] 
[Serializable] 

public class Cart
{
	    private DateTime _dateCreated;
        private DateTime _lastUpdate;
        private List<CartItem> _items;

        public Cart()
        {
            if (this._items == null)
            {
                this._items = new List<CartItem>();
                this._dateCreated = DateTime.Now;
            }
        }

        public List<CartItem> Items
        {
         get { return _items;}
        set { _items = value;}
        }

        public void Insert(int ProductID, double Price, int Quantity, string ProductName, string ImageUrl, double Weight,string PWeight)
        {
            int ItemIndex = ItemIndexOfID(ProductID);
            if (ItemIndex == -1)
            {
                CartItem NewItem = new CartItem();
                NewItem.ProductID = ProductID;
                NewItem.Quantity = Quantity;
                NewItem.Price = Price;
                NewItem.ProductName = ProductName;
                NewItem.ImageUrl = ImageUrl;
                NewItem.Weight = Weight;
                NewItem.PWeight = PWeight;
                _items.Add(NewItem);
            }
            else
            {
                _items[ItemIndex].Quantity += 1;
            }
            _lastUpdate = DateTime.Now;
        }

        public void Update(int RowID, int ProductID, int Quantity, double Price, double Weight)
        {
            CartItem Item = _items[RowID];
            Item.ProductID = ProductID;
            Item.Quantity = Quantity;
            Item.Price = Price;
            Item.Weight = Weight;
            
            _lastUpdate = DateTime.Now;

            
        }

        public void Update(int ProductID,int Quantity)
        {
            _items[ItemIndexOfID(ProductID)].Quantity = Quantity;

        }


    
        public void DeleteItem(Int32 pid)
        {
           // _items.RemoveAt(rowID);
            _items.RemoveAt(ItemIndexOfID(pid));
            _lastUpdate = DateTime.Now;
        }

        private int ItemIndexOfID(int ProductID)
        {
            int index = 0;
            foreach (CartItem item in this._items)
            {
                if (item.ProductID == ProductID)
                {
                    return index;
                }
                index += 1;
            }
            return -1;
        }

        public double Total
        {
            get
            {
                double t = 0;
                if (_items == null)
                {
                    return 0;
                }
                foreach (CartItem Item in _items)
                {
                    t += Item.SubTotal;
                }
                return t;
            }

        }
        public double Totalweight
        {
            get
            {
                double tw = 0;
                if (_items == null)
                {
                    return 0;
                }
                foreach (CartItem Item in _items)
                {
                    tw += Item.WeightTotal;
                }
                return tw;
            }

        }
 
    }


