using System.Collections.Generic;
using System.IO;
using System;

namespace ConsoleAudio
{
	public class Sound
	{
		private List<Note> notes;
		public List<Note> Notes { get => notes; set => notes = (value == null) ? notes : value; }

		public Sound()
		{
			notes = new List<Note>();
		}

		public void AddNote(Note newNote) => notes.Add(newNote);

		public void AddNote(ushort tone, ushort duration) => notes.Add(new Note(tone, duration));

		public void AddNote(ushort duration) => notes.Add(new Note(duration));

		public void Save(string path)
		{
			using (var bw = new BinaryWriter(File.Open(path, FileMode.Create)))
			{
				bw.Write(Notes.Count);
				for (int i = 0; i < Notes.Count; i++)
				{
					bw.Write(Notes[i].Tone);
					bw.Write(Notes[i].Duration);
				}
			}
		}

		public static Sound Load(string path)
		{
			if (File.Exists(path) == false) throw new ArgumentException("file not found");

			Sound result = new Sound();
			using (var br = new BinaryReader(File.Open(path, FileMode.Open)))
			{
				int noteCount = br.ReadInt32();
				for (int i = 0; i < noteCount; i++)
					result.AddNote(br.ReadUInt16(), br.ReadUInt16());
			}
			return result;
		}
	}
}
