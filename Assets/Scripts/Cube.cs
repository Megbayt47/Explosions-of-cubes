using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private Renderer _renderer;

    public int Chance { get; private set; } = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Construct(int chanceSpawn, Vector3 scale, Color color)
    {
        Chance = chanceSpawn;
        transform.localScale = scale;
        _renderer.material.color = color;
    }
}