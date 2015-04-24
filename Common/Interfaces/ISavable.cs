using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISavable<T> : ISave<T>, IRead<T>, IDelete
    {
    }
}
