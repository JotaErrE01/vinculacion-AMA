using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_AMA.DB;
using Project_AMA.Models;

namespace Project_AMA.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class BrigadaController : ControllerBase {
		private readonly ApplicationDbContext _context;

		public BrigadaController(ApplicationDbContext context) {
			_context = context;
		}

		// GET: api/Brigada
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Brigada>>> GetBrigada() {
			return await _context.Brigadas.ToListAsync();
		}

		// GET: api/Brigada/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Brigada>> GetBrigada(int id) {
			var brigada = await _context.Brigadas.FindAsync(id);

			if (brigada == null) {
				return NotFound();
			}

			return brigada;
		}

		// PUT: api/Brigada/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBrigada(int id, Brigada brigada) {
			var brigadaDB = await _context.Brigadas.FindAsync(id);

			if (brigadaDB == null) return NotFound();
			
			brigadaDB.Id = id;
			brigadaDB.Nombre_Brigada = brigada.Nombre_Brigada;
			brigadaDB.Descripcion_Brigada = brigada.Descripcion_Brigada;
			brigadaDB.Nombre_Responsable = brigada.Nombre_Responsable;
			brigadaDB.Num_Responsable = brigada.Num_Responsable;
			brigadaDB.Direccion = brigada.Direccion;
			brigadaDB.Inicio_Brigada = brigada.Inicio_Brigada;
			brigadaDB.Fin_Brigada = brigada.Fin_Brigada;
			brigadaDB.created_at = brigadaDB.created_at;
			brigadaDB.updated_at = DateTime.Now;
			
			_context.Entry(brigadaDB).State = EntityState.Modified;

			try {
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) {
				if (!BrigadaExists(id)) {
					return NotFound();
				}
				else {
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Brigada
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Brigada>> PostBrigada(Brigada brigada) {
			var created_at = DateTime.Now;
			var updated_at = DateTime.Now;

			var newBrigada = new Brigada() {
				Nombre_Brigada = brigada.Nombre_Brigada,
				Descripcion_Brigada = brigada.Descripcion_Brigada,
				Nombre_Responsable = brigada.Nombre_Responsable,
				Num_Responsable = brigada.Num_Responsable,
				Direccion = brigada.Direccion,
				Inicio_Brigada = brigada.Inicio_Brigada,
				Fin_Brigada = brigada.Fin_Brigada,
				created_at = created_at,
				updated_at = updated_at
			};
			
			_context.Brigadas.Add(newBrigada);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetBrigada", new { id = brigada.Id }, brigada);
		}

		// DELETE: api/Brigada/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBrigada(int id) {
			var brigada = await _context.Brigadas.FindAsync(id);
			if (brigada == null) return NotFound();

			_context.Brigadas.Remove(brigada);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool BrigadaExists(int id) {
			return _context.Brigadas.Any(e => e.Id == id);
		}
	}
}