﻿using HairSalon.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalon.Contract.Repositories.Entity
{
	public class UserInfo : BaseEntity
	{
		public string FullName { get; set; } = string.Empty;
		public string? BankAccount { get; set; }
		public string? BankAccountName { get; set; }
		public string? Bank { get; set; }
	}
}
