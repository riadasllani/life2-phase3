using System;
using CsvHelper.Configuration;

namespace MatchingApp.Models.Entities
{
	public class UserMap : ClassMap<User>
    {
		public UserMap()
		{
			Map(m => m.Id).Name("15624510");
			Map(m => m.Gender).Name("Male");
            Map(m => m.Age).Name("19");
            Map(m => m.Credits).Name("19000");
            Map(m => m.Active).Name("0");


        }
	}
}