using LogicaDeNegocios.Entidades;
using System.Reflection.Metadata;

namespace Dto
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EnumEstado Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaRealizar { get; set; }

        public TareaDto() { }
        public TareaDto(Tarea t)
        {
            Id = t.Id;
            Nombre = t.Nombre;
            Descripcion = t.Descripcion;
            Estado = t.Estado;
            FechaInicio = t.FechaInicio;
            FechaRealizar = t.FechaRealizar;
        }
        public  Tarea ToTarea()
        {
            Tarea t = new Tarea
            {
                Id = Id,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Estado = Estado,
                FechaInicio = FechaInicio,
                FechaRealizar = FechaRealizar
            };
            return t;
        }
    }
}
