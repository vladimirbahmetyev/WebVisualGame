﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebVisualGame_MVC.Models.DbModel.GameComponents
{
	public class Condition
	{
		[Key]
		public int Id { get; set; }
		
		[ForeignKey("Transition")]
		[Required]
		public int TransitionId { get; set; }

		[Required]
		public bool Type { get; set; }

		[Required]
		public int KeyСondition { get; set; }
	}
}
