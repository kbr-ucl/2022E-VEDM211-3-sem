using Bmi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmi.Application
{
    public interface IBmiRepository
    {
        void Add(BmiEntity bmiEntity);
    }
}
