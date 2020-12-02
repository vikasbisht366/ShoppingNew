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

/// <summary>
/// Summary description for CartItem
/// </summary>
/// 
[Serializable] 

public class CartItem
{
    private int _productID;
    private string _productName;
    private string _productDesc;
    private string _imageUrl;
    private int _quantity;
    private double _price;
    private double _subTotal;
    private string _pweight;
    private double _weight;
    private double _weightTotal;

    public CartItem()
    {
    }
    public CartItem(int ProductID, string ProductName,
          string ImageUrl, int Quantity, double Price, double Weight,string PWeight)
    {
        _productID = ProductID;
        _productName = ProductName;
        _imageUrl = ImageUrl;
        _quantity = Quantity;
        _price = Price;
        _weight = Weight;
        _subTotal = Quantity * Price;
        _weightTotal = Quantity * Weight;
        _pweight = PWeight;
    }
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            _productID = value;
        }
    }
    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }
    public string productDesc
    {
        get { return _productDesc; }
        set { _productDesc = value; }
    }
    public string ImageUrl
    {
        get { return _imageUrl; }
        set { _imageUrl = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public double SubTotal
    {
        get { return _quantity * _price; }
       

    }
    public double Weight
    {
        get { return _weight; }
        set { _weight = value; }
    }
    public string PWeight
    {
        get { return _pweight; }
        set { _pweight = value; }
    }
    public double WeightTotal
    {
        get { return _quantity * _weight; }


    }

}
