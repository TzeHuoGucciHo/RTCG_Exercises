using UnityEngine;

public class CameraControl : MonoBehaviour
{
    CreateGrid createGrid;

    public float distance = 10.0f;
    public float orbitSpeed = 2.0f;

    float angle = 0.0f;
    Vector3 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        createGrid = GetComponent<CreateGrid>();
        offset = new Vector3(distance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cubeCenter = createGrid.grid[0].localPosition + new Vector3(createGrid.gridResolution / 2, createGrid.gridResolution / 2, createGrid.gridResolution / 2);
        Camera.main.transform.LookAt(cubeCenter);

        angle += orbitSpeed * Time.deltaTime;
        Vector3 newPosition = Quaternion.Euler(0, angle, 0) * offset + cubeCenter;

        Camera.main.transform.position = newPosition;
    }
}
