using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica
{
	public class User
	{	[Key]
		public int id { get; set; }
		public string family_name { get; set; }
		public string first_name { get; set; }
		public string patronymic { get; set; }
		public string login { get; set; }
		public string password { get; set; }
	}

	public class UserContext : DbContext
	{

		public UserContext():base("myConnection") { }

		public DbSet<User> Users { get; set; }
	}
}
