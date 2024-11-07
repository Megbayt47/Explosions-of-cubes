using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Cube> Exploded;

    public int Chance { get; private set; } = 100;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(int chanceSpawn, Vector3 scale, Color color)
    {
        Chance = chanceSpawn;
        transform.localScale = scale;
        _renderer.material.color = color;
    }

    public void TryExplode()
    {
        int minValue = 0;
        int maxValue = 100;

        if (UnityEngine.Random.Range(minValue, maxValue + 1) <= Chance)
        {
            Exploded?.Invoke(this);
        }

        Destroy(gameObject);
    }
}