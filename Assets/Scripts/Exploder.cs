using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10000;
    [SerializeField] private float _explosionRadius = 50;

    public void BlowUpCubes(List<Cube> cubes, Cube cube)
    {
        foreach (var newCube in cubes)
        {
            newCube.Rigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }

    public void ExplodedCube(Cube cube)
    {
        List<Rigidbody> cubes = GetExplodableObjects(cube);

        foreach (Rigidbody explodableObjects in cubes)
        {
            explodableObjects.AddExplosionForce(cube.ExplosionForce, cube.transform.position, cube.BlastRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}