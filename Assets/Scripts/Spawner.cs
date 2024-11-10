using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new();
    [SerializeField] private Exploder _exploder;

    private readonly int _multiply = 2;
    private readonly int _divider = 2;

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Destruction += OnCubeDestructed;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Destruction -= OnCubeDestructed;
        }
    }

    private void CreateCubes(Cube cube)
    {
        int minRandomNumber = 2;
        int maxRandomNumber = 6;
        int number = Random.Range(minRandomNumber, maxRandomNumber + 1);

        for (int i = 0; i < number; i++)
        {
            Quaternion rotation = Random.rotation;
            Cube newCube = Instantiate(cube, cube.transform.position, rotation);

            newCube.Destruction += OnCubeDestructed;
            newCube.Exploded += OnCubeExplode;

            int chanceSpawn = cube.Chance / _divider;
            Vector3 scale = cube.transform.localScale / _divider;
            Color color = Random.ColorHSV();
            float blastRadius = cube.BlastRadius * _multiply;
            float explosionForce = cube.ExplosionForce * _multiply;

            newCube.Initialize(chanceSpawn, scale, color, blastRadius, explosionForce);
        }
    }

    private void OnCubeDestructed(Cube cube)
    {
        CreateCubes(cube);
        cube.Destruction -= OnCubeDestructed;
    }

    private void OnCubeExplode(Cube cube)
    {
        _exploder.ExplodedCube(cube);
        cube.Exploded -= OnCubeExplode;
    }
}