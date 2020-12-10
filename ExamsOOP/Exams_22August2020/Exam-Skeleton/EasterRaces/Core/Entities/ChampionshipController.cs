using System;
using System.Linq;
using System.Text;

using EasterRaces.Core.Contracts;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {

        private const int MIN_COUNT_OF_DRIVERS = 3;
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;
        private CarFactory carFactory;
           
        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
            this.carFactory = new CarFactory();

        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.driverRepository.GetByName(driverName);
            if(driver == null)
            {
                var msg = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(msg);
            }
            var car = this.carRepository.GetByName(carModel);
            if(car == null)
            {
                var msg = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(msg);
            }
            driver.AddCar(car);
            var outputMsg = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return outputMsg;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if(!this.driverRepository.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            IDriver driver = this.driverRepository.GetByName(driverName);

            if(!this.raceRepository.GetAll().Any(r=> r.Name == raceName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            IRace race = this.raceRepository.GetByName(raceName);

            race.AddDriver(driver);
            var msg = String.Format(OutputMessages.DriverAdded, driverName, raceName);
            return msg;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if(this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model));
            }
            ICar car = this.carFactory.CreateCar(type, model, horsePower);
            this.carRepository.Add(car);
            var msg = String.Format(OutputMessages.CarCreated, car.GetType().Name, model);
            return msg;


        }

        public string CreateDriver(string driverName)
        {
            if(this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.DriversExists, driverName));
            }
            Driver driver = new Driver(driverName);
            this.driverRepository.Add(driver);
            var msg = String.Format(OutputMessages.DriverCreated, driverName);
            return msg;
        }

        public string CreateRace(string name, int laps)
        {
           if(this.raceRepository.GetAll().Any(r=>r.Name == name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);
            var msg = String.Format(OutputMessages.RaceCreated, name);
            return msg;
        }

        public string StartRace(string raceName)
        {
           if(!this.raceRepository.GetAll().Any(r=>r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            var race = this.raceRepository.GetByName(raceName);
            var countOfDrivers = race.Drivers.Count;
            if(countOfDrivers < MIN_COUNT_OF_DRIVERS)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MIN_COUNT_OF_DRIVERS));
            }

            var winners = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Driver {winners[0].Name} wins {race.Name} race.")
                .AppendLine($"Driver {winners[1].Name} is second in {race.Name} race.")
                .AppendLine($"Driver {winners[2].Name} is third in {race.Name} race.");

            return sb.ToString().TrimEnd();
        }

        public void End()
        {
            Environment.Exit(0);
        }
    }
}
