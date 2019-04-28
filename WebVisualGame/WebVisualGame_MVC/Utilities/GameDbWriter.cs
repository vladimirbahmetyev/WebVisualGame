﻿using System;
using System.Collections.Generic;
using System.Linq;

//using GameInterpreror;
using WebVisualGame_MVC.Data;
using WebVisualGame_MVC.Data.GameComponents;

namespace WebVisualGame_MVC.Utilities
{

	public class GameDbWriter
	{
		//private readonly GameMachineReader reader;

		private readonly DataContext dataBase;

		public GameDbWriter(DataContext db)
		{
			//reader = new GameMachineReader();

			dataBase = db;
		}

		public void SaveGameComponents(string sourceCode, Game gameNote)
		{
			//Queue<DialogPoint> dpQueue = new Queue<DialogPoint>();

			//HashSet<DialogPoint> dpSet = new HashSet<DialogPoint>();

			//DialogPoint gameStart = null;

			//try
			//{
			//	gameStart = reader.ReadGame(sourceCode);
			//}
			//catch (ApplicationException e)
			//{
			//	throw e;
			//}

			//dpQueue.Enqueue(gameStart);

			//dpSet.Add(gameStart);

			//while (dpQueue.Count > 0)
			//{
			//	DialogPoint currPoint = dpQueue.Dequeue();

			//	var pointDialogNote = new Data.GameData.PointDialog()
			//	{
			//		Background_imageURL = "",
			//		StateNumber = currPoint.ID,
			//		Text = currPoint.Text,
			//		PointDialogActions = new List<Data.GameData.PointDialogAction>()
			//	};

			//	if (currPoint.Actions != null)
			//	{
			//		for (int i = 0; i < currPoint.Actions.Length; ++i)
			//		{
			//			var actionNote = new Data.GameData.PointDialogAction()
			//			{
			//				Type = (currPoint.Actions[i].Type == ActionType.FindKey),
			//				KeyAction = currPoint.Actions[i].KeyNumber,
			//			};

			//			pointDialogNote.PointDialogActions.Add(actionNote);
			//		}
			//	}

			//	gameNote.PointDialogues.Add(pointDialogNote);

			//	foreach (var currLink in currPoint.Links)
			//	{
			//		var linkNote = new Data.GameData.Transition()
			//		{
			//			StartPoint = currPoint.ID,
			//			NextPoint = currLink.NextPoint.ID,
			//			Conditions = new List<Data.GameData.Condition>(),
			//			TransitionActions = new List<Data.GameData.TransitionAction>(),
			//			Text = currLink.Text
			//		};

			//		for (int i = 0; i < currLink.Conditions.Length; ++i)
			//		{
			//			var conditionNote = new Data.GameData.Condition()
			//			{
			//				KeyСondition = currLink.Conditions[i].KeyNumber,
			//				Type = (currLink.Conditions[i].Type == ConditionType.Have)
			//			};

			//			linkNote.Conditions.Add(conditionNote);
			//		}

			//		for (int i = 0; i < currLink.Actions.Length; ++i)
			//		{
			//			var linkActionNote = new Data.GameData.TransitionAction()
			//			{
			//				Type = (currLink.Actions[i].Type == ActionType.FindKey),
			//				KeyAction = currLink.Actions[i].KeyNumber
			//			};

			//			linkNote.TransitionActions.Add(linkActionNote);
			//		}

			//		gameNote.Transitions.Add(linkNote);

			//		if (!dpSet.Contains(currLink.NextPoint))
			//		{
			//			dpQueue.Enqueue(currLink.NextPoint);

			//			dpSet.Add(currLink.NextPoint);
			//		}
			//	}
			//}
		}

		public void UpdateGameComponents(string sourceCode, Game gameNote)
		{
			dataBase.Transitions.RemoveRange(dataBase.Transitions.Where(c => c.GameId == gameNote.Id));

			dataBase.PointDialogs.RemoveRange(dataBase.PointDialogs.Where(c => c.GameId == gameNote.Id));

			SaveGameComponents(sourceCode, gameNote);

			//try
			//{
			//	dataBase.Update(gameNote);

			//	dataBase.SaveChanges();
			//}
			//catch (Exception e)
			//{
			//	//...
			//}
		}

		public void DeleteGame(int gameId)
		{
			dataBase.Transitions.RemoveRange(dataBase.Transitions.Where(c => c.GameId == gameId));

			dataBase.PointDialogs.RemoveRange(dataBase.PointDialogs.Where(c => c.GameId == gameId));

			dataBase.Games.RemoveRange(dataBase.Games.FirstOrDefault(c => c.Id == gameId));

			dataBase.SaveChanges();
		}
	}
}

