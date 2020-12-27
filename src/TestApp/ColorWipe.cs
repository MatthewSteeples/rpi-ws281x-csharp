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

				Wipe(controller, Color.Empty);
			}
		}
	}
}
