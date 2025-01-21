using Shouldly;
using Xunit;

namespace ShouldlySandbox;

/// <summary>
/// Testing strings
/// </summary>
public class BattleNameTests
{
  private readonly BattleManager _battleManager = new();

  // Case-sensitive exact match (no parameters needed)
  [Fact]
  public void BattleNameIsCapitalized()
  {
    string expectedContent = $"The Amazing Contest{Environment.NewLine}An Incredible Tale\r";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldBe(expectedContent);
  }

  // Ignoring case
  [Fact]
  public void BattleNameIsAnAmazingOne()
  {
    string expectedContent = $"the amazing contest{Environment.NewLine}an incredible tale\r";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldBe(expectedContent, StringCompareShould.IgnoreCase);
  }

  // Ignoring line endings
  [Fact]
  public void BattleNameHasContestAndTagline()
  {
    string expectedContent = $"The Amazing Contest{Environment.NewLine}An Incredible Tale\r\n";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldBe(expectedContent, StringCompareShould.IgnoreLineEndings);
  }

  // Ignoring case and line endings
  [Fact]
  public void BattleNameHasALotToSay()
  {
    string expectedContent = $"THE AMAZING CONTEST{Environment.NewLine}An Incredible Tale\r\n";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldBe(expectedContent, StringCompareShould.IgnoreCase | StringCompareShould.IgnoreLineEndings);
  }

  // Ignoring case for string contains is the default!
  [Fact]
  public void BattleNameContainsAmazingThings()
  {
    const string expectedContent = "amazing";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldContain(expectedContent);
  }

  // Case-sensitive Contains example
  [Fact]
  public void BattleNameHasACapitalizedTellAllTale()
  {
    const string expectedContent = "Tale";

    string battleName = _battleManager.GetBattleName();

    battleName.ShouldContain(expectedContent, Case.Sensitive);
  }
}
