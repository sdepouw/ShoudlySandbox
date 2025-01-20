namespace ShouldlySandbox;

public class InvalidStrengthException(int strength) : Exception($"{strength} is not a valid!");