using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject child;
    public GameObject[] prefabs;

    private void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        if (child != null) Destroy(child);

        int idx = Random.Range(0, prefabs.Length);
        child = Instantiate(prefabs[idx]);
    }
}