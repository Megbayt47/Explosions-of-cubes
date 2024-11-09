using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public event Action<Cube> Exploded;
    public event Action<Cube> ExplodedCube;

    public int Chance { get; private set; } = 100;
    public float BlastRadius { get; private set; } = 20;
    public float ExplosionForce { get; private set; } = 2000;
    public Rigidbody Rigidbody { get; private set; }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(int chanceSpawn, Vector3 scale, Color color, float radius, float force)
    {
        Chance = chanceSpawn;
        transform.localScale = scale;
        _renderer.material.color = color;
        BlastRadius = radius;
        ExplosionForce = force;
    }

    public void TryExplode()
    {
        int minValue = 0;
        int maxValue = 100;

        if (UnityEngine.Random.Range(minValue, maxValue + 1) <= Chance)
        {
            Exploded?.Invoke(this);
            Destroy(gameObject);
        }
        else
        {
            ExplodedCube?.Invoke(this);
            Destroy(gameObject);
        }
    }
}