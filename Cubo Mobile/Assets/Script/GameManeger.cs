using System.Collections;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePreFab;
    public float spawnInterval = 2f;
    public bool isGameOver = false;
    public float spawnY = 11f;
    public float spawnX = 7f;



    private IEnumerator SpawnObstacle()
    {
        while(!isGameOver)
        {
            var xPosition = Random.Range(-spawnX, spawnX);

            Instantiate(obstaclePreFab, new Vector3(xPosition, spawnY, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
