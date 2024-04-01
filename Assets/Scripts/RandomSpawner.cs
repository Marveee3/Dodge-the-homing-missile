using UnityEngine;

public class RandomSpawner : MonoBehaviour
{   
    [SerializeField]private GameObject objectToSpawn;
    [SerializeField]private float minX = -5f;
    [SerializeField]private float maxX = 5f;
    [SerializeField]private float minY = -5f;
    [SerializeField]private float maxY = 5f;

    private void Start()
    {
        // Вызываем метод SpawnObject каждые 10 секунд, начиная сразу после старта
        InvokeRepeating("SpawnObject", 0f, 0.7f);
    }


    private void OnDrawGizmosSelected()
    {
        // Отображение границ прямоугольника с помощью гизмо
        Gizmos.color = Color.green;
        Vector3 size = new Vector3(maxX - minX,  maxY - minY, 0.1f);
        Vector3 center = new Vector3((minX + maxX) / 2f,  (minY + maxY) / 2f, transform.position.z);
        Gizmos.DrawWireCube(center, size);
    }

    public void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            // Генерируем случайные координаты в пределах границ квадрата/прямоугольника
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);

            // Создаем новый объект в случайной позиции
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Object to spawn is not set!");
        }
    }

}
