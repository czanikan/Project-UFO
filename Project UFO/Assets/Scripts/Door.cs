using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    [SerializeField] float speed = 10;

    private void Update()
    {
        if(isOpen)
        {
            Open();
        }   
        else
        {
            Close();
        }
    }

    public void UpdateState()
    {
        isOpen = !isOpen;
    }

    void Open()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, -5f, transform.position.z), speed * Time.deltaTime);
    }

    void Close()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(transform.position.x, 0, transform.position.z), speed * Time.deltaTime);
    }
}
