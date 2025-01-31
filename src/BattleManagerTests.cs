using Shouldly;
using Xunit;

namespace ShouldlySandbox;

public class BattleManagerTests
{
  private readonly BattleManager _battleManager = new();

  // Basic assertions
  [Fact]
  public void CalculatesDamageAs100Given58Strength()
  {
    const int expectedCalculatedDamage = 100;
    const int strength = 58;

    int calculatedDamage = _battleManager.CalculateDamage(strength);

    calculatedDamage.ShouldBe(expectedCalculatedDamage);
  }

  // Asserting counts/lengths
  [Fact]
  public void TheShopHasFiveItemsForSale()
  {
    const int expectedNumberOfItems = 5;

    List<decimal> shopPrices = _battleManager.GetShopPrices();

    shopPrices.Count.ShouldBe(expectedNumberOfItems);
  }

  // Assert exception thrown
  [Fact]
  public void DamageCalculationRejectsNegativeStrength()
  {
    const int invalidStrength = -1;

    Action calculateDamageCall = () => _battleManager.CalculateDamage(invalidStrength);

    InvalidStrengthException thrownException = calculateDamageCall.ShouldThrow<InvalidStrengthException>();
    thrownException.Message.ShouldContain(invalidStrength.ToString());
  }

  // Assert exception not thrown
  [Fact]
  public void DamageCalculationAccepts0Strength()
  {
    const int acceptableStrength = 0;

    Action calculateDamageCall = () => _battleManager.CalculateDamage(acceptableStrength);

    calculateDamageCall.ShouldNotThrow();
  }

  // Asynchronous exception assertions
  [Fact]
  public async Task ExplodeWillNeverBeImplemented()
  {
    Func<Task> explodeCall = () => _battleManager.Explode();

    await explodeCall.ShouldThrowAsync<NotImplementedException>();
  }

  [Fact]
  public async Task ToBattleShouldNotExplode()
  {
    Func<Task> toBattleCall = () => _battleManager.ToBattle();

    await toBattleCall.ShouldNotThrowAsync();
  }

  // Multiple assertions
  [Fact]
  public void ShopPricesAreNotTooExpensive()
  {
    List<decimal> shopPrices = _battleManager.GetShopPrices();

    shopPrices.ShouldSatisfyAllConditions(
      () => shopPrices.First().ShouldBeLessThan(3m),
      () => shopPrices.Sum().ShouldBeLessThan(5000m),
      () => shopPrices[1].ShouldBeLessThan(50m),
      () => shopPrices[1].ShouldBeGreaterThan(10m)
    );
  }

  // All items in collection exist, in order
  [Fact]
  public void ShopPricesReturnCorrectAmounts()
  {
    List<decimal> expectedShopPrices = [2.99m, 45m, 1000m, 65m, 457.22m];

    List<decimal> shopPrices = _battleManager.GetShopPrices();

    // The order of items in the list matters!
    shopPrices.ShouldBe(expectedShopPrices);
  }

  // All items in collection exist, out of order
  [Fact]
  public void ShopPricesReturnCorrectAmountsRegardlessOfOrder()
  {
    List<decimal> expectedShopPrices = [457.22m, 1000m, 2.99m, 45m, 65m];

    List<decimal> shopPrices = _battleManager.GetShopPrices();

    // The order of items in the list does not matter!
    shopPrices.ShouldBe(expectedShopPrices, ignoreOrder: true);
  }
}
