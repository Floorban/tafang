using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public ItemSlot itemSlot;
    public CollisionDetect collisionDetect;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public float spawnTime = 0.5f;
    private float timeSinceSpawned = 0f;

    public float rotationSpeed = -90f;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (itemSlot.isDropped && collisionDetect.isEntered)
        {
            timeSinceSpawned += Time.deltaTime;
            if (timeSinceSpawned >= spawnTime)
            {
                ShootBullet();
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {

            Rotate(-rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {

            Rotate(rotationSpeed * Time.deltaTime);
        }
    }

    void Rotate(float angle)
    {

        transform.Rotate(Vector3.forward, angle);
    }

    public void ShootBullet()
    {
        Quaternion rotation = transform.rotation;
        Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);
        timeSinceSpawned = 0;
    }


    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");

      //  if (itemSlot.isDropped) return;

        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

     
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
       // if (itemSlot.isDropped) return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");

     //   if (itemSlot.isDropped) return;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

}
