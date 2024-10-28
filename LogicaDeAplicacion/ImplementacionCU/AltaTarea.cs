using Dto;
using LogicaDeAplicacion.InterfacesCU.Tareas;
using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.ImplementacionCU
{
    public class AltaTarea : IAltaTarea
    {
        private IRepositorioTarea _repositorioTarea;
        public AltaTarea(IRepositorioTarea repositorioTarea)
        {
            _repositorioTarea = repositorioTarea;
        }
        public TareaDto Ejecutar(TareaDto tDto)
        {
            Tarea tarea = tDto.ToTarea();
            tarea.Validar();
            Tarea tareaGuardadaEnBD = _repositorioTarea.Alta(tarea);
            TareaDto nuevaTareaDto = new TareaDto(tareaGuardadaEnBD);
            return nuevaTareaDto;
        }
    }
}
