using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
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
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, cube.BlastRadius);

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