using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    //paramètres par défaut
    [SerializeField] public Camera cam;   
    [SerializeField] public float zoomDistance = 10;
    [SerializeField] public float zoomSpeed = 2f;
    [SerializeField] public float minZoom = 1f;
    [SerializeField] public float maxZoom = 20f;

    private Vector3 lastMousePosition;

    private void Update()
{
    // Détection du clic gauche pour initialiser la rotation
    if (Input.GetMouseButtonDown(0))
    {
        lastMousePosition = cam.ScreenToViewportPoint(Input.mousePosition);
    }
    else if (Input.GetMouseButton(0))
    {
        Vector3 currentMousePosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 movementDelta = lastMousePosition - currentMousePosition;

        float rotationX = movementDelta.y * 180;  // Rotation verticale
        float rotationY = -movementDelta.x * 180; // Rotation horizontale

        cam.transform.position = PlanetManager.current.Cursor.position;

        cam.transform.Rotate(new Vector3(1, 0, 0), rotationX);
        cam.transform.Rotate(new Vector3(0, 1, 0), rotationY, Space.World);

        cam.transform.Translate(new Vector3(0, 0, -zoomDistance));

        lastMousePosition = currentMousePosition;
    }

    // Gestion du zoom avec la molette de la souris
    float zoomInput = Input.GetAxis("Mouse ScrollWheel");
    zoomDistance -= zoomInput * zoomSpeed; // Ajustement du niveau de zoom
    zoomDistance = Mathf.Clamp(zoomDistance, minZoom, maxZoom); // Contrôle des limites du zoom

    // Mise à jour de la position de la caméra en fonction du zoom
    cam.transform.position = PlanetManager.current.Cursor.position - cam.transform.forward * zoomDistance;
}

}