using System.Text;

namespace Cars
{
    public class Seat : Car , ICar
    {
        public Seat(string model, string color)
            : base(model, color)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
                    .AppendLine(this.Start())
                .AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
