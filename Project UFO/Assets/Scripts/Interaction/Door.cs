using UnityEngine;

public class Door : Interactable
{
    public bool isOpen = false;
    [SerializeField] float speed = 10;
    [SerializeField] Vector3 openPosition;
    [SerializeField] Vector3 closePosition;

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

    void Open()
    {
        transform.position = Vector3.Lerp(transform.position,
            openPosition, speed * Time.deltaTime);
    }

    void Close()
    {
        transform.position = Vector3.Lerp(transform.position,
            closePosition, speed * Time.deltaTime);
    }
    public override void interaction()
    {

    }
    public override void turnOnOff(bool state)
    {
        isOpen = state;
    }
}
