using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SenneGameWpf
{
    public static class Resources
    {
        static internal ImageSource GetImage(string psAssemblyName, string psResourceName)
        {
            var oUri = new Uri("pack://application:,,,/" + psAssemblyName + ";component/" + psResourceName, UriKind.RelativeOrAbsolute);
            return BitmapFrame.Create(oUri);
        }
    }
}