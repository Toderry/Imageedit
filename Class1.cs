using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                foreach (String ext in new String[] { "*.jpg", "*.png", "*.jpeg", "*.bmp"})
                {
                    foreach (FileInfo file in directoryInfo.GetFiles(ext, System.IO.SearchOption.TopDirectoryOnly))
                    {
                        list.Add(Inp(file.FullName));
                    }
                }
            }

            return list;
        }
        public static List<Bitmap> Resize(List<Bitmap> list, Size size)
        {
            var new_list = new List<Bitmap>();
            for (int i = 0; i < list.Count; i++)
            {
                Bitmap bNew = new Bitmap(size.Width, size.Height);

                Bitmap b = list[i];
                using (Graphics g = Graphics.FromImage((Image)bNew))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                    g.DrawImage(b, 0, 0, size.Width, size.Height);
                    new_list.Add(bNew);

                }                
            }
            return new_list;
        }
        public static void Upload(List<Bitmap> list, string path) {
            for (int i = 0; i < list.Count; i++)
            {
                Bitmap b = list[i];
                b.Save(path+"\\"+i.ToString()+".png", ImageFormat.Png);
            }
        }
        public static Size GetDimensions(Bitmap img) {

            Size dimensions = new Size(img.Height, img.Width);
            return dimensions;
        }
        public static Bitmap Inp(string path) {
            return new Bitmap(path);
        }
    }
}
