using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public GameObject playerOB;
    public LayerMask mask;
    public float maxDistance;
    public float sphereRadius;
    private Ray ray;
    public HealthBar healthBar;

    private float currentHitDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if(Physics.SphereCast(ray, sphereRadius, out hitInfo, maxDistance,mask,QueryTriggerInteraction.UseGlobal))
        {
            playerOB = hitInfo.transform.gameObject;
            currentHitDistance = hitInfo.distance;
            int currHealth = playerOB.GetComponent<HealthSystem>().currentHealth;
            currHealth = Mathf.Max(0, currHealth - 5);
            playerOB.GetComponent<HealthSystem>().currentHealth = currHealth;
            healthBar.SetHealth(currHealth);
            if(currHealth == 0)
            {
                playerOB.GetComponent<HealthSystem>().onDeath();
            }
            /*Debug.DrawLine(ray.origin, hitInfo.point, Color.red)*/;
        } else
        {
            currentHitDistance = maxDistance;
            playerOB = null;
            //Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * currentHitDistance);

        Gizmos.DrawWireSphere(ray.origin + ray.direction * currentHitDistance, sphereRadius);
    }
}
