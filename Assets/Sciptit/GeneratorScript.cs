using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Public variables to set in the Inspector
    public GameObject objectPrefab; // Prefab to spawn
    public float spawnInterval = 3f; // Time between spawns
    public float objectSpeed = 10f; // Speed of spawned objects

    private void Start()
    {   
        // Start spawning objects at intervals
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Instantiate the object at the generator's position and rotation
        GameObject newObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        newObject.AddComponent<MovingObject>().speed = objectSpeed;
    }
}

public class MovingObject : MonoBehaviour
{
    [HideInInspector]
    public float speed; // Speed of the object

    private void Update()
    {
        // Move the object forward (negative z direction)
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy the object when it reaches z <= 0
        if (transform.position.z <= -7)
        {
            Destroy(gameObject);
        }
    }
}
