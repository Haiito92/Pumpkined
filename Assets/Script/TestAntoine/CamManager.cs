using Cinemachine;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] _dollyCams;
    int _camIndex = 0;

    private static CamManager _instance;
    public static CamManager Instance => _instance;
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _dollyCams[0].gameObject.SetActive(true);
    }

    public void NextDollyCam()
    {
        _dollyCams[_camIndex].gameObject.SetActive(false);
        _camIndex = (_camIndex + 1 ) % _dollyCams.Length;
        _dollyCams[_camIndex].gameObject.SetActive(true);
    }
}
