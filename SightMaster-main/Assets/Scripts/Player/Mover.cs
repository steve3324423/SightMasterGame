using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 15f;

    private CharacterController _controller;
    private IInput _input;

    public event Action<bool> Moved;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _controller.Move(_input.GetDirection(transform) * _speed * Time.deltaTime);
        Moved?.Invoke(_controller.velocity.magnitude > 0);
    }
}
