using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;

    private float _explosionRadius;

    public void Explode(Cube cube)
    {
        int divider = 2;
        _explosionRadius = cube.transform.localScale.x / divider;

        List<Rigidbody> objects = GetExplodableObject(cube);

        foreach (Rigidbody explodableObject in objects)
        {
            explodableObject.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<Rigidbody> _cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                _cubes.Add(hit.attachedRigidbody);
            }
        }

        return _cubes;
    }
}