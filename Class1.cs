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
            FileInfo[] lists;

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                // ищем в корневом каталоге
                lists= directoryInfo.GetFiles("*.(bmp|jpg|jpeg|png)", System.IO.SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in lists)
                {
                   
                    list.Add(Inp(file.FullName));
                }
            }

            return list;
        }
        public static Tuple<int, int> GetDimensions(Bitmap img) {

            Tuple<int, int> dimensions = new Tuple<int, int>(img.Height, img.Width);
            return dimensions;
        }
        public static Bitmap Inp(string path) {
            return new Bitmap(path);
        }
    }
}
