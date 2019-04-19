﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameTextParsing
{
    enum ActionType { Find, Lose }
    class GameAction
    {
        public ActionType Action { get; set; }
        public int Key { get; set; }
    }

    class DialogLink
    {
        public string Text { get; set; }
        public GameAction[] Actions { get; set; }
        public int NextID { get; set; }
        public string Condition { get; set; }

        public DialogLink()
        {
            Actions = new GameAction[0];
            Condition = "";
        }
    }

    class DialogPoint
    {
        public string Text { get; set; }
        public int ID { get; set; }
        public GameAction[] Actions { get; set; }
        public DialogLink[] Links { get; set; }
    }

    enum SwitchType { Determinate, Probabilistic }

    class SwitchLink
    {
        public string Condition { get; set; }
        public GameAction[] Actions { get; set; }
        public int NextID { get; set; }
    }

    class SwitchPoint
    {
        public int ID { get; set; }
        public SwitchType SType { get; set; }
        public GameAction[] Actions { get; set; }
        public SwitchLink[] Links { get; set; }
    }
}
