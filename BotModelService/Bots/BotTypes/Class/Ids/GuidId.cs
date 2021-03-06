﻿using System;

namespace BotModel.Bots.BotTypes.Class.Ids
{
	public abstract class GuidId : ClassId<Guid>
	{
		public override Guid GetId => Get;

		protected GuidId(Guid value) : base(value)
		{
		}

		// ToDo:
		// public override Equils GetHashCode() => GetId.GetHashCode();
	}
}