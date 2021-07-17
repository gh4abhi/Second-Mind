using UnityEngine;

//Scale up the banner.

public class InfoBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform SectionInformation;
    float SPEED = 6f;
    Vector3 desiredScale = Vector3.zero;

    public static InfoBehaviour instance;

    public static InfoBehaviour Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<InfoBehaviour>();
            }
            return instance;
        }
    }
    void Update()
    {
        SectionInformation.localScale = Vector3.Lerp(SectionInformation.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;
        //print("Object Open");
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
        //print("Object Closed");
    }
}
