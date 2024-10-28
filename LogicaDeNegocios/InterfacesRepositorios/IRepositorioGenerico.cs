using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.InterfacesRepositorios
{
    public interface IRepositorioGenerico<T>
    {
        T Alta(T entity);
        T Modificar(T entity);
        T Get(int id);
        void Eliminar(T entity);
    }
}
