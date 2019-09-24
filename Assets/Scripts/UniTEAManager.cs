using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniTEA;

public class UniTEAManager : MonoBehaviour
{
  [SerializeField]
  new Renderer renderer;

  public static UniTEA<Model, Msg> TEA
  {
    get;
    private set;
  }


  void Awake()
  {
    var updater = new Updater();
    TEA = new UniTEA<Model, Msg>(Model.Init, updater, renderer);
  }
}
