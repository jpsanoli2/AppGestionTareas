using LogicaDeNegocios.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.InterfacesRepositorios
{
    public interface IRepositorioTarea : IRepositorioGenerico<Tarea>
    {
        IEnumerable<Tarea> GetAllTareas();
    }
}
