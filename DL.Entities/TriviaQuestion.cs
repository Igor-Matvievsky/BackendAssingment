using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class TriviaQuestion : Question
    {
        public override bool IsPollQuestion() => false;
    }
}
