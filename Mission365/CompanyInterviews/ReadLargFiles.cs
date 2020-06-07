using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructureAlgorithm.CompanyInterviews

{
    /// <summary>
    /// echo "This is just a sample line appended to create a big file.. " > dummy.txt
    ///for /L %i in (1,1,24) do type dummy.txt >> dummy.txt
    /// </summary>
    [TestClass]
    public class ReadLargFiles
    {
        [TestMethod]
        public void MyTestMethod()
        {

            using (StreamReader sw = new StreamReader(@"c:\users\anshu\dummy.txt"))
            {
                double count = 0;
                string line = "";
                while ((line = sw.ReadLine()) != null)
                {
                    if (line.Contains("sample line appended"))
                    {
                        count++;
                    }
                }
            }

            //    int max = 33554432;
            //    byte[] buffer = new byte[max];
            //    double count = 0;
            //        using (FileStream fs = File.OpenRead(@"c:\users\anshu\dummy.txt"))
            //        {
            //            using (BufferedStream bs = new BufferedStream(fs))
            //            {
            //                var memoryStream = new MemoryStream(buffer);
            //var stream = new StreamReader(memoryStream);
            //                while (bs.Read(buffer, 0, max) != 0)
            //                {
            //                    memoryStream.Seek(0, SeekOrigin.Begin);
            //                    string line;
            //                    while ((line = stream.ReadLine()) != null)
            //                    {
            //                        if (line.Contains("sample line appended"))
            //                        {
            //                            count++;
            //                        }
            //                    }
            //                }
            //            }


            //        }

            //const int MAX_BUFFER = 33554432; //32MB
            //byte[] buffer = new byte[MAX_BUFFER];
            //int bytesRead;
            //int count = 0;
            //using FileStream fs = File.Open(@"c:\users\anshu\dummy.txt", FileMode.Open, FileAccess.Read);

            //using BufferedStream bs = new BufferedStream(fs);
            //string line;
            //while ((bytesRead = bs.Read(buffer, 0, MAX_BUFFER)) != 0) //reading only 32mb chunks at a time
            //{
            //    var stream = new StreamReader(new MemoryStream(buffer));
            //    while ((line = stream.ReadLine()) != null)
            //    {
            //        if(line.Contains("sample line appended"))
            //        {
            //            count++;
            //        }
            //    }

            //}
        }

    }

}
