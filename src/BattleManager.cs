namespace ShouldlySandbox;

public class BattleManager
{
  public int CalculateDamage(int strength)
  {
    if (strength < 0)
    {
      throw new InvalidStrengthException(strength);
    }
    return strength + 42;
  }

  public List<decimal> GetShopPrices() => [2.99m, 45m, 1000m, 65m, 457.22m];
  
  public Task ToBattle() => Task.CompletedTask; // Imagine a fierce battle taking place.

  public Task Explode() => throw new NotImplementedException("Not done yet!");

  public string GetBattleName() => $"The Amazing Contest{Environment.NewLine}An Incredible Tale\r";
}
