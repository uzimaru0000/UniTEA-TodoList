using UniTEA;
using UniTEA.Utils;

public class DeleteTodoMsg : OneValueMsg<Msg, int>
{
  public override Msg GetMessage() => Msg.DeleteTodo;
  public DeleteTodoMsg(int id) : base(id) { }
}
