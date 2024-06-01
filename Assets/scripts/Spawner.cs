using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _enemy;

    private int _delay = 2;

    private void Start()
    { 
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int minIndex = 0;
        int maxIndex = _spawnPoints.Count;
        int minRotation = 0;
        int maxRotation = 360;
        int rotationX = 0;
        int rotationZ = 0;

        while (true)
        {
            int index = Random.Range(minIndex, maxIndex);
            int rotationY = Random.Range(minRotation, maxRotation);
            Vector3 rotation = new Vector3(rotationX, rotationY, rotationZ);

            yield return new WaitForSeconds(_delay);
            Instantiate(_enemy, _spawnPoints[index].position, Quaternion.Euler(rotation));
        }
    }
}
