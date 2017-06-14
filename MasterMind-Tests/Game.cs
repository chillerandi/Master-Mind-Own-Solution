﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MasterMind_Kernel;

namespace MasterMind_Tests
{
    [TestFixture]
    public class Game_Test
    {

        private bool IsError(Action action)
        {
            try {
                action();
                return false;
            }
            catch { return true; }
        }

        [Test]
        public void Initial_Game_State()
        {
            var Target = new Game();
            Assert.AreEqual(GameState.Initial, Target.State);
        }

        [Test]
        public void Start_Game()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Assert.AreEqual(GameState.Running, Target.State);
        }

        [Test]
        public void Start_Game_Provides_Random_Number()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Assert.IsNotEmpty(Target.Secret);
            Assert.IsNotNull(Target.Secret);
        }

        [Test]
        public void Game_Secret_between_0_and_9()
        {
            for (var i = 0; i <= 10000; i++) {
                var Target = new Game();
                Target.Start(5, 10);
                Assert.IsTrue(Target.Secret.All(item => item >= '0' && item <= '9'));
            }
        }

        [Test]
        public void State_not_initial_after_input()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Target.UserInput("15324");
            Assert.AreNotEqual(GameState.Initial, Target.State);
        }

        [Test]
        public void input_in_not_initialized_game_raises_error()
        {
            var Target = new Game();
            var error = false;
            try {
                Target.UserInput("15324");
            }
            catch {
                error = true;
            }
            Assert.IsTrue(error);
        }

        [Test]
        public void game_won_if_target_equals_secret()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Target.UserInput(Target.Secret);
            Assert.AreEqual(GameState.won, Target.State);
        }

        [Test]
        public void game_lost_if_maxGuesses_reached()
        {
            var Target = new Game();
            Target.Start(5, 10);
            for (var i = 0; i < Target.MaxGuesses; i++) {
                Target.UserInput("15324");
            }
            Assert.AreEqual(GameState.lost, Target.State);
        }

        [Test]
        public void game_running_if_default_maxGuesses_not_reached()
        {
            var Target = new Game();
            Target.Start(5, 10);
            for (var i = 0; i < Target.MaxGuesses - 1; i++) {
                Target.UserInput("15324");
            }
            Assert.AreEqual(GameState.Running, Target.State);
        }

        [Test]
        public void Game_accepts_parameter_for_maxGuesses()
        {
            var Target = new Game();
            Target.Start(3, 5);
            if (Target.Secret != "123") {
                for (int i = 0; i < Target.MaxGuesses; i++) { Target.UserInput("123"); }
            }
            else { Target.UserInput("456"); }
            Assert.AreEqual(GameState.lost, Target.State);
        }

        [Test]
        public void Finished_Game_Rejects_Input()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Target.UserInput(Target.Secret);
            var Error = false;
            try {
                Target.UserInput("");
            }
            catch { Error = true; }
            Assert.IsTrue(Error);
        }

        //[Test]
        //public void Finished_Game_Accepts_Input_J_For_new_Game()
        //{
        //    var Target = new Game();
        //    Target.Start(5, 10);
        //    Target.UserInput(Target.Secret);
        //    var Error = false;
        //    try {
        //        Target.UserInput("j");
        //    }
        //    catch { Error = true; }
        //    Assert.IsFalse(Error);
        //    Assert.AreEqual(GameState.Initial, Target.State);
        //}

        [Test]
        public void Only_ValidInput_Accpeted()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Target.UserInput("15324");
            Assert.IsTrue(IsError(() => Target.UserInput("")));
            Assert.IsTrue(IsError(() => Target.UserInput("111111")));
            Assert.IsTrue(IsError(() => Target.UserInput("ab123")));
        }

        [Test]
        public void Input_Produces_Info()
        {
            var Target = new Game();
            Target.Start(5, 10);
            Target.UserInput("15324");
            Assert.IsNotNull(Target.Info());
            Assert.IsNotEmpty(Target.Info());
            Assert.AreEqual(Target.Secret.Length, Target.Info().Length);
        }

        [Test]
        public void Game_accepts_parameter_for_Secret_Length()
        {
            var Target = new Game();
            Target.Start(6, 5);
            Assert.IsTrue(IsError(() => Target.UserInput("1")));
            Assert.IsTrue(IsError(() => Target.UserInput("12")));
            Assert.IsTrue(IsError(() => Target.UserInput("123")));
            Assert.IsTrue(IsError(() => Target.UserInput("12345")));
            Assert.IsTrue(IsError(() => Target.UserInput("1234567")));
            Assert.IsFalse(IsError(() => Target.UserInput("123456")));
        }

    }
}
