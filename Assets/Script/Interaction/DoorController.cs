using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private Door door;
    [SerializeField] private Material openMat;
    [SerializeField] private Material closeMat;
    [SerializeField] private GameObject openLight;
    [SerializeField] private GameObject closeLight;

    private MeshRenderer btnMesh;

    private void Awake()
    {
        btnMesh = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        ButtonMat();
        LightButton();
    }

    public void Interact(Player player)
    {
        door.DoorToggle();
        ButtonMat();
        LightButton();
    }

    private void ButtonMat()
    {
        if (door.DoorCheck())
            btnMesh.material = openMat;
        else
            btnMesh.material = closeMat;
    }
    private void LightButton()
    {
        if (openLight != null) openLight.SetActive(door.DoorCheck());
        if (closeLight != null) closeLight.SetActive(!door.DoorCheck());
    }
}
