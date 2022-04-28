namespace ToyRobotLib
{
    public interface IPrint
    {
        public void Instructions();
        public void Commands();
        public void Custom(string text);
        public void Exit();
    }
}