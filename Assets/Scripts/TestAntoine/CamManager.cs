using Cinemachine;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    //[SerializeField] CinemachineVirtualCamera[] _dollyCams;
    [SerializeField] CinemachineVirtualCamera[] _cams;
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
        //_dollyCams[0].gameObject.SetActive(true);
        foreach(CinemachineVirtualCamera cam in _cams) 
        {
            cam.Priority = 9;
        }
        _camIndex = 0;
        _cams[_camIndex].Priority = 11;
    }

    public void NextCam()
    {
        _cams[_camIndex].Priority = 9;
        _camIndex = (_camIndex + 1) % _cams.Length;
        _cams[_camIndex].Priority = 11;
    }

    public void ChangeToCam(int index)
    {
        foreach(CinemachineVirtualCamera cam in _cams) 
        {
            cam.Priority = 9;
        }
        _cams[index].Priority = 11;
    }



    //public void NextDollyCam()
    //{
    //    _dollyCams[_camIndex].gameObject.SetActive(false);
    //    _camIndex = (_camIndex + 1 ) % _dollyCams.Length;
    //    _dollyCams[_camIndex].gameObject.SetActive(true);
    //}
}
