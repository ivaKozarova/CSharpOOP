namespace P04.PizzaCalories.Common.Exceptions
{
    public class ExceptionsMessages
    {
        public static string InvalidTypeOfDough = "Invalid type of dough.";
        public static string InvalidDoughWeight = "Dough weight should be in the range[{0}..{1}].";
        public static string InvalidToppingExc = "Cannot place {0} on top of your pizza.";
        public static string InvalidToppingWeightExc = "{0} weight should be in the range [{1}..{2}].";
        public static string LimitCountOfToppingsExc = "Number of toppings should be in range [0..10].";
        public static string InvalidLengthOfPizzaNameExc = "Pizza name should be between 1 and 15 symbols.";
    }
}
