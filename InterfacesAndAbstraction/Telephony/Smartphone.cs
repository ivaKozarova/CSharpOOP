namespace Telephony
{
    public class Smartphone : IBrowsable , ICallable
    {
        public string Browsing(string input)
        {
            foreach (var symbol in input)
            {
                if(char.IsDigit (symbol))
                {
                    return "Invalid URL!";
                }
            }
            return $"Browsing: {input}!";
        }

        public string Calling(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return "Invalid number!";
                }
            }
            return $"Calling... {number}";
        }
    }
}
