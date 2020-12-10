using System;
using System.Linq;
using System.Collections.Generic;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        

        public Controller()
        {           
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if(this.computers.Any(c=>c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = CreateComputer(computerType, id, manufacturer, model, price);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            this.computers.Add(computer);
            return $"{String.Format(SuccessMessages.AddedComputer, id)}";
        }
        public string AddComponent(int computerId, int id, string componentType,
                                    string manufacturer, string model, decimal price,
                                    double overallPerformance, int generation)
        {

            CheckDoesComputerExist(computerId);

            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = CreateComponent(componentType, id, manufacturer, model, price,
                                            overallPerformance, generation);

            if (component == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            computer.AddComponent(component);
            this.components.Add(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

        }
        public string AddPeripheral(int computerId, int id, string peripheralType,
                                  string manufacturer, string model, decimal price, double overallPerformance,
                                    string connectionType)
        {
            CheckDoesComputerExist(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            IPeripheral peripheral = CreatePeripheral(peripheralType, id, manufacturer, model, price,
                overallPerformance, connectionType);

            if (peripheral == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        private void CheckDoesComputerExist(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        public string BuyBest(decimal budget)
        {
            var computersWithPriceLessOrEqualToBudget = this.computers.FindAll(c => c.Price <= budget);
            if(computersWithPriceLessOrEqualToBudget.Count == 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            var bestComp = computersWithPriceLessOrEqualToBudget.OrderByDescending(c => c.OverallPerformance).Take(1).ToList();
            return bestComp[0].ToString();
        }

        public string BuyComputer(int id)
        {
            CheckDoesComputerExist(id);
            var computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);
            return computer.ToString();

        }

        public string GetComputerData(int id)
        {
            CheckDoesComputerExist(id);
            var computer = this.computers.FirstOrDefault(c => c.Id == id);
            return computer.ToString();
        }
        public void Close()
        {
            Environment.Exit(0);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckDoesComputerExist(computerId);
            var computer = this.computers.First(c => c.Id == computerId);
            computer.RemoveComponent(componentType);
            var component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);
            var componentId = component.Id;

            return String.Format(SuccessMessages.RemovedComponent, componentType, componentId);

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckDoesComputerExist(computerId);
            var computer = this.computers.First(c => c.Id == computerId);
            computer.RemovePeripheral(peripheralType);
            var peripheral = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheral);
            var peripheralId = peripheral.Id;

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheralId);

        }
        public IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            return computer;
        }
        private IComponent CreateComponent(string componentType, int id, string manufacturer,
                                    string model, decimal price, double overallPerformance,
                                        int generation)
        {
            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            return component;

        }
        private IPeripheral CreatePeripheral(string peripheralType, int id, string manufacturer,
                                            string model, decimal price, double overallPerformance,
                                            string connectionType)
        {
            IPeripheral peripheral = null;

            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            return peripheral;
        }

    }
}
