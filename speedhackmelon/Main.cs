﻿using MelonLoader;
using Harmony;
using NKHook6.Api;
using Assets.Scripts.Unity.UI_New.InGame.Races;
using Assets.Scripts.Simulation.Towers.Weapons;
using NKHook6;
using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;
using NKHook6.Api.Extensions;
using Assets.Scripts.Unity.UI_New.Main;
using NKHook6.Api.Events;
using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Models.Towers;

using Assets.Scripts.Unity;


using static NKHook6.Api.Events._Towers.TowerEvents;
using Assets.Scripts.Simulation.Towers;

using static NKHook6.Api.Events._Weapons.WeaponEvents;
using Assets.Scripts.Utils;

using static NKHook6.Api.Events._TimeManager.TimeManagerEvents;
using Il2CppSystem.Collections;
using NKHook6.Api.Events._Bloons;
using NKHook6.Api.Events._Weapons;

namespace speedhackmelon
{
    public class Main : MelonMod
    {

        public static int speed = 3;
        public static bool hypersonic = false;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            EventRegistry.instance.listen(typeof(Main));
            Logger.Log("speed mod loaded");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            TimeManager.compromisedFastFowardRate = speed;
            TimeManager.maxSimulationStepsPerUpdate = speed;

        }

        [EventAttribute("WeaponCreatedEvent")]
        public static void WeaponCreatedEvent(WeaponEvents.CreatedEvent e)
        {
            if(hypersonic)
                e.instance.weaponModel.rate = 0;
        }



        [EventAttribute("KeyPressEvent")]
        public static void onEvent(KeyEvent e)
        {

            string key = e.key + "";

            //if (key == "Alpha5")
            //{
            //    hypersonic = !hypersonic;
            //    Logger.Log("hypersonic: " + hypersonic);
            //}
            if (key == "Alpha6")
            {
                speed = 3;
                Logger.Log("speed = 3");
            }
            if (key == "Alpha7")
            {
                speed = 10;
                Logger.Log("speed = 10");
            }
            if (key == "Alpha8")
            {
                speed = 50;
                Logger.Log("speed = 50");
            }
            if (key == "Alpha9")
            {
                speed = 5;
                Logger.Log("speed = 5");
            }



        }




    }

}
