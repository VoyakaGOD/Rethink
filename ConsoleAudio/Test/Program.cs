using System;
using ConsoleAudio;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			SoundPlayer.Play(Sound.Load("testSound"));
			Console.WriteLine("first");
			while (SoundPlayer.IsEmpty == false) ;
			Console.WriteLine("second");
			SoundPlayer.Play(Sound.Load("sound2"));
		}
	}
}
