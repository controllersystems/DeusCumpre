﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace ControllerSystems.DeusCumpre.Domain.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class Post
	{
		public string Title
		{
			get;
			set;
		}

		public DateTime CreationDate
		{
			get;
			set;
		}

		public string Body
		{
			get;
			set;
		}

		public User User
		{
			get;
			set;
		}

		public List<String> Tags
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}

	}
}

