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
    public class ModificarTarea : IModificarTarea
    {
        private IRepositorioTarea _repositorioTarea;
        public ModificarTarea(IRepositorioTarea repositorioTarea)
        {
            _repositorioTarea = repositorioTarea;
        }

        public TareaDto Ejecutar(int id, TareaDto tDto)
        {
            Tarea tarea = tDto.ToTarea();
            tarea.Validar();
            Tarea tareaToUpdate = _repositorioTarea.Get(id);
            if (tareaToUpdate == null) 
            {
                throw new NotFoundException("Tarea no encontrada");
            }
            tareaToUpdate.Copiar(tarea);
            Tarea tareaModificada = _repositorioTarea.Modificar(tareaToUpdate);
            TareaDto tareaModificadaDto = new TareaDto(tareaModificada);
            return tareaModificadaDto;
        }
    }
}
