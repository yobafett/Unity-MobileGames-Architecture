using UnityEngine;

namespace CodeBase.Services.Inputs
{
    public class MobileInputService : InputService
    {
        public override Vector2 Axis => 
            SimpleInputAxis();
    }
}