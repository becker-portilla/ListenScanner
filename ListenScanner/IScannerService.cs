using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Drawing;
using ListenScanner;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;

namespace ListenScanner
{
    [ServiceContract]
    [ServiceKnownType(typeof(Document))]
    public interface IScannerService
    {
        [OperationContract]
        Document ScanDocuments();
        
    }

    public class ScannerService : IScannerService
    {
        public Document ScanDocuments()
        {
            //List<string> devices = WIAScanner.GetDevices();

            try
            {
              //  if (devices.Count > 0)
                //{
                    List<Image> images = WIAScanner.Scan(Main.DeviceID);
                    if (images.Count > 0)
                        return new Document() { Image = ImageToByteArray(images.FirstOrDefault()) };
                    //foreach (Image image in images)
                    //{
                    //    image.Save(sharedFolder + name + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);
                    //}
                //}
            }
            catch (Exception exc)
            {
               // MessageBox.Show(exc.Message);
            }
            //scan and save on shared folder

            return null;
        }
        
        private byte[] ImageToByteArray(System.Drawing.Image m_imageIn)
        {

            MemoryStream oMemoryStream = new MemoryStream();
            // ImageFormat could be other formats like bmp,gif,icon,png etc.
            m_imageIn.Save(oMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return oMemoryStream.ToArray();

        }
        private Image ByteArrayToImage(byte[] m_byteArrayIn)
        {
            MemoryStream oMemoryStream = new MemoryStream(m_byteArrayIn);
            Image oImage = Image.FromStream(oMemoryStream);
            return oImage;
        }
    }

    public class Document
    {
        public byte[] Image { get; set; }
    }
}
