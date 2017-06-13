using System;
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
            Target.Start();
            Assert.AreEqual(GameState.Running, Target.State);
        }

        [Test]
        public void Start_Game_Provides_Random_Number()
        {
            var Target = new Game();
            Target.Start();
            Assert.IsNotEmpty(Target.Secret);
            Assert.IsNotNull(Target.Secret);
        }

        [Test]
        public void Game_Secret_between_0_and_9()
        {
            for (var i = 0; i <= 10000; i++) {
                var Target = new Game();
                Target.Start();
                Assert.IsTrue(Target.Secret.All(item => item >= '0' && item <= '9'));
            }
        }

        [Test]
        public void State_not_initial_after_input()
        {
            var Target = new Game();
            Target.Start();
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
            Target.Start();
            Target.UserInput(Target.Secret);            
            Assert.AreEqual(GameState.won, Target.State);
        }

        [Test]
        public void game_lost_if_target_equals_secret()
        {
            var Target = new Game();
            Target.Start();
            for (var i = 0 ; i < Game.MaxGuesses ; i++) { Target.UserInput("15324"); }
            Assert.AreEqual(GameState.lost, Target.State);
        }

        [Test]
        public void Finished_Game_Rejects_Input()
        {
            var Target = new Game();
            Target.Start();
            Target.UserInput(Target.Secret);
            var Error = false;
            try {
                Target.UserInput("");
            }
            catch { Error = true; }
            Assert.IsTrue(Error);
        }

        [Test]
        public void Only_ValidInput_Accpeted()
        {
            var Target = new Game();
            Target.Start();
            Target.UserInput("15324");
            Assert.IsTrue(IsError(() => Target.UserInput("")));
            Assert.IsTrue(IsError(() => Target.UserInput("111111")));
            Assert.IsTrue(IsError(() => Target.UserInput("ab123")));
        }

        [Test]
        public void Input_Produces_Info()
        {
            var Target = new Game();
            Target.Start();
            Target.UserInput("15324");
            Assert.IsNotNull(Target.Info());
            Assert.IsNotEmpty(Target.Info());
            Assert.AreEqual(Target.Secret.Length, Target.Info().Length);
        }

        private bool IsError(Action action)
        {
            try {
                action();
                return false;
            }
            catch { return true; }
        }
    }
}
