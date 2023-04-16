using Imageedit;
using NUnit;
using System.Drawing;

namespace Tests
{
    public class Tests
    {
        List<Bitmap> list;
       [SetUp]
        public void Setup()
        {
            list = Imageeditor.Load("C:\\Users\\Андрей Родыгин\\Desktop\\in");
            
        }

        [Test]
        public void Test1()
        {
            
            Assert.IsNotNull(list); 
            Assert.AreEqual(4, list.Count);
        }
        public void Test2()
        {
            Imageeditor.Resize(list);
            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
            Tuple<int, int> dimensions = new Tuple<int, int>(100,100);
            Assert.That(Imageeditor.GetDimensions(list[0]), Is.EqualTo(dimensions));
        }
        public void Test3()
        {
            string path = "C:\\Users\\Андрей Родыгин\\Desktop\\out";
            Imageeditor.Upload(list,path);
            int i = 0;
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                // ищем в корневом каталоге
                i += directoryInfo.GetFiles("*.(bmp|jpg|jpeg|png)", System.IO.SearchOption.TopDirectoryOnly).Length;
            }
            Assert.AreEqual(4, i);

        }

    }
}