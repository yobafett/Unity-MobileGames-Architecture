using UnityEngine;

namespace CodeBase.Services.Inputs
{
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}