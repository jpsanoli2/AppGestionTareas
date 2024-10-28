using Dto;
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
    public class GetTarea : IGetTarea
    {
        private IRepositorioTarea _repositorioTarea;
        public GetTarea(IRepositorioTarea repositorioTarea)
        {
            _repositorioTarea = repositorioTarea;
        }

        public TareaDto Ejecutar(int id)
        {
            Tarea tareaObtenida = _repositorioTarea.Get(id);
            if(tareaObtenida == null)
            {
                throw new NotFoundException("Tarea no encontrada"); 
            }
            TareaDto tareaDto = new TareaDto(tareaObtenida);
            return tareaDto;
        }
    }
}
