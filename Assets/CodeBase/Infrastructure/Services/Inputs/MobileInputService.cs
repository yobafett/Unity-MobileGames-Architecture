using UnityEngine;

namespace CodeBase.Infrastructure.Services.Inputs
{
	public class MobileInputService : InputService
	{
		public override Vector2 Axis =>
			SimpleInputAxis();
	}
}