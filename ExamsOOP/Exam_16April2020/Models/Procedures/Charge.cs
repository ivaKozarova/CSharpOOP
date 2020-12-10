using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        private const int CHARGING_HAPPINESS = 12;
        private const int CHARGING_ENERGY = 10;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness += CHARGING_HAPPINESS;
            robot.Energy += CHARGING_ENERGY;
        }
    }
}
