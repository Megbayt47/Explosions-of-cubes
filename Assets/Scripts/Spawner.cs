using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new();
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Exploded += OnCubeExploded;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Exploded -= OnCubeExploded;
        }
    }

    private void CreateCubes(Cube cube)
    {
        int divider = 2;
        int minRandomNumber = 2;
        int maxRandomNumber = 6;
        int number = Random.Range(minRandomNumber, maxRandomNumber + 1);

        List<Cube> cubes = new();

        for (int i = 0; i < number; i++)
        {
            Quaternion rotation = Random.rotation;
            Cube newCube = Instantiate(cube, cube.transform.position, rotation);

            newCube.Exploded += OnCubeExploded;

            int chanceSpawn = cube.Chance / divider;
            Vector3 scale = cube.transform.localScale / divider;
            Color color = Random.ColorHSV();

            newCube.Initialize(chanceSpawn, scale, color);

            cubes.Add(newCube);
        }

        _exploder.BlowUp(cubes, cube);
    }

    private void OnCubeExploded(Cube cube)
    {
        CreateCubes(cube);
        cube.Exploded -= OnCubeExploded;
    }
}