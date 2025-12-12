using Microsoft.AspNetCore.Mvc;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<Note> Notes = new List<Note>();
        private static int nextId = 1;

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(Notes);
        }

        [HttpPost]
        public IActionResult AddNote([FromBody] Note note)
        {
            note.Id = nextId++;
            Notes.Add(note);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNote(int id, [FromBody] Note updatedNote)
        {
            var note = Notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            note.Title = updatedNote.Title;
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            var note = Notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            Notes.Remove(note);
            return Ok();
        }
    }
}
