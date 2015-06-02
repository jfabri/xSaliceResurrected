using System;
using LeagueSharp;
using LeagueSharp.Common;

namespace xSaliceResurrected.Managers
{
    class LagManager
    {
        private static Menu _menu;
        private static int _incrementTick;

        public static void AddLagManager(Menu menu)
        {
            _menu = new Menu("Lag Manager", "Lag Manager");
            _menu.AddItem(new MenuItem("lagManagerEnabled", "Enabled", true).SetValue(true));
            _menu.AddItem(new MenuItem("lagManagerDelay", "Delay In Calculation(ms), Increase too decrease lag", true).SetValue(new Slider(0)));

            menu.AddSubMenu(_menu);

            Game.OnUpdate += OnUpdate;
        }

        public static bool Enabled
        {
            get { return _menu.Item("lagManagerEnabled", true).GetValue<bool>(); }
        }

        public static bool ReadyState
        {
            get { return _incrementTick == 0; }
        }

        private static void OnUpdate(EventArgs args)
        {
            _incrementTick++;

            if (_incrementTick > _menu.Item("lagManagerDelay", true).GetValue<Slider>().Value)
                _incrementTick = 0;
        }

    }
}
