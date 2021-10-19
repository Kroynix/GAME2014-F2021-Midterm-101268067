/*
GAME2014-F2021
Mid Term Script
Nathan Nguyen
101268067

Description:
Bullet Manager keeps track of all bullets to make sure the bullets dont exceed the maximum set by the user
(in this case 50 bullets) Bullets are set to a queue which are then set to active when being shot and when 
disabled are set to inactive but will never create more in the queue / Fully delete them until the program
is turned off

Change Log:
Nothing needed to be changed

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
