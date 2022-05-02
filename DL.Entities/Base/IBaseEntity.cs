using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities.Base
{
    public interface IBaseEntity
    {
        long Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
