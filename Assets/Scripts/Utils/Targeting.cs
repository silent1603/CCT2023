using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Targeting : MonoBehaviour
{

    //public Material normalMat;
    //public Material inRangeMat;

    public GameObject priorityTarget;
    [SerializeField] List<GameObject> targets;
    [SerializeField] float[] distances;
    [SerializeField] float shortestDis = Mathf.Infinity;
    [SerializeField] GameObject gunHolder;
    [SerializeField] float lookSpeed = 3f;

    public LayerMask layerMask;
    

    [SerializeField] float radius = 5f;

    public void Start()
    {
        targets = new List<GameObject>();
        priorityTarget = null;
    }

    public void Update()
    {
        targets.Clear();
        priorityTarget = null;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, layerMask);

        if (hitColliders == null)
        {
            targets.Clear();
            priorityTarget = null;
            return;
        }
        if (hitColliders.Length > 0)
        {
            foreach (Collider2D c in hitColliders)
            {
                //print(gameObject.name);
                targets.Add(c.transform.gameObject);
            }

            float minDist = Vector2.Distance(transform.position, targets[0].transform.position);
            int targetIndex = 0;

            for (int i = 0; i < targets.Count; i++)
            {

                float dist = Vector2.Distance(transform.position, targets[i].transform.position);

                Debug.DrawLine(transform.position, targets[i].transform.position, Color.red);

                if (minDist > dist)
                {
                    minDist = dist;
                    targetIndex = i;
                }               
            }
            priorityTarget = targets[targetIndex];

            //print(priorityTarget.name);

            Debug.DrawLine(transform.position, targets[targetIndex].transform.position, Color.green);
        }

        GunLookat();
    }

    void GunLookat()
    {
        if (priorityTarget == null)
        {
            gunHolder.transform.rotation = Quaternion.identity;
            return;
        }

        Vector3 diff = priorityTarget.transform.position - gunHolder.transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gunHolder.transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
