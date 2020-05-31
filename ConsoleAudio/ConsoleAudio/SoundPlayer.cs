using System;
using System.Threading;
using System.Collections.Generic;

namespace ConsoleAudio
{
	public static class SoundPlayer
	{
		private static Thread thread;

		private static List<Note> notes;

		private static List<byte> _volume;

		public static bool IsEmpty => notes == null;

		public static void Play(Sound sound, byte volume = 0)
		{
			if (IsEmpty)
			{
				notes = new List<Note>();
				_volume = new List<byte>();
				thread = null;
			}

			for (int i = notes.Count; i <= sound.Notes.Count; i++)
			{
				notes.Add(new Note(0));
				_volume.Add(0);
			}

			for (int i = 0; i < sound.Notes.Count; i++)
			{
				if (sound.Notes[i].IsRest) continue;

				if ((volume >= _volume[i + 1]) || notes[i + 1].IsRest)
				{
					notes[i + 1] = sound.Notes[i];
					_volume[i + 1] = volume;
				}
			}

			if (thread == null)
			{
				thread = new Thread(new ThreadStart(PlaySound));
				thread.Start();
			}
		}

		public static void Stop()
		{
			notes = null;
			_volume = null;
			thread.Abort();
		}

		private static void PlaySound()
		{
			while (notes.Count > 0) {
				if(notes[0].IsRest)
					Thread.Sleep(notes[0].Duration);
				else
					Console.Beep(notes[0].Tone, notes[0].Duration);
				notes.RemoveAt(0);
			}
			Stop();
		}
	}
}
