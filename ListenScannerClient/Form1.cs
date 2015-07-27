using ListenScannerClient.ScannerSvcRef;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using pdf = iTextSharp.text;

namespace ListenScannerClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEscanear_Click(object sender, EventArgs e)
        {
            ScannerServiceClient svc = new ScannerServiceClient();
            svc.Endpoint.Address = new EndpointAddress(this.txtUrl.Text);
            this.btnEscanear.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                svc.Open();
            }
            catch
            {
                MessageBox.Show("Verificar que el servicio se encuentre activo");
                return;
            }

            Document doc = svc.ScanDocuments();
            if (doc != null && doc.Image != null && doc.Image.Length > 0)
            {
                SaveDocument(doc);
            }
            this.btnEscanear.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtNombre.Text = @"doc-93859481-";
            this.txtUrl.Text = @"http://localhost:8181/ScannerSvc";
            this.txtPath.Text = @"c:\\temp";
        }

        private Image ByteArrayToImage(byte[] m_byteArrayIn)
        {
            MemoryStream oMemoryStream = new MemoryStream(m_byteArrayIn);
            Image oImage = Image.FromStream(oMemoryStream);
            return oImage;
        }

        private void SaveDocument(Document doc)
        {
            pdf.Document pdfDoc = new pdf.Document();
            Image img = ByteArrayToImage(doc.Image);
            //img.Save(this.txtPath.Text + @"\" + this.txtNombre.Text + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".jpeg", ImageFormat.Jpeg);
            try
            {

                pdf.pdf.PdfWriter.GetInstance(pdfDoc, new FileStream(this.txtPath.Text + @"\" + this.txtNombre.Text + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".pdf", FileMode.Create));
                //pdfDoc.SetMargins(0, 0, 0, 0);
                pdfDoc.Open();
                pdf.Image pdfImage = pdf.Image.GetInstance(img, ImageFormat.Jpeg);
                pdfImage.ScaleToFit(pdfDoc.PageSize.Width - pdfDoc.LeftMargin - pdfDoc.RightMargin, pdfDoc.PageSize.Height - pdfDoc.BottomMargin - pdfDoc.TopMargin);
                pdfDoc.Add(pdfImage);
            }
            finally
            {
                pdfDoc.Close();
            }
        }
    }
}
