using rpi_ws281x;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
	class RainbowColorAnimation : BaseAnimation
	{
		private static int colorOffset = 0;

		public override void Execute(AbortRequest request)
		{
			using (var controller = GetController())
			{
				var colors = GetAnimationColors();
				while (!request.IsAbortRequested)
				{
				
					for (int i = 0; i <= controller.Settings.Channels[0].LEDCount - 1; i++)
					{
						var colorIndex = (i + colorOffset) % colors.Count;
						controller.SetLEDColor(0, i, colors[colorIndex]);
					}

					controller.Render();

					if (colorOffset == int.MaxValue)
					{
						colorOffset = 0;
					}
					colorOffset++;
					System.Threading.Thread.Sleep(50);
				}

				Wipe(controller, Color.Empty);
			}
		}

		private static List<Color> GetAnimationColors()
		{
			var result = new List<Color>();

			result.Add(Color.FromArgb(0x201000));
			result.Add(Color.FromArgb(0x202000));
			result.Add(Color.Green);
			result.Add(Color.FromArgb(0x002020));
			result.Add(Color.Blue);
			result.Add(Color.FromArgb(0x100010));
			result.Add(Color.FromArgb(0x200010));

			return result;
		}
	}
}
