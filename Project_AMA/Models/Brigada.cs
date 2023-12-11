using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Project_AMA.Models;

public class Brigada {
	[Key] 
	[SwaggerSchema(ReadOnly = true)]
	public int Id { get; set; }

	[Required] public string Nombre_Brigada { get; set; }

	public string Descripcion_Brigada { get; set; }

	public string Nombre_Responsable { get; set; }

	public int Num_Responsable { get; set; }

	public string Direccion { get; set; }

	public DateTime Inicio_Brigada { get; set; }

	public DateTime? Fin_Brigada { get; set; }

	[SwaggerSchema(ReadOnly = true)]
	public DateTime created_at { get; set; }

	[SwaggerSchema(ReadOnly = true)]
	public DateTime updated_at { get; set; }
}