using UnityEngine;

namespace CodeBase.Infrastructure.Services.Inputs
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}