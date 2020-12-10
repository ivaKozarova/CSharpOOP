using System;
using System.Collections.Generic;

using RobotService.Models.Robots;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Utilities.Enums;
using RobotService.Models.Procedures;
using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Utilities.Enums.ProcedureType;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private Dictionary<ProcedureType, IProcedure> procedures; 
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            CreateProcedures();
        }

        private void CreateProcedures()
        {            
            this.procedures[ProcedureType.Chip] = new Chip();
            this.procedures[ProcedureType.Charge] = new Charge();
            this.procedures[ProcedureType.Rest] = new Rest();
            this.procedures[ProcedureType.Polish] = new Polish();
            this.procedures[ProcedureType.Work] = new Work();
            this.procedures[ProcedureType.TechCheck] = new TechCheck();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if(!Enum.TryParse(robotType, out RobotType robotTypeName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            IRobot robot = CreateRobot(robotTypeName, name, energy, happiness, procedureTime);
            this.garage.Manufacture(robot);
            var msg = String.Format(OutputMessages.RobotManufactured, name);
            return msg;
        }
        public string Chip(string robotName, int procedureTime)
        {
           IRobot robot =  GetRobotByName(robotName);
            this.procedures[ProcedureType.Chip].DoService(robot, procedureTime);
            var msg = String.Format(OutputMessages.ChipProcedure, robot.Name);
            return msg;

        }
        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            this.procedures[ProcedureType.Charge].DoService(robot, procedureTime);
            var msg = String.Format(OutputMessages.ChargeProcedure, robotName);
            return msg;
        }
        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeName);
            var msg = this.procedures[procedureTypeName].History();
            return msg;
        }
        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            this.procedures[ProcedureType.Polish].DoService(robot, procedureTime);
            var msg = String.Format(OutputMessages.PolishProcedure, robotName);
            return msg;
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            this.procedures[ProcedureType.Rest].DoService(robot, procedureTime);
            var msg = String.Format(OutputMessages.RestProcedure, robotName);
            return msg;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobotByName(robotName);
            this.garage.Sell(robotName, ownerName);
            if(robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            this.procedures[ProcedureType.TechCheck].DoService(robot, procedureTime);
            var msg = String.Format(OutputMessages.TechCheckProcedure, robotName);
            return msg;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            this.procedures[ProcedureType.Work].DoService(robot, procedureTime);
            var msg = String.Format(String.Format(OutputMessages.WorkProcedure, robotName,procedureTime));
            return msg;
        }

        private IRobot CreateRobot(RobotType robotTypeName, string name,
                                   int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            switch (robotTypeName)
            {
                case RobotType.PetRobot:
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.HouseholdRobot:
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case RobotType.WalkerRobot:
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }
            return robot;
        }
        private IRobot GetRobotByName(string robotName)
        {

            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            return this.garage.Robots[robotName];
        }
    }
}
