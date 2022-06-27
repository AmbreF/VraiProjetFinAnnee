using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject projectilePrefab;
        public int size;
        public GameObject characterAim;
    }




    public static ProjectilePooler Instance;
    Queue<GameObject> objectPool = new Queue<GameObject>();
    private void Awake()
    {
        Instance = this;
    }


    public Pool pool;

    // Start is called before the first frame update
    void Start()
    {
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.projectilePrefab);
            CharacterProjectile projectile = obj.GetComponent<CharacterProjectile>();
            projectile.SetCharacterAim(pool.characterAim.transform.up);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        

    }

    public GameObject SpawnFromPool(Vector2 position, Quaternion rotation)
    {

        GameObject objToSpawn = objectPool.Dequeue();

        CharacterProjectile projectile = objToSpawn.GetComponent<CharacterProjectile>();
        projectile.SetCharacterAim(pool.characterAim.transform.up);


        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        

        IPooledProjectile pooledProjectile = objToSpawn.GetComponent<IPooledProjectile>();

        if(pooledProjectile != null)
        {
            pooledProjectile.OnProjectileSpawn();
        }

        objectPool.Enqueue(objToSpawn);

        return objToSpawn;
    }



}
