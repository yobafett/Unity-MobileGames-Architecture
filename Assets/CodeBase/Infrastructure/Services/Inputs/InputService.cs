using UnityEngine;

namespace CodeBase.Infrastructure.Services.Inputs
{
    public abstract class InputService : IInputService
    {
        protected const string HORIZONTAL = "Horizontal";
        protected const string VERTICAL = "Vertical";
        private const string BUTTON = "Fire";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp() =>
            SimpleInput.GetButtonUp(BUTTON);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(HORIZONTAL), SimpleInput.GetAxis(VERTICAL));
    }
}

