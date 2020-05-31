using System;

namespace ConsoleAudio
{
	public struct Note
	{
		public ushort Tone;
		public ushort Duration;
		
		public bool IsRest => (Tone < 37) || (Tone > 32767);

		public Note(ushort duration)
		{
			Tone = 0;
			Duration = duration;
		}

		public Note(ushort tone, ushort duration)
		{
			Tone = tone;
			Duration = duration;
		}
	}
}
