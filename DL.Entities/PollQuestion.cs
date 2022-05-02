using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class PollQuestion : Question
    {
        public override bool IsPollQuestion() => true;
    }
}
