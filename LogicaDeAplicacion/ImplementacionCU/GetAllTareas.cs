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
    public class GetAllTareas : IGetAllTareas
    {
        private IRepositorioTarea _repositorioTarea;
        public GetAllTareas(IRepositorioTarea repositorioTarea)
        {
            _repositorioTarea = repositorioTarea;
        }

        public IEnumerable<TareaDto> Ejecutar()
        {
            List<TareaDto> tareasDto = new List<TareaDto>();
            IEnumerable<Tarea> tareas = _repositorioTarea.GetAllTareas();
            foreach(Tarea t in tareas)
            {
                tareasDto.Add(new TareaDto(t));
            }
            return tareasDto;
        }
    }
}
