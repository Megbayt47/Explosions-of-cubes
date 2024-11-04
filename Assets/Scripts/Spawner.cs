using UnityEngine;

public class Spawner : MonoBehaviour
{
    private void CreateCubes(Cube cube)
    {
        int divider = 2;
        int minRandomNumber = 2;
        int maxRandomNumber = 6;
        int number = Random.Range(minRandomNumber, maxRandomNumber + 1);

        for (int i = 0; i < number; i++)
        {
            Quaternion rotation = Random.rotation;
            Cube newCube = Instantiate(cube, cube.transform.position, rotation);

            int chanceSpawn = cube.Chance / divider;
            Vector3 scale = cube.transform.localScale / divider;
            Color color = Random.ColorHSV();

            newCube.Construct(chanceSpawn, scale, color);
        }
    }

    public bool TrySpawn(Cube cube)
    {
        int minValue = 0;
        int maxValue = 100;

        if (Random.Range(minValue, maxValue + 1) <= cube.Chance)
        {
            CreateCubes(cube);

            return true;
        }

        return false;
    }
}