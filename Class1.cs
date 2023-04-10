using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imageedit
{
    public static class Imageeditor
    {
        public static List<Bitmap> Load(string path)
        {
            List<Bitmap> list = new List<Bitmap>();
            var BT = new Bitmap(@"C:\Users\Андрей Родыгин\Desktop\in\Снимок экрана (1).png");
            list.Add(BT);
            return list;
        }
    }
}
