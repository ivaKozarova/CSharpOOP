using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }
        public void AddRange(Stack<string> values)
        {
            while (values.Any())
            {
                this.Push(values.Pop());
            }
        }
    }
}
