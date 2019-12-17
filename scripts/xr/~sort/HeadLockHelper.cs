/* 
NOTE:
inspired by:
https://creator.magicleap.com/learn/tutorials/interacting-with-head-locked-content-unity-r-version
*/
using System;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace Codebycandle.Util.Trans
{
  public class HeadLockHelper:MonoBehaviour
  {
    #region VAR-PRIVATE
    private Transform _cameraTrans;
    private const float _distance = 2.0f;
    #endregion

    #region MONO-BEHAVIOUR
    void Awake()
    {
      _cameraTrans = Camera.main.transform;
    }
    #endregion

    #region UTIL-PUBLIC
    public void HardHeadLock(GameObject obj)
    {
      obj.transform.position = _cameraTrans.position + _cameraTrans.forward * _distance;
      obj.transform.rotation = _cameraTrans.rotation;
    }

    public void HeadLock(GameObject obj, float speed)
    {
      // speed
      speed = Time.deltaTime * speed;

      // position
      Vector3 posTo = _cameraTrans.position + (_cameraTrans.forward * _distance);
      obj.transform.position = Vector3.SlerpUnclamped(obj.transform.position, posTo, speed);

      // rotation
      Quaternion rotTo = Quaternion.LookRotation(obj.transform.position - _cameraTrans.position);
      obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, rotTo, speed);	
    }
    #endregion
  }
}