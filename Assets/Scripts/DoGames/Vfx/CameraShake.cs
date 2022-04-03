using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoGames.Vfx
{

    [RequireComponent(typeof(Camera))]
    public class CameraShake : MonoBehaviour
    {

        protected enum ShakeMode{
            TWO_DIMENSIONS,
            THREE_DIMENSIONS
        }

        [SerializeField] protected ShakeMode mode = ShakeMode.TWO_DIMENSIONS;
        private Vector3 originalLocalPosition;

        protected void Start()
        {
            originalLocalPosition = this.transform.localPosition;
        }
        public void Shake(float duration, float magnitude)
        {
            transform.position = originalLocalPosition;
            StopAllCoroutines();
            StartCoroutine(ShakeCoroutine(duration, magnitude));
        }

        protected IEnumerator ShakeCoroutine(float duration, float magnitude)
        {
            float timeElapsed = 0f;
            while (timeElapsed < duration)
            {
                Vector3 offset;
                switch (mode){
                    case (ShakeMode.TWO_DIMENSIONS):
                        offset = Random.insideUnitCircle * magnitude;
                        break;
                    default:
                        offset = Random.insideUnitSphere * magnitude;
                        break;
                }
                transform.position = originalLocalPosition + offset;
                yield return new WaitForEndOfFrame();
                timeElapsed += Time.deltaTime;
            }
            transform.position = originalLocalPosition;
            yield return new WaitForEndOfFrame();
        }
    }
}