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
    public class MatcherTest
    {
        [Test]
        public void Matcher_Produces_Matches()
        {
            var Target = new Matcher{ MaxGuesses = 10, Secret = "12345" };
            Target.UserInput("53421");
            Assert.AreEqual("11111", Target.Match);
        }

        [Test]
        public void Matcher_Counts_Matches_only_once()
        {
            var Target = new Matcher { MaxGuesses = 10, Secret = "123" };
            Target.UserInput("211");
            Assert.AreEqual("110", Target.Match);
        }

        [Test]
        public void Matcher_Produces_Weighted_Matches()
        {
            var Target = new Matcher { MaxGuesses = 10, Secret = "123" };
            Target.UserInput("313");
            Assert.AreEqual("210", Target.Match);
        }

        [Test]
        public void Matcher_Considers_inputs_once()
        {
            var Target = new Matcher { MaxGuesses = 10, Secret = "52345" };
            Target.UserInput("52342");
            Assert.AreEqual("22220", Target.Match);
        }

        [Test]
        public void Matcher_Produces_RowMatches()
        {
            var Target = new Matcher { MaxGuesses = 10, Secret = "52345" };            
            Target.UserInput("56666");
            Target.UserInput("52666");
            Target.UserInput("52665");
            Assert.AreEqual(3, Target.RowMatches.Count());
            Assert.AreEqual("22200", Target.RowMatches.Last());
        }
    }
}
