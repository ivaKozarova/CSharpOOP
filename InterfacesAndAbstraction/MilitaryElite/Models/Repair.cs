namespace MilitaryElite.Models
{
    public class Repair
    {
        public Repair(string name, int hours)
        {
            this.PartName = name;
            this.HoursWorked = hours;
        }
        public string PartName { get; }
        public int HoursWorked { get;}
        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
