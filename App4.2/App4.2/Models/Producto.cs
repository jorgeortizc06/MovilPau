using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace App4_2.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }

        public bool Activo { get; set; }
        public string Marca { get; set; }

        public byte[] Imagen { get; set; }

        public ImageSource ImagenSource
        {
            get
            {
                if (Imagen != null)
                    return ImageSource.FromStream(() => new MemoryStream(Imagen));

                return null;
            }
        }
    
}
}
