using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App4._2.ViewModels
{
    public class ProductoViewModel : BindableObject
    {
        int idproducto; public int IdProducto { get { return idproducto; } set { idproducto = value; OnPropertyChanged("IdProducto"); } }
        string descripcion; public string Descripcion { get { return descripcion; } set { descripcion = value; OnPropertyChanged("Descripcion"); } }
        int idMarca; public int IdMarca { get { return idMarca; } set { idMarca = value; OnPropertyChanged("IdMarca"); } }
        string marca; public string Marca { get { return marca; } set { marca = value; OnPropertyChanged("Marca"); } }
        bool activo; public bool Activo { get { return activo; } set { activo = value; OnPropertyChanged("Activo"); } }

        byte[] imagen; public byte[] Imagen { get { return imagen; } set { imagen = value; OnPropertyChanged("Imagen"); } }
    }
}
