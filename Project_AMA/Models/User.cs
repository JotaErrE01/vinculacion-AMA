using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Project_AMA.Models;

public class User {
	[Key] 
	[SwaggerSchema(ReadOnly = true)]
	public int Id { get; set; }

	[Required] public string dni { get; set; }

	public string email { get; set; }

	[Required] public byte[] PasswordHash { get; set; }

	[Required] public byte[] PasswordSalt { get; set; }

	[MaxLength(50)] public string? name { get; set; }

	[SwaggerSchema(ReadOnly = true)]
	public DateTime created_at { get; set; }

	[SwaggerSchema(ReadOnly = true)]
	public DateTime updated_at { get; set; }
}