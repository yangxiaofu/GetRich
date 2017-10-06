using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

namespace Game.Objects.Characters.Tests{
	
	[TestFixtureAttribute]
	[CategoryAttribute("Energy Level Tests")]
	public class EnergyLevelTests
	{
		[TestAttribute]
		[CategoryAttribute("Energy Level")]
		public void T01CheckLevel_ReturnsIsWorkingEqualsFalse()
		{
			float level = 0;
			float energyLevelToRest = 0;
			float energyLevelConsumedPerSecond = 0;
			float energyLevelRestoredPerSecond = 0;
			var characterStubArgs = new CharacterStubArgs(0, 0, 0);
			var character = new CharacterStub(characterStubArgs);

			var energyLevelArgs = new EnergyLevelArgs(
				level,
				energyLevelToRest,
				energyLevelConsumedPerSecond,
				energyLevelRestoredPerSecond, 
				character
			);

			var energylevel = new EnergyLevel(energyLevelArgs);
			energylevel.CheckLevel();
			
			Assert.IsFalse(character.GetIsWorking());
		}

		[TestAttribute]
		public void T02CheckLevel_ReturnsIsWorking()
		{
			float level = 100;
			float energyLevelToRest = 50;
			float energyLevelConsumedPerSecond = 0;
			float energyLevelRestoredPerSecond = 0;
			var characterStubArgs = new CharacterStubArgs(0, 0, 0);
			var character = new CharacterStub(characterStubArgs);

			var energyLevelArgs = new EnergyLevelArgs(
				level,
				energyLevelToRest,
				energyLevelConsumedPerSecond,
				energyLevelRestoredPerSecond, 
				character
			);

			var energylevel = new EnergyLevel(energyLevelArgs);
			energylevel.CheckLevel();
			
			Assert.IsTrue(character.GetIsWorking());
		}

		[TestAttribute]
		public void T03CheckLevel_ReturnsIsWorking()
		{
			float level = 50;
			float energyLevelToRest = 50;
			float energyLevelConsumedPerSecond = 0;
			float energyLevelRestoredPerSecond = 0;
			var characterStubArgs = new CharacterStubArgs(0, 0, 0);
			var character = new CharacterStub(characterStubArgs);

			var energyLevelArgs = new EnergyLevelArgs(
				level,
				energyLevelToRest,
				energyLevelConsumedPerSecond,
				energyLevelRestoredPerSecond, 
				character
			);

			var energylevel = new EnergyLevel(energyLevelArgs);
			energylevel.CheckLevel();
			
			Assert.False(character.GetIsWorking());
		}
	}

}
