using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Cube> _cubes = new();
    [SerializeField] private Exploder _exploder;
    [SerializeField] private AudioSource _explosiveFartSound;
    [SerializeField] private AudioSource[] _winSounds;

    private readonly int _multiply = 2;
    private readonly int _divider = 2;
    private AudioSource _randomSoundWin;

    private void OnEnable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Destructed += OnCubeDestructe;
        }
    }

    private void OnDisable()
    {
        foreach (Cube cube in _cubes)
        {
            cube.Destructed -= OnCubeDestructe;
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

            newCube.Destructed += OnCubeDestructe;
            newCube.Exploded += OnCubeExplode;

            int chanceSpawn = cube.Chance / _divider;
            Vector3 scale = cube.transform.localScale / _divider;
            Color color = Random.ColorHSV();
            float blastRadius = cube.BlastRadius * _multiply;
            float explosionForce = cube.ExplosionForce * _multiply;

            newCube.Initialize(chanceSpawn, scale, color, blastRadius, explosionForce);
        }
    }

    private void OnCubeDestructe(Cube cube)
    {
        _randomSoundWin = RandomSound();
        _randomSoundWin.Play();

        CreateCubes(cube);
        cube.Destructed -= OnCubeDestructe;
        cube.Exploded -= OnCubeExplode;
    }

    private void OnCubeExplode(Cube cube)
    {
        _explosiveFartSound.Play();
        _exploder.ExplodedCube(cube);
        cube.Exploded -= OnCubeExplode;
    }

    private AudioSource RandomSound()
    {
        return _winSounds[Random.Range(0, _winSounds.Length)];
    }
}