﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace ControllerSystems.DeusCumpre.Application.Interfaces.Services
{
	using ControllerSystems.DeusCumpre.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public interface IPublisherService 
	{
		void Publish(Post post);

		void Delete(Post post);

		void Edit(Post post);

	}
}

