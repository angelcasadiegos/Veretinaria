using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Infraestructura
{
    public class DocumentoPdf
    {

        public DocumentoPdf()
        {           

        }
        public void GuardarPdf(IList<Cliente> clientes, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            Document document = new Document(iTextSharp.text.PageSize.LETTER, 40, 40, 40, 40);
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            document.AddAuthor("Aplicacion Pulsacion");
            document.Open();
            document.Add(new Paragraph("INFORME DE CLIENTES REGISTRADAS"));
            document.Add(new Paragraph("\n"));
            document.Add(LlenarTabla(clientes));
            document.Close();
        }
        private PdfPTable LlenarTabla(IList<Cliente> clientes)
        {
            PdfPTable tabla = new PdfPTable(6);
            tabla.AddCell(new Paragraph("Identificacion"));
            tabla.AddCell(new Paragraph("Nombre"));
            tabla.AddCell(new Paragraph("Telefono"));
            tabla.AddCell(new Paragraph("Email"));
            tabla.AddCell(new Paragraph("Direccion"));
            tabla.AddCell(new Paragraph("Fecha de Registro"));            
            foreach (var item in clientes)
            {
                tabla.AddCell(new Paragraph(item.Identificacion));
                tabla.AddCell(new Paragraph(item.Nombre));
                tabla.AddCell(new Paragraph(item.Telefono));
                tabla.AddCell(new Paragraph(item.Email));
                tabla.AddCell(new Paragraph(item.Direccion));
                tabla.AddCell(new Paragraph(item.FechaRegistro.ToString()));
                
            }

            return tabla;

        }

    }
}
