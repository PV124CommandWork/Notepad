using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using MediaColor = System.Windows.Media.Color;
namespace Notepad
{
    internal class ClassFont
    {
        public ClassFont()
        {

        }

        public static System.Windows.Media.FontFamily openFont()
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            return new System.Windows.Media.FontFamily(fontDialog.Font.Name);
        }
        //public static System.Windows.Media.SolidColorBrush openColor()
        //{
        //    ColorDialog oc = new ColorDialog();
        //    DialogResult result = oc.ShowDialog();
        //    if (result == System.Windows.Forms.DialogResult.OK)
        //    {
        //        MediaColor color = MediaColor.FromArgb(oc.Color.A, oc.Color.R, oc.Color.G, oc.Color.B);
        //        System.Windows.Media.SolidColorBrush solidColorBrush = new System.Windows.Media.SolidColorBrush(color);
        //        return solidColorBrush;
        //    }
            
        //}
    }

    
}
