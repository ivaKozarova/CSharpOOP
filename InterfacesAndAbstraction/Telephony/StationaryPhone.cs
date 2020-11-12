namespace Telephony
{
    class StationaryPhone : ICallable
    {
        public string Calling(string input)
        {
            foreach (var symbol in input)
            {
                if (!char.IsDigit(symbol))
                {
                    return "Invalid number!";
                }
            }
            return $"Dialing... {input}";
        }
    }
}
