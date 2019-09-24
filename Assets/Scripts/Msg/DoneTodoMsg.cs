using UniTEA;
using UniTEA.Utils;

public class DoneTodoMsg : OneValueMsg<Msg, int>
{
  public override Msg GetMessage() => Msg.DoneTodo;
  public DoneTodoMsg(int id) : base(id) { }
}
