 using UnityEngine;
 
 public class ParticleSystemAutoDestroy : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 1.5f);
    }
}