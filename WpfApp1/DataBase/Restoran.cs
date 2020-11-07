using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp1.DataBase
{
    partial class Kategoria
    {
        
    }

    partial class Bluda
    {
            public BitmapImage print { get 
            {
                if (Image==null)
                    return null;

                using (var ms = new System.IO.MemoryStream(this.Image.ToArray()))
                    {
                        var image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad; // here
                        image.StreamSource = ms;
                        image.EndInit();
                        return image;
                    };
            } 
        }
    }
}


