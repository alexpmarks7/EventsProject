using System;
using System.Collections.Generic;
using System.Text;

namespace EventsProject
{
	public partial class Event
	{
		public override string ToString()
		{
			return $"{EventTypeName}";
		}
	}
}
