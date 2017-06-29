using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MasterMind_Kernel
{
    public class Matcher
    {
        public Matcher()
        {
            rowMatches = new List<string>();
        }

        public void UserInput(string v)
        {
            Debug.Assert(v.Length == Secret.Length);
            var Buffer = new StringBuilder();

            var temp = Secret;
            for (int Index = 0; Index < v.Length; ++Index) {
                if (temp[Index] == v[Index]) {
                    Buffer.Append('2');
                    temp = ReplaceWithSpace(temp, Index);
                    v = ReplaceWithSpace(v, Index, '_');
                }
            }

            for (int Index = 0; Index < v.Length; ++Index) {
                if (temp.Contains(v[Index])) {
                    Buffer.Append('1');
                    temp = ReplaceWithSpace(temp, temp.IndexOf(v[Index]));
                }
            }
            for (int index = Buffer.Length; index < v.Length; ++index) {
                Buffer.Append('0');
            }
            rowMatches.Add(Buffer.ToString());
        }

        private string secret_;
        public string Secret
        {
            get { return secret_; }
            set { secret_ = value; }
        }

        private int maxGuesses_;
        public int MaxGuesses
        {
            get { return maxGuesses_; }
            set { maxGuesses_ = value; }
        }

        public int Count
        {
            get { return rowMatches.Count; }
        }

        public string Match
        {
            get { return rowMatches.Any() ? rowMatches.Last() : string.Empty; }
        }

        private List<string> rowMatches;
        public IEnumerable<string> RowMatches
        {
            get { return rowMatches; }
        }

        public string ReplaceWithSpace(string input, int index, char replace = ' ')
        {
            var Remover = new StringBuilder(input);
            Remover[index] = replace;
            return Remover.ToString();
        }
    }
}
