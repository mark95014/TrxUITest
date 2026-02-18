namespace TrxUITest.src.tests.utils
{
    public class Note
    {
        public enum NoteType { client, account, review }

        string id;
        string[] notes;
        NoteType noteType;

        public Note(string id, NoteType noteType, string[] notes)
        {
            this.id = id;
            this.noteType = noteType;
            this.notes = notes;
        }
    }
}