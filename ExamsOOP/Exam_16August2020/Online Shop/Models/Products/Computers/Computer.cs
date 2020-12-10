using System;
using System.Linq;
using System.Collections.Generic;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> periphrals;

        protected Computer(int id, string manufacturer,
                          string model, decimal price,
                            double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.periphrals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.periphrals.AsReadOnly();

        public override double OverallPerformance
        => CalculateOverallperformance();

        public override decimal Price
        => CalculatePrice();

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.periphrals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }
            this.periphrals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            if(component == null)
            {
                var msg = String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }
            this.components.Remove(component);
            return component;

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {

            var peripheral = this.periphrals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            if (peripheral == null)
            {
                var msg = String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }
            this.periphrals.Remove(peripheral);
            return peripheral;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var averagePerformance = this.Peripherals.Any() ?
                                    this.Peripherals.Average(p => p.OverallPerformance) : 0;
            var msgCompPeripherals = String.Format(SuccessMessages.ComputerPeripheralsToString,
               this.Peripherals.Count, $"{averagePerformance:f2}");


            var msgCompComponents = String.Format(SuccessMessages.ComputerComponentsToString, this.Components.Count);
           
            sb                
                .AppendLine($" {msgCompComponents}");
            foreach (var item in this.Components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            sb.AppendLine($" {msgCompPeripherals}");
            foreach (var item in this.Peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }

            return base.ToString() +Environment.NewLine+ sb.ToString().TrimEnd();
        }

        private double CalculateOverallperformance()
        {
            if(this.Components.Any())
            {
                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
            return base.OverallPerformance;
        }
        private decimal CalculatePrice()
        {
            return base.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);
        }

    }
}
