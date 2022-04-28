namespace ToyRobotLib
{
    public interface IToyRobot
    {
        void Place(int x, int y, Direction facing);
        void Move();
        void Left();
        void Right();
        string Report();
    }
}