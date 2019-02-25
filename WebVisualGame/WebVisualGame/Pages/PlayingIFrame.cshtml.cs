using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Web;
using WebVisualGame.Data;
using WebVisualGame.Data.GameData;
using System.Text.RegularExpressions;

namespace WebVisualGame.Pages
{
    public class PlayingIFrameModel : PageModel
    {

		private readonly Repository db;
		private readonly int gameId;
		private SortedSet<int> keys;

        public void OnGet(int id_transition)
        {
			id_transition = matchingTransition[id_transition];
			pointID = db.Transitions.FirstOrDefault(i => i.StartPoint == pointID &&
			i.GameId == gameID &&
			i.Id == id_transition).NextPoint;

			var matchingTransition = db.Transitions.Select(i => i.StartPoint == pointID &&
			i.GameId == gameID).ToArray();
			var l = db.�onditions.Select(i => i.TransitionId )
		}

		public void OnPostAnswer(int index_transition)
		{
			var transition = Transitions[index_transition];
			Point = db.PointDialogs.FirstOrDefault(i => i.StateNumber == Point.StateNumber &&
			i.GameId == gameId);

			var transiton_actions = db.TransitionActions.Include(i => 
				i.TransitionId == transition.Id).ToArray();
			var point_actions = db.PointDialogActions.Include(i => 
				i.PointDialogId == Point.Id).ToArray();
		}

		private void UpdateTransition()
		{
			var newTransitons = db.Transitions.Where(i => i.GameId == gameId &&
				i.StartPoint == Point.StateNumber).ToList();

			var mergedTables = (from trans in newTransitons
								join cond in db.Conditions on trans.Id equals cond.TransitionId
								orderby (trans.Id)
								select new
								{
									Id = trans.Id,
									Type = cond.Type,
									Key�ondition = cond.Key�ondition
								}).ToArray();
			// deleting impossible transitions
			for (int i = 0; i < mergedTables.Length; ++i)
			{
				// Type == 1 => keys canrains Key�ondition, else deleting Transition
				// table have to been sorted
				if (mergedTables[i].Type !=
					keys.Contains(mergedTables[i].Key�ondition))
				{
					int transitionId = mergedTables[i].Id;
					FiltereTransition(newTransitons, transitionId);
					while (mergedTables[i].Id == transitionId)
					{
						++i;
					}
					--i;
				}
			}
			Size = newTransitons.Count;
			Transitions = new Transition[Size];
			int j = 0;
			foreach (var newTransition in newTransitons)
			{
				Transitions[j] = newTransition;
				++j;
			}
		}

		private void FiltereTransition(List<Transition> transitions, int id)
		{
			foreach (var transition in transitions)
			{
				if (transition.Id == id)
				{
					transitions.Remove(transition);
					return;
				}
			}
		}

		private void FillingKey(TransitionAction[] transiton_actions,
			PointDialogAction[] point_actions)
		{
			for (int i = 0; i < transiton_actions.Length; ++i)
			{
				if (transiton_actions[i].Type)
				{
					keys.Add(transiton_actions[i].KeyAction);
				}
				else
				{
					keys.Remove(transiton_actions[i].KeyAction);
				}
			}
			for (int i = 0; i < point_actions.Length; ++i)
			{
				if (point_actions[i].Type)
				{
					keys.Add(point_actions[i].KeyAction);
				}
				else
				{
					keys.Remove(point_actions[i].KeyAction);
				}
			}
		}
    }
}
		public PointDialog Point { get; private set; }
		public Transition[] Transitions { get; private set; }
		public int Size { get; private set; }

		public PlayingIFrameModel(Repository _db)
		{
			db = _db;
			keys = new SortedSet<int>();
			gameId = Int32.Parse(Request.Cookies["GameID"]);
			int pointNumber = Int32.Parse(Request.Cookies["StartPoint"]);
			Point = db.PointDialogs.FirstOrDefault(i => i.GameId == gameId &&
			i.StateNumber == pointNumber);
			string stringKey = Request.Cookies["SetKeys"];

			var numCollection = Regex.Matches(stringKey, "([0-9]+");
			foreach (Match it in numCollection)
			{
				keys.Add(Int32.Parse(it.Value));
			}
			UpdateTransition();