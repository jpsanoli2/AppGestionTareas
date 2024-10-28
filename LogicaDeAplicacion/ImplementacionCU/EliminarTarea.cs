using LogicaDeAplicacion.InterfacesCU.Tareas;
using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.Exceptions;
using LogicaDeNegocios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class EliminarTarea : IEliminarTarea
    {
        private IRepositorioTarea _repositorioTarea;
        public EliminarTarea(IRepositorioTarea repositorioTarea)
        {
            _repositorioTarea = repositorioTarea;
        }

        public void Ejecutar(int id)
        {
            Tarea tarea = _repositorioTarea.Get(id);
            if (tarea == null) 
            {
                throw new NotFoundException("Tarea no encontrada");
            }
            _repositorioTarea.Eliminar(tarea);
        }
    }
}
