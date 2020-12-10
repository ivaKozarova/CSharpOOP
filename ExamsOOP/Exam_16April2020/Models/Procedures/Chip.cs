using System;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int NEEDED_HAPPINESS_FOR_CHIPPING= 5;
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if(robot.IsChipped)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped, robot.Name));
            }
            robot.Happiness -= NEEDED_HAPPINESS_FOR_CHIPPING;
            robot.IsChipped = true;
            
        }
    }
}
