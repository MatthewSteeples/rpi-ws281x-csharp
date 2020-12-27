using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
	abstract class BaseAnimation
	{
		public abstract void Execute(AbortRequest request);

		protected WS281x GetController()
		{
			Console.Clear();
			Console.Write("How many LEDs to you want to use: ");

			var ledCount = Int32.Parse(Console.ReadLine());

			Console.Write("What brightness do you want to use (0-255)?");
			var brightness = byte.Parse(Console.ReadLine());

			//The default settings uses a frequency of 800000 Hz and the DMA channel 10.
			var settings = Settings.CreateDefaultSettings();

			//Use Unknown as strip type. Then the type will be set in the native assembly.
			settings.Channels[0] = new Channel(ledCount, 18, brightness, false, StripType.WS2812_STRIP);

			var controller = new WS281x(settings);

			return controller;
		}
	}
}
