using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ResizeImage;
/// <summary>
/// Summary description for clsImageResize
/// </summary>
/// 
public class clsImageResize
{
    public clsImageResize()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ResizeImage(string tFname, string tempPath, string outputFilePath, int widthToConvert, int heightToConvert)
    {
        string fPath = tempPath;
        System.Drawing.Image img;
        System.Drawing.Image imgThumb;
        System.Drawing.Graphics grph;

        img = System.Drawing.Image.FromFile(fPath);
        int wdth = 0; int hgth = 0;
        if (img.Width > 210)
        {
            wdth = 210;
            hgth = img.Height;
        }
        else
        {
            wdth = img.Width;
            hgth = img.Height;
        }
        imgThumb = new Bitmap(wdth, hgth);
        grph = Graphics.FromImage(imgThumb);
        System.Drawing.Rectangle rec = new Rectangle(0, 0, wdth, hgth);
        grph.DrawImage(img, rec);
        imgThumb.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

        imgThumb.Dispose();
        img.Dispose();
        grph.Dispose();

    }
    public void ResizePhoto(string tFname, string tempPath, string outputFilePath, int widthToConvert, int heightToConvert)
    {
        string fPath = tempPath;
        System.Drawing.Image img;
        System.Drawing.Image imgThumb;
        System.Drawing.Graphics grph;

        img = System.Drawing.Image.FromFile(fPath);
        int wdth = 0; int hgth = 0;
        if (img.Width > 100)
        {
            wdth = widthToConvert;
            hgth = heightToConvert;
        }
        else
        {
            wdth = img.Width;
            hgth = img.Height;
        }
        imgThumb = new Bitmap(wdth, hgth);
        grph = Graphics.FromImage(imgThumb);
        System.Drawing.Rectangle rec = new Rectangle(0, 0, wdth, hgth);
        grph.DrawImage(img, rec);
        imgThumb.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

        imgThumb.Dispose();
        img.Dispose();
        grph.Dispose();

    }

    public void FixedSize(string tFname, string tempPath, string outputFilePath, int Width, int Height)
    {
        System.Drawing.Image imgPhoto = System.Drawing.Image.FromFile(tempPath);
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;
        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);

        //if we have to pad the height pad both the top and the bottom
        //with the difference between the scaled height and the desired height
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = (int)((Width - (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = (int)((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        bmPhoto.Save(outputFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    }
}
