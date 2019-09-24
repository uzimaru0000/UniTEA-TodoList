using UnityEngine;

public class Dispatcher : MonoBehaviour
{

  public void InputEvent(string str)
  {
    UniTEAManager.TEA.Dispatch(new InputTodoMsg(str));
  }

  public void CreateEvent()
  {
    UniTEAManager.TEA.Dispatch(new CreateTodoMsg());
  }
}