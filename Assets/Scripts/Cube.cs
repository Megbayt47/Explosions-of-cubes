using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Cube> Exploded;

    public int Chance { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Initialize(int chanceSpawn, Vector3 scale, Color color)
    {
        Chance = chanceSpawn;
        transform.localScale = scale;
        _renderer.material.color = color;
    }

    public void TryExploded()
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