using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
	class ColorWipe : BaseAnimation
	{
		public override void Execute(AbortRequest request)
		{
			using (var controller = GetController())
			{
				while(!request.IsAbortRequested)
				{
					Wipe(controller, Color.Red);
					Wipe(controller, Color.Green);
					Wipe(controller, Color.Blue);
				}
			}
		}

		private static void Wipe(WS281x controller, Color color)
		{
			for (int i = 0; i <= controller.Settings.Channels[0].LEDs.Count - 1; i++)
			{
				controller.SetLEDColor(0, i, color);
				controller.Render();
				System.Threading.Thread.Sleep(1000 / 15);
			}
		}
	}
}
