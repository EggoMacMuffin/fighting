using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
  public float distance;
  public float angle;
  public LayerMask objectsLayers;
  public LayerMask obstaclesLayers;
  public string characterName;
  public Collider detectedObject;

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, distance);
    Gizmos.color = Color.green;
    Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
    Gizmos.DrawRay(transform.position, rightDirection * distance);
    Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
    Gizmos.DrawRay(transform.position, leftDirection * distance);
  }
  void Update()
  {
    Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);

    for (int i = 0; i < colliders.Length; ++i)
    {
      Collider collider = colliders[i];
      Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
      float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
      if (angleToCollider < angle)
      {
        if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers))
        {
          Debug.DrawLine(transform.position, collider.bounds.center, Color.blue);
          if (collider.gameObject.CompareTag("Player"))
          {
            Debug.Log(characterName + " detects a player!");
            detectedObject = collider;
          }
        }
        else
        {
          Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
      }
    }
  }
}
