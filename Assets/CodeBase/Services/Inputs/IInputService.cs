using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Services.Inputs
{
    public interface IInputService : IService
    {
        Vector2 Axis { get; }

        bool IsAttackButtonUp();
    }
}