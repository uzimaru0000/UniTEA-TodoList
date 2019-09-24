using UniTEA;
using UniTEA.Utils;

public class InputTodoMsg : OneValueMsg<Msg, string>
{
  public override Msg GetMessage() => Msg.InputTodo;
  public InputTodoMsg(string str) : base(str) { }
}
