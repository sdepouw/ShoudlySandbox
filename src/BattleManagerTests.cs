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
}
