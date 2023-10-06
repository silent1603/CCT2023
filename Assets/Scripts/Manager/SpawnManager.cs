using Utils.DesignPattern;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float xOffset;

    [SerializeField]
    private float yOffset;

    [SerializeField]
    private int _currentWave;

    [SerializeField]
    private GameObject _enemyAI;

    [SerializeField]
    private int duration;

    [SerializeField]
    private float cameraWidth;
    [SerializeField]
    private float cameraHeight;

    public void Start()
    {
        _camera = Camera.main;

    }

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        float cameraSize = GetComponent<Camera>().orthographicSize;
        float cameraAspect = GetComponent<Camera>().aspect;

        cameraWidth = 2 * cameraSize * cameraAspect;
        cameraHeight = 2 * cameraSize;
        int side = Random.Range(0, 8);
        Vector3 pos = Vector3.zero;
        float x = 0;
        float y = 0;
        switch (side)
        {
            case 0: // Top Right
                x = Random.Range(cameraWidth, cameraWidth * xOffset);
                y = Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 1: // Top Left
                x = -Random.Range(cameraWidth, cameraWidth * xOffset);
                y = Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 2: // Bottom Left
                x = -Random.Range(cameraWidth, cameraWidth * xOffset);
                y = -Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 3: // Bottom Right
                x = Random.Range(cameraWidth, cameraWidth * xOffset);
                y = -Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 4: // TOP
                y = Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 5: // BELOW
                y = -Random.Range(cameraHeight, cameraHeight * yOffset);
                break;
            case 6: // RIGHT
                x = Random.Range(cameraWidth, cameraWidth * xOffset);
                break;
            case 7: // LEFT
                x = -Random.Range(cameraWidth, cameraWidth * xOffset);
                break;
        }
        pos = new Vector3(x, y, 0f);
        Debug.Log("Random on X:" + pos.x + ", Y:" + pos.y);
        Instantiate(_enemyAI,pos, Quaternion.identity);
    }
    
    public void OnCameraChange(Camera camera)
    {
      
    }
   

}
