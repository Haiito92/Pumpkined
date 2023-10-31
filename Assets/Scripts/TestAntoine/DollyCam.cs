using UnityEngine;

public class DollyCam : MonoBehaviour
{
    public void CamTrigger()
    {
        CamManager.Instance.NextDollyCam();
    }
}
