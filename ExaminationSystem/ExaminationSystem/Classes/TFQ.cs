using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Classes
{
    internal class TFQ : Question
    {
        public TFQ(string _Header, string _Body, float _Mark, Answer _RightAnswer) : base(_Header, _Body, _Mark, _RightAnswer)
        {
        }

        public override string ToString()
        {
            return Body ?? string.Empty;
        }
    }
}
