using UnityEngine;
using UnityEngine.UI;

namespace SaveSystemTutorial
{    
    public class RawImageScroller : MonoBehaviour
    {
        [SerializeField] Vector2 minScrollVector = new Vector2(-0.1f, -0.1f);
        [SerializeField] Vector2 maxScrollVector = new Vector2(0.1f, 0.1f);

        Vector2 scrollDirection;

        RawImage image;

        void Awake()
        {
            image = GetComponent<RawImage>();

            scrollDirection = new Vector2(Random.Range(minScrollVector.x, maxScrollVector.x), Random.Range(minScrollVector.y, maxScrollVector.y));
        }

        void Update()
        {
            image.uvRect = new Rect(image.uvRect.position + scrollDirection * Time.deltaTime, image.uvRect.size);
        }
    }
}