using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bmi.Domain;

namespace Bmi.Application
{
    public  class BmiService : IBmiService
    {
        private readonly IBmiRepository _repository;

        public BmiService(IBmiRepository repository)
        {
            _repository = repository;
        }
        void IBmiService.Add(BmiDto bmi)
        {
            var bmiEntity = new BmiEntity();
            _repository.Add(bmiEntity);

        }
    }
}
