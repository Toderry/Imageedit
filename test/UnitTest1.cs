using Imageedit;
using NUnit;
using System.Drawing;

namespace Tests
{
    public class Tests
    {
        List<Bitmap> list;
        Size size;
        string path;


        [Test]
        public void Test1()
        {
            list = Imageeditor.Load("C:\\Users\\������ �������\\Desktop\\in");
            Assert.IsNotNull(list); 
            Assert.AreEqual(4, list.Count);
        }



        [SetUp]
        public void Setup2()
        {
            list = Imageeditor.Load("C:\\Users\\������ �������\\Desktop\\in");
            size = new Size(100, 100);

        }

        [Test]
        public void Test2()
        {
            
            list = Imageeditor.Resize(list,size);

            Assert.IsNotNull(list);
            Assert.AreEqual(4, list.Count);
            Assert.That(Imageeditor.GetDimensions(list[0]), Is.EqualTo(size));
            Assert.That(Imageeditor.GetDimensions(list[1]), Is.EqualTo(size));


        }

        [SetUp]
        public void Setup3()
        {
            list = Imageeditor.Load("C:\\Users\\������ �������\\Desktop\\in");
            size = new Size(100, 100);
            list = Imageeditor.Resize(list, size);

            path = "C:\\Users\\������ �������\\Desktop\\out";

        }
        [Test]
        public void Test3()
        {
           
            Imageeditor.Upload(list,path);

            int i = 0;
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                // ���� � �������� ��������
                i += directoryInfo.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly).Length;
            }
            Assert.AreEqual(4, i);
            Assert.That(Imageeditor.GetDimensions(list[0]), Is.EqualTo(size));


        }

    }
}