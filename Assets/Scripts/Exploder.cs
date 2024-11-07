using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

    private float _explosionRadius;
    private int _divider = 2;

    public void BlowUp(List<Cube> cubes, Cube cube)
    {
        foreach (var newCube in cubes)
        {
            float newCubeWidth = cube.transform.localScale.x;

            _explosionRadius = newCubeWidth / _divider;

            newCube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }
}