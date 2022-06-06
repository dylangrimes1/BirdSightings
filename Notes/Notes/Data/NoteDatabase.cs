using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Bird>().Wait();
        }

        public Task<List<Bird>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Bird>().ToListAsync();
        }

        public Task<Bird> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Bird>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Bird note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Bird note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}