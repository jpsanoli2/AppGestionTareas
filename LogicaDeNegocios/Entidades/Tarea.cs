using LogicaDeNegocios.Exceptions;
using LogicaDeNegocios.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.Entidades
{
    public class Tarea : IValidable, IIdentity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EnumEstado Estado { get; set; } = EnumEstado.Pendiente;
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaRealizar {  get; set; }

        public Tarea() { }
        public Tarea(string nombre, string descripcion, DateTime fechaRealizar)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaRealizar = fechaRealizar;
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Descripcion) || FechaRealizar < DateTime.Now) throw new ElementoInvalidoException("La tarea no es válida");
        }
        public void Copiar(Tarea t)
        {
            Nombre = t.Nombre;
            Descripcion = t.Descripcion;
            Estado = t.Estado;
            FechaInicio = t.FechaInicio;
            FechaRealizar = t.FechaRealizar;
        }
        public void Completar()
        {
            Estado = EnumEstado.Completa;
        }
    }
}
