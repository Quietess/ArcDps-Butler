using System;
using System.Collections.Generic;
using System.Linq;
using EVTC_Log_Parser.Model;
using EVTC_Log_Parser.Model.Data.Table;
using Butler.Logic.Interfaces;
using Butler.Models;

namespace Butler.Logic
{
	public class LogFileConverter : ILogFileConverter
	{
		public void ConvertLog(IEncounterLog herosLog, SharedValues sharedValues)
		{
			herosLog.Name = sharedValues.Target;
			herosLog.EncounterDate = sharedValues.LogStart.ToLocalTime();
			herosLog.EncounterResult = sharedValues.Success ? "Success" : "Fail";

			var time = TimeSpan.FromSeconds(sharedValues.FightDuration);
			herosLog.EncounterTime = new TimeSpan(time.Days, time.Hours, time.Minutes, time.Seconds);

			foreach (var sharedValuesPlayerValue in sharedValues.PlayerValues)
			{
				var characterStats = new CharacterStatistics()
				{
					Name = sharedValuesPlayerValue.Character,
					DisplayName = sharedValuesPlayerValue.Account.Substring(1),
					BossDps = Math.Round(sharedValuesPlayerValue.DPSBoss),
					BossDamage = sharedValuesPlayerValue.TotalBoss,
					AllDps = Math.Round(sharedValuesPlayerValue.DPSAll),
					AllDamage = sharedValuesPlayerValue.TotalAll,
					Down = sharedValuesPlayerValue.Down.ToString(),
					Role = sharedValuesPlayerValue.Profession,
				};

				if (sharedValuesPlayerValue.Dead 
				    && sharedValuesPlayerValue.FightDurationPlayer < sharedValues.FightDuration)
				{
					var percent = (sharedValuesPlayerValue.FightDurationPlayer / sharedValues.FightDuration * 100).ToString("0");
					var timeOfDead = TimeSpan.FromSeconds(sharedValuesPlayerValue.FightDurationPlayer);
					characterStats.Dead = $"{timeOfDead.Minutes}m {timeOfDead.Seconds}s ({percent}% alive)";
				}

				AddSkills(sharedValuesPlayerValue.Skills, characterStats);
				
				herosLog.CharacterStatistics.Add(characterStats);
			}

			herosLog.BossDps =
				Math.Round(sharedValues.PlayerValues.Sum(i => i.TotalBoss) / sharedValues.FightDuration);

			herosLog.AllDps =
				Math.Round(sharedValues.PlayerValues.Sum(i => i.TotalAll) / sharedValues.FightDuration);
		}

		private static void AddSkills(IEnumerable<SkillDps> skills, CharacterStatistics characterStats)
		{
			foreach (var skill in skills.OrderByDescending(i => i.DPSBoss))
			{
				var skillDamage = new SkillDamage
				{
					Name = skill.Name,
					SkillId = skill.SkillId,
					DamageAll = skill.PowerAll + skill.CondiAll,
					DamageBoss = skill.PowerBoss + skill.CondiBoss,
					DpsAll = Math.Round(skill.DPSAll),
					DpsBoss = Math.Round(skill.DPSBoss)
				};

				characterStats.Skills.Add(skillDamage);
			}
		}
	}
}