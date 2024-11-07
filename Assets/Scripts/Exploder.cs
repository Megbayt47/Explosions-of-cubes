using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

    private float _explosionRadius;

    public void BlowUp(List<Cube> cubes, Cube cube)
    {
        foreach (var newCube in cubes)
        {
            _explosionRadius = newCube.transform.localScale.x;

            newCube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }
}