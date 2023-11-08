using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    //Test Timing Bar
    [SerializeField] TimingBar _timingBar;

    //Test Sound
    [SerializeField] SoundEmitter _soundEmitter;


    //Test Timing Bar

    public void DoAction(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _timingBar.DoAction();
        }
    }

    public void ActivateSoundEmitter(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _soundEmitter.EmitSound();
        }
    }

    public void ChangeCam(InputAction.CallbackContext ctx)
    {
        if(ctx.started)
        {
            CamManager.Instance.NextCam();
        }
    }
}
